using System;
using System.Collections.Generic;
using System.Text;

namespace TavernChess.Minions.Beast
{
    public class TL : MainMinion
    {
        private int rCount = 1;
        public TL() : this(false) { }
        public TL(bool isgold)
            : base(isgold)
        {
            if (isgold)
            {
                Attack = Hp = 4;
                rCount = 2;
            }
            else
            {
                Attack = Hp = 2;
                rCount = 1;
            }
        }
        public override string Name => "土狼";

        public override int Start => 1;

        public override int Fee => 1;

        public override MRace Race => MRace.Beast;

        internal override void AfterDie(MainMinion minion)
        {
            if (minion.Race.Is(MRace.Beast))
            {
                this._attack += (2 * rCount);
                this._hp += 1 * rCount;
            }
        }
    }
}
