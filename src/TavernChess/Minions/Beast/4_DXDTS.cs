using System;
using System.Collections.Generic;
using System.Text;

namespace TavernChess.Minions.Beast
{
    public class DXDTS : MainMinion
    {
        public DXDTS() : this(false) { }
        public DXDTS(bool isgold)
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

        public override string Name => "洞穴多头蛇";

        public override int Start => 4;

        public override int Fee => 4;

        public override MRace Race => MRace.Beast;

        protected internal override void AfterDoAttck(int damage, MainMinion target)
        {
            var before = target.Companions.GetByIndex(target.Index - 1);
            if (before != null)
            {
                before.GetHurt(damage);
            }

            var after = target.Companions.GetByIndex(target.Index + 1);
            if (after != null)
            {
                after.GetHurt(damage);
            }
        }
    }
}
