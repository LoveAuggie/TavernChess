using System;
using System.Collections.Generic;
using System.Text;

namespace TavernChess.Minions.Beast
{
    public class BNJX : MainMinion
    {
        public BNJX() : this(false) { }
        public BNJX(bool isgold)
            : base(isgold)
        {
            if (isgold)
            {
                Attack = 8;
                Hp = 4;
            }
            else
            {
                Attack = 4;
                Hp = 2;
            }
        }

        public override string Name => "暴怒的巨蜥";

        public override int Start => 2;

        public override int Fee => 2;

        public override MRace Race => MRace.Beast;
    }
}
