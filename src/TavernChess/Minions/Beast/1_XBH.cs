using System;
using System.Collections.Generic;
using System.Text;

namespace TavernChess.Minions.Beast
{
    public class XBH : MainMinion
    {
        public XBH() : this(false) { }
        public XBH(bool isgold)
            : base(isgold)
        {
            if (isgold)
                Attack = Hp = 2;
            else
                Attack = Hp = 1;
        }

        public override string Name => "雄斑虎";

        public override MRace Race => MRace.Beast;

        public override int Start => 1;

        public override int Fee => 1;
    }
}
