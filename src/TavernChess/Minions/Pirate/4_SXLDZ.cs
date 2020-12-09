using System;
using System.Collections.Generic;
using System.Text;

namespace TavernChess.Minions.Pirate
{
    public class SXLDZ : MainMinion
    {
        private int rCount;
        public SXLDZ() : this(false) { }
        public SXLDZ(bool isgold)
            : base(isgold)
        {
            if (isgold)
            {
                Attack = 8;
                Hp = 10;
                rCount = 4;
            }
            else
            {
                Attack = 4;
                Hp = 5;
                rCount = 2;
            }
        }

        public override string Name => "撕心狼队长";

        public override int Start => 4;

        public override int Fee => 4;

        public override MRace Race => MRace.Pirate;

        protected internal override void BeforAttack(MainMinion minion)
        {
            if (minion.Race.Is(MRace.Pirate))
            {
                minion._attack += rCount;
                minion._hp += rCount;
            }
        }
    }

}
