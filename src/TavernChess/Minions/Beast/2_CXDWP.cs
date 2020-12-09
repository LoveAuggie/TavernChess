using System;
using System.Collections.Generic;
using System.Text;
using TavernChess.Buff.DH;

namespace TavernChess.Minions.Beast
{
    public class CXDWP : MainMinion
    {
        public CXDWP() : this(false) { }
        public CXDWP(bool isgold)
            : base(isgold)
        {
            if (isgold)
            {
                Attack = Hp = 2;
                this.deathList.Add(new WPJL(true));
            }
            else
            {
                Attack = Hp = 1;
                this.deathList.Add(new WPJL(false));
            }
        }

        public override string Name => "慈祥的外婆";

        public override int Start => 2;

        public override int Fee => 2;

        public override MRace Race => MRace.Beast;

        public override bool isDeathMinion { get; set; } = true;
    }
}
