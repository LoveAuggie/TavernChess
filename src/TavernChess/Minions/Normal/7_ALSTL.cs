using System;
using System.Collections.Generic;
using System.Text;

namespace TavernChess.Minions.Normal
{
    public class ALSTL : MainMinion
    {
        public ALSTL() : this(false) { }
        public ALSTL(bool isgold)
            : base(isgold)
        {
            if (isgold)
                Attack = Hp = 14;
            else
                Attack = Hp = 7;

            this.RevivedMinion = new ALSTL(this.IsGold);
        }
        public override string Name => "永恒者埃利斯特拉";

        public override int Start => 6;

        public override int Fee => 7;

        public override MRace Race => MRace.None;

        public override bool DivienShield { get; set; } = true;

        public override bool Revived { get; set; } = true;

        protected internal override MainMinion BeforeCallGotAttack(MainMinion minion, MainMinion target)
        {
            if (target.Taunt)
                return this;

            return base.BeforeCallGotAttack(minion, target);
        }
    }
}
