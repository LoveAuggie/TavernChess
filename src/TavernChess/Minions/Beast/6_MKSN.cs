using System;
using System.Collections.Generic;
using System.Text;

namespace TavernChess.Minions.Beast
{
    public class MKSN : MainMinion
    {
        public MKSN() : this(false) { }
        public MKSN(bool isgold)
            : base(isgold)
        {
            if (isgold)
            {
                Attack = 4;
                Hp = 16;
            }
            else
            {
                Attack = 2;
                Hp = 8;
            }
        }

        public override string Name => "迈克斯纳";

        public override int Start => 6;

        public override int Fee => 6;

        public override MRace Race => MRace.Beast;

        public override bool Legenda => true;

        public override bool Posionus { get; set; } = true;
    }
}
