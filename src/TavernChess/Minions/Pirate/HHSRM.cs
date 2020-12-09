using System;
using System.Collections.Generic;
using System.Text;

namespace TavernChess.Minions.Pirate
{
    public class HHSRM : MainMinion
    {
        public HHSRM() : this(false) { }

        public HHSRM(bool isgold)
            : base(isgold)
        {
            if (isgold)
            {
                Attack = 4;
                Hp = 10;
            }
            else
            {
                Attack = 2;
                Hp = 5;
            }
        }

        public override string Name => "喊号食人魔";

        public override int Start => 2;

        public override int Fee => 3;

        public override MRace Race => MRace.Pirate;

        protected override void AfterGetAttack(int damage, MainMinion mainMinion)
        {
            if (!this.isDie && this.Hp > 0)
            {
                this.StartAttack();
            }
        }
    }
}
