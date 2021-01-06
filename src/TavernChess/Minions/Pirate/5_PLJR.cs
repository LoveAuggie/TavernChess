using System;
using System.Collections.Generic;
using System.Text;

namespace TavernChess.Minions.Pirate
{
    public class PLJR : MainMinion
    {
        private int rCount;
        public PLJR() : this(false) { }
        public PLJR(bool isgold)
            : base(isgold)
        {
            if (isgold)
            {
                Attack = 12;
                Hp = 14;
                rCount = 4;
                AttackCount = 4;
            }
            else
            {
                Attack = 6;
                Hp = 7;
                rCount = 2;
                AttackCount = 2;
            }
        }

        public override string Name => "破浪巨人";

        public override int Start => 5;

        public override int Fee => 5;

        public override MRace Race => MRace.Pirate;

        protected internal override void AfterDoAttck(int damage, MainMinion target)
        {
            if (damage > target.Hp)
            {
                foreach (var m in this.Companions.AliveList)
                {
                    if (m.Race.Is(MRace.Pirate))
                    {
                        m._attack += rCount;
                        m._hp += rCount;
                    }
                }
            }
        }
    }
}
