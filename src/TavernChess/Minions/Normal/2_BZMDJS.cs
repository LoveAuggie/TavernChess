using System;
using System.Collections.Generic;
using System.Text;

namespace TavernChess.Minions.Normal
{
    class BZMDJS : MainMinion
    {
        public BZMDJS() : this(false) { }
        public BZMDJS(bool isgold)
            : base(isgold)
        {
            if (isgold)
            {
                Attack = 4;
                Hp = 6;
            }
            else 
            {
                Attack = 2;
                Hp = 3;
            }
        }
        public override string Name => "被折磨的祭司";

        public override int Start => 2;

        public override int Fee => 2;

        public override MRace Race => MRace.None;

        public override bool Taunt { get; set; } = true;

        protected internal override void BeforeGotAttack(MainMinion minion)
        {
            var b = this.Companions.GetByIndex(this.Index - 1);
            if (b != null)
            {
                b.Attack++;
                b.Hp++;
            }
            var a = this.Companions.GetByIndex(this.Index + 1);
            if (a != null)
            {
                a.Attack++;
                a.Hp++;
            }
        }
    }
}
