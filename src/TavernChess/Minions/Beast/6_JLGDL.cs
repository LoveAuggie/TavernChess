using System;
using System.Collections.Generic;
using System.Text;
using TavernChess.Buff;

namespace TavernChess.Minions.Beast
{
    public class JLGDL : MainMinion
    {
        public JLGDL() : this(false) { }
        public JLGDL(bool isgold)
            : base(isgold)
        {
            if (isgold)
            {
                Attack = Hp = 8;
                deathList.Add(new JLBH(true));
            }
            else
            {
                Attack = Hp = 4;
                deathList.Add(new JLBH(false));
            }
        }

        public override string Name => "巨狼戈德林";

        public override int Start => 6;

        public override int Fee => 6;

        public override MRace Race => MRace.Beast;

        public override bool isDeathMinion { get; set; } = true;
    }
}
