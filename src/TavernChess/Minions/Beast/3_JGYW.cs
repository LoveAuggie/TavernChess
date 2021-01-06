using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TavernChess.Minions.Beast
{
    public class JGYW : MainMinion
    {
        public JGYW() : this(false) { }
        public JGYW(bool isgold)
            : base(isgold)
        {
            if (isgold)
            {
                Attack = 8;
                Hp = 6;
            }
            else
            {
                Attack = 4;
                Hp = 3;
            }
        }

        public override string Name => "巨大的金刚鹦鹉";

        public override int Start => 3;

        public override int Fee => 3;

        public override MRace Race => MRace.Beast;

        protected internal override void AfterDoAttck(int damage, MainMinion target)
        {
            var dList = this.Companions.AliveList.Where(t => t.deathList != null && t.deathList.Count > 0).ToList();
            dList.Remove(this);
            if (dList.Count > 0)
            {
                MainMinion m = null;
                if (dList.Count == 1)
                {
                    m = dList[0];
                }
                else
                {
                    Random rand = new Random(Guid.NewGuid().GetHashCode());
                    m = dList[rand.Next(dList.Count)];
                }

                m.Companions = this.Companions;
                m.Enemies = this.Enemies;

                m.CallDeath();
                if (IsGold)
                {
                    m.CallDeath();
                }
            }
        }
    }
}
