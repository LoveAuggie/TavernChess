using System;
using System.Collections.Generic;
using System.Text;
using TavernChess.Minions.Adds;

namespace TavernChess.Minions.Beast
{
    public class TPKJL : MainMinion
    {
        public TPKJL() : this(false) { }
        public TPKJL(bool isgold)
            : base(isgold)
        {
            if (isgold)
            {
                Attack = Hp = 14;
            }
            else
            {
                Attack = Hp = 7;
            }
        }

        public override string Name => "铁皮恐角龙";

        public override int Start => 5;

        public override int Fee => 5;

        public override MRace Race => MRace.Beast;

        protected internal override void AfterAttck(int damage, MainMinion target)
        {
            if (damage > target.Hp)
            {
                var count = IsGold ? 10 : 5;
                this.Companions.CallAddMinion(this, 0, new AddsMinion("恐角龙", count, count, IsGold, MRace.Beast));
            }
        }
    }
}
