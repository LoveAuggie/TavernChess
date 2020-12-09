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
        public MainMinion BaseMinion { get; set; }

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
            this.AfterAttck(damage1, enemy);

            // 受到伤害，
            enemy.GetHurt(damage1);
            this.GetHurt(damage2);

            // 敌方受到攻击事件
            enemy.AfterGetAttack(damage1, this);

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
                var minion = this.BaseMinion;
                minion.Revived = false;
                Companions.CallAddMinion(this, 0, this.BaseMinion);
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
        internal virtual void BeforeInsert(List<MainMinion> minions)
        {
        }

        internal virtual void DivienShieldChange(bool value, MainMinion minion)
        {

        }

        internal virtual void AfterInsert(MainMinion minion)
        {

        }

        internal virtual void AfterDie(MainMinion minion)
        {
            
        }

        internal virtual void AfterDeath(MainMinion minion)
        {
            
        }

        protected virtual void AfterGetAttack(int damage, MainMinion mainMinion)
        {

        }

        protected internal virtual void BeforAttack(MainMinion minion)
        {

        }

        protected internal virtual void AfterAttck(int damage, MainMinion target)
        {
        }

        protected internal virtual int GuangHuanAttack(MainMinion minion)
        {
            return 0;
        }

        protected internal virtual int GuangHuanHp(MainMinion minion)
        {
            return 0;
        }
        #endregion

        object ICloneable.Clone()
        {
            return base.MemberwiseClone();
        }
    }
}
