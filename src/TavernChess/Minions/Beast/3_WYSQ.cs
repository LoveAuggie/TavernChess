using System;
using System.Collections.Generic;
using System.Text;
using TavernChess.Buff;
using TavernChess.Buff.DH;

namespace TavernChess.Minions.Beast
{
    public class WYSQ : MainMinion
    {
        public WYSQ() : this(false) { }
        public WYSQ(bool isgold)
            : base(isgold)
        {
            if (isgold)
                Attack = Hp = 4;
            else
                Attack = Hp = 2;

            this.deathList.Add(new WYJL(this.IsGold));
        }
        public override string Name => "瘟疫鼠群";

        public override int Start => 3;

        public override int Fee => 3;

        public override MRace Race => MRace.Beast;

        public override bool isDeathMinion { get; set; } = true;
    }
}
