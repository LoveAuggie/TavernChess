using System;
using System.Collections.Generic;
using System.Text;
using TavernChess.Buff.DH;

namespace TavernChess.Minions.Pirate
{
    public class HDWL : MainMinion
    {
        public HDWL() : this(false) { }

        public HDWL(bool isgold)
            : base(isgold)
        {
            if (isgold)
            {
                Attack = 4;
                Hp = 2;
            }
            else
            {
                Attack = 2;
                Hp = 1;
            }

            this.deathList.Add(new WLJL(isgold));
        }

        public override string Name => "海盗无赖";

        public override int Start => 1;

        public override int Fee => 1;

        public override MRace Race => MRace.Pirate;
    }
}
