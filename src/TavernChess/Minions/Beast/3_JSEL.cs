using System;
using System.Collections.Generic;
using System.Text;
using TavernChess.Buff.DH;

namespace TavernChess.Minions.Beast
{
    public class JSEL : MainMinion
    {
        public JSEL() : this(false) { }
        public JSEL(bool isgold)
            : base(isgold)
        {
            if (isgold)
                Attack = Hp = 6;
            else
                Attack = Hp = 3;

            deathList.Add(new LZJL(IsGold));
        }
        public override string Name => "寄生饿狼";

        public override int Start => 3;

        public override int Fee => 3;

        public override MRace Race => MRace.Beast;

        public override bool isDeathMinion { get; set; } = true;
    }
}
