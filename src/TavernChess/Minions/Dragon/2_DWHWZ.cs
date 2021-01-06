using System;
using System.Collections.Generic;
using System.Text;

namespace TavernChess.Minions.Dragon
{
    public class DWHWZ : MainMinion
    {
        public DWHWZ() : this(false) { }
        public DWHWZ(bool isgold)
            : base(isgold)
        {
            if (isgold)
            {
                Attack = 4;
                Hp = 8;
            }
            else
            {
                Attack = 2;
                Hp = 4;
            }
        }

        public override string Name => "雕文护卫者";

        public override int Start => 2;

        public override int Fee => 3;

        public override MRace Race => MRace.Dragon;

        protected internal override void BeforeDoAttack(MainMinion target)
        {
            if (this.IsGold)
                this.Attack = this.Attack * 3;
            else
                this.Attack = this.Attack * 2;
        }
    }
}
