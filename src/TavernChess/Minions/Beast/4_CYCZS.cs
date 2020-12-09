using System;
using System.Collections.Generic;
using System.Text;
using TavernChess.Buff.DH;

namespace TavernChess.Minions.Beast
{
    public class CYCZS : MainMinion
    {
        public CYCZS() : this(false) { }
        public CYCZS(bool isgold)
            : base(isgold)
        {
            if (isgold)
            {
                Attack = 12;
                Hp = 10;
            }
            else
            {
                Attack = 6;
                Hp = 5;
            }
            deathList.Add(new TLJL(IsGold));
        }

        public override string Name => "草原长鬃狮";

        public override int Start => 4;

        public override int Fee => 6;

        public override MRace Race => MRace.Beast;

        public override bool isDeathMinion { get; set; } = true;
    }
}
