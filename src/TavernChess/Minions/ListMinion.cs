using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TavernChess.Minions.Adds;
using TavernChess.Minions.Normal;

namespace TavernChess.Minions
{
    public class ListMinion
    {
        public string Name { get; set; } = "D1";

        public ListMinion Enemies;

        public List<MainMinion> minions = new List<MainMinion>();

        public List<MainMinion> AliveList
        {
            get { return minions.Where(t => !t.isDie && t.Hp > 0).ToList(); }
        }

        public int RunIndex;

        public bool Attack()
        {
            var minion = GetRunMinon();
            if (minion == null)
                return false;

            minion.Companions = this;
            minion.Enemies = Enemies;
            minion.StartAttack();
            if (minion.Hp > 0)
            {
                SetNextRunIndex();
            }

            if (AliveList.Count <= 0)
                return false;

            return true;
        }

        internal void StartFight()
        {
        }

        internal MainMinion GetByIndex(int index)
        {
            if (index >= 0 && index < this.AliveList.Count)
            {
                var m = this.AliveList[index];
                m.Enemies = this.Enemies;
                m.Companions = this;
                return m;
            }
            return null;
        }

        private void SetNextRunIndex()
        {
            if (RunIndex >= this.AliveList.Count - 1)
            {
                RunIndex = 0;
            }
            else
            {
                RunIndex++;
            }
        }

        private MainMinion GetRunMinon()
        {
            if (this.AliveList != null && this.AliveList.Count > 0)
            {
                if (this.AliveList.Count > RunIndex)
                    return this.AliveList[RunIndex];
                else
                    return this.AliveList[0];
            }
            return null;
        }

        internal MainMinion ChooseDefense()
        {
            var tauns = this.AliveList.Where(t => t.Taunt && !t.isDie && t.Hp > 0).ToList();
            MainMinion m = null;
            if (tauns.Count > 0)
            {
                m = RandomGet(tauns);
            }
            else
            {
                m = RandomGet(this.AliveList.Where(t => !t.isDie && t.Hp > 0).ToList());
            }
            if (m != null)
            {
                m.Companions = this;
                m.Enemies = this.Enemies;
            }
            return m;
        }

        internal void CheckDeath()
        {
            var dies = this.minions.Where(t => t.isDie).ToList();
            if (dies.Count > 0)
            {
                foreach (var d in dies)
                {
                    d.Die();
                }
            }

            // 亡语效果触发完毕之后再删除
            this.minions.RemoveAll(t => t.isDie || t.Hp < 0);
        }

        private MainMinion RandomGet(List<MainMinion> minions)
        {
            if (minions.Count <= 0) return null;
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            var index = rand.Next(0, minions.Count);
            return minions[index];
        }

        #region 随从的行为，对应各种效果的检查
        internal bool CallAddMinion(MainMinion source, int index, params MainMinion[] addMinions)
        {
            if (AliveList.Count >= 7)
            {
                return false;
            }
            var curList = AliveList.ToArray().ToList();
            curList.ForEach(t => t.Companions = this);

            foreach (var m in curList)
            {
                var list = addMinions.ToList();
                m.BeforeCallInsert(list);
                addMinions = list.ToArray();
            }
            if (index == 0)
                index = source.Index;

            List<MainMinion> Addlist = new List<MainMinion>();
            if (index < AliveList.Count && index >= 0)
                foreach (var m in addMinions)
                {
                    if (AliveList.Count >= 7) break;

                    m.Companions = this;
                    m.Enemies = this.Enemies;
                    minions.Insert(index+1, m);
                    if (m is AddsMinion am)
                    {
                        am.AfterAdd();
                    }

                    foreach (var curMinion in curList)
                    {
                        curMinion.AfterCallInsert(m);
                    }
                }
            else
                foreach (var m in addMinions)
                {
                    if (AliveList.Count() >= 7) break;

                    minions.Add(m);
                    if (m is AddsMinion am)
                    {
                        am.AfterAdd();
                    }

                    foreach (var curMinion in curList)
                    {
                        curMinion.AfterCallInsert(m);
                    }
                }
            return true;
        }

        internal void CallBeforeAttack(MainMinion minion)
        {
            foreach (var m in this.AliveList)
            {
                m.BeforCallDoAttack(minion);
            }
        }

        internal MainMinion CallBeforeGetAttack(MainMinion mainMinion, MainMinion target)
        {
            foreach (var c in this.AliveList)
            {
                target = c.BeforeCallGotAttack(mainMinion, target);
            }
            return target;
        }

        internal void CallAfterDie(MainMinion minion)
        {
            foreach (var m in this.AliveList)
            {
                m.AfterDie(minion);
            }
        }

        internal void CallAfterDeath(MainMinion minion)
        {
            for (int i = 0; i < this.AliveList.Count; i++)
            {
                this.AliveList[i].AfterCallDeath(minion);
            }
        }

        internal int CallGuangHuanHp(MainMinion minion)
        {
            return this.AliveList.Select(t => t.GuangHuanHp(minion)).Sum(); ;
        }

        internal int CallGuangHuanAttack(MainMinion minion)
        {
            return this.AliveList.Select(t => t.GuangHuanAttack(minion)).Sum();
        }

        internal void CallDivienShieldChange(bool value, MainMinion minion)
        {
            foreach (var m in this.AliveList)
            {
                m.AfterDivienShieldChange(value, minion);
            }
        }
        #endregion
    }
}
