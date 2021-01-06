using System;
using System.Collections.Generic;
using System.Text;
using TavernChess.Buff;

namespace TavernChess.Minions
{
    public abstract class MainMinion:ICloneable
    {
        /// <summary>
        /// 基础属性
        /// </summary>

        public abstract string Name { get; }

        public abstract int Start { get; }

        public abstract int Fee { get; }

        public abstract MRace Race { get; }

        protected internal int _attack;
        public int Attack
        {
            get { return _attack + this.Companions.CallGuangHuanAttack(this); }
            set { _attack = value; }
        }

        protected internal int _hp;
        public int Hp
        {
            get { return _hp + this.Companions.CallGuangHuanHp(this); }
            set { _hp = value; }
        }

        public bool IsGold { get; private set; }

        public Dictionary<string, object> properties = new Dictionary<string, object>();

        public MainMinion(bool isgold) 
        {
            this.IsGold = isgold;
        }

        public virtual bool Legenda { get; } = false;

        public virtual bool DivienShield { get; set; } = false;

        public virtual bool Posionus { get; set; } = false;

        public virtual bool Revived { get; set; } = false;

        public MainMinion RevivedMinion { get; set; }

        public virtual bool Taunt { get; set; } = false;

        public virtual int AttackCount { get; set; } = 1;

        public virtual bool isDeathMinion { get; set; } = false;

        public bool isDie { get; set; } = false;

        public int Index { get { return this.Companions.AliveList.IndexOf(this); } }

        public virtual List<Deathrattle> deathList { get; set; } = new List<Deathrattle>();

        public ListMinion Companions = new ListMinion();

        public ListMinion Enemies = new ListMinion();

        public void StartAttack()
        {
            if (this.Attack <= 0)
                return;

            for (int i = 0; i < AttackCount; i++)
            {
                var enemy = Enemies.ChooseDefense();

                enemy = Enemies.CallBeforeGetAttack(this, enemy);

                enemy.BeforeGotAttack(this);

                DoAttack(enemy);
            }
        }

        private void DoAttack(MainMinion enemy)
        {
            Console.WriteLine($"[{this.Companions.Name}][{this.Name}]({this.Attack} - {this.Hp}) => [{enemy.Companions.Name}][{enemy.Name}]({enemy.Attack} - {enemy.Hp})");

            this.Companions.CallBeforeAttack(this);



            // 先计算攻击伤害
            var damage1 = this.SetHurt(enemy);
            var damage2 = enemy.SetHurt(this);

            // 攻击后事件
            this.AfterDoAttck(damage1, enemy);

            // 受到伤害，
            enemy.GetHurt(damage1);
            this.GetHurt(damage2);

            // 敌方受到攻击事件
            enemy.AfterGotAttack(damage1, this);

            // 双方结算死亡
            Companions.CheckDeath();
            Enemies.CheckDeath();

            Console.WriteLine($"    => [{this.Companions.Name}][{this.Name}]({this.Hp}) => [{enemy.Companions.Name}][{enemy.Name}]({enemy.Hp})");
        }

        private int SetHurt(MainMinion target)
        {
            var damage = this.Attack;
            if (target.DivienShield)
            {
                this.SetDivienShield(false);
                damage = 0;
            }

            if (this.Posionus && damage > 0)
            {
                target.isDie = true;
            }

            return damage;
        }

        protected internal int GetHurt(int attack)
        {
            this.Hp -= attack;

            if (this.Hp <= 0)
                this.isDie = true;

            return attack;
        }

        protected internal void Die()
        {
            //Companions.Remove(this);
            Console.WriteLine($"    => [{this.Companions.Name}][{this.Name}] Die, Count=>{Companions.AliveList.Count}");

            this.CallDeath();

            if (this.Revived)
            {
                var minion = this.RevivedMinion;
                minion.Revived = false;
                Companions.CallAddMinion(this, 0, this.RevivedMinion);
            }

            this.Companions.CallAfterDie(this);
        }

        protected internal void CallDeath()
        {
            if (this.deathList != null && this.deathList.Count > 0)
            {
                foreach (var d in deathList)
                {
                    d.LogRun(this);
                }
            }
            this.Companions.CallAfterDeath(this);
        }

        public MainMinion MClone()
        {
            return (MainMinion)this.MemberwiseClone();
        }

        protected virtual void StartGame() 
        {

        }

        protected internal void SetDivienShield(bool value)
        {
            var old = this.DivienShield;
            this.DivienShield = value;
            if (old != value)
            {
                this.Companions.CallDivienShieldChange(value, this);
            }
        }

        #region 各种随从效果的虚拟方法

        #region 友方的各种状态
        /// <summary>
        /// 当召唤其他随从时
        /// </summary>
        /// <param name="minions">随从列表</param>
        internal virtual void BeforeCallInsert(List<MainMinion> minions)
        {
        }

        /// <summary>
        /// 当友方失去或获得圣盾时
        /// </summary>
        /// <param name="value">true:获得 false：失去</param>
        /// <param name="minion">友方随从</param>
        internal virtual void AfterDivienShieldChange(bool value, MainMinion minion)
        {

        }

        /// <summary>
        /// 当友方召唤随从后
        /// </summary>
        /// <param name="minion">召唤的随从</param>
        internal virtual void AfterCallInsert(MainMinion minion)
        {

        }

        /// <summary>
        /// 友方死亡后
        /// </summary>
        /// <param name="minion">死亡的随从</param>
        internal virtual void AfterDie(MainMinion minion)
        {
            
        }

        /// <summary>
        /// 友方触发亡语后
        /// </summary>
        /// <param name="minion">触发亡语的随从</param>
        internal virtual void AfterCallDeath(MainMinion minion)
        {

        }

        /// <summary>
        /// 当友方被攻击时
        /// </summary>
        /// <param name="minion">攻击者</param>
        /// <param name="target">友方目标</param>
        /// <returns></returns>
        protected internal virtual MainMinion BeforeCallGotAttack(MainMinion minion, MainMinion target)
        {
            return target;
        }

        /// <summary>
        /// 友方发动攻击时
        /// </summary>
        /// <param name="minion">攻击者</param>
        protected internal virtual void BeforCallDoAttack(MainMinion minion)
        {

        }
        #endregion

        #region 自身的各种效果
        /// <summary>
        /// 自己攻击之前
        /// </summary>
        /// <param name="target">目标</param>
        protected internal virtual void BeforeDoAttack(MainMinion target)
        {
        }

        /// <summary>
        /// 自己攻击后
        /// </summary>
        /// <param name="damage">伤害</param>
        /// <param name="target">目标随从</param>
        protected internal virtual void AfterDoAttck(int damage, MainMinion target)
        {
        }

        /// <summary>
        /// 当自己被攻击前
        /// </summary>
        /// <param name="minion">攻击者</param>
        protected internal virtual void BeforeGotAttack(MainMinion minion)
        {
            
        }


        /// <summary>
        /// 当被攻击后
        /// </summary>
        /// <param name="damage">伤害数</param>
        /// <param name="mainMinion">攻击者</param>
        protected internal virtual void AfterGotAttack(int damage, MainMinion mainMinion)
        {

        }

        #endregion

        /// <summary>
        /// 攻击力光环效果
        /// </summary>
        /// <param name="minion"></param>
        /// <returns></returns>
        protected internal virtual int GuangHuanAttack(MainMinion minion)
        {
            return 0;
        }

        /// <summary>
        /// 血量光环效果
        /// </summary>
        /// <param name="minion"></param>
        /// <returns></returns>
        protected internal virtual int GuangHuanHp(MainMinion minion)
        {
            return 0;
        }
        #endregion
    }
}
