using System;
using System.Collections.Generic;
using System.Text;

namespace TavernChess.Minions.Beast
{
    public class XMM : MainMinion
    {
        private int rCount;
        public XMM() : this(false) { }
        public XMM(bool isgold)
            : base(isgold)
        {
            if (isgold)
            {
                Attack = Hp = 10;
                rCount = 10;
            }
            else
            {
                Attack = Hp = 5;
                rCount = 5;
            }
        }

        public override string Name => "熊妈妈";

        public override int Start => 6;

        public override int Fee => 6;

        public override MRace Race => MRace.Beast;

        internal override void BeforeCallInsert(List<MainMinion> minions)
        {
            foreach (var minion in minions)
            {
                if (minion.Race.Is(MRace.Beast))
                {
                    minion._attack += rCount;
                    minion._hp += rCount;
                }
            }
        }
    }
}
