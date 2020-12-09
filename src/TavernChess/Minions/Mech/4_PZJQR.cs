using System;
using System.Collections.Generic;
using System.Text;

namespace TavernChess.Minions.Mech
{
    public class PZJQR : MainMinion
    {
        public PZJQR() : this(false) { }

        public PZJQR(bool isgold)
            : base(isgold)
        {
            if (isgold)
            {
                Attack = 6;
                Hp = 3;
            }
            else
            {
                Attack = 3;
                Hp = 1;
            }
        }

        public override string Name => "偏折机器人";

        public override int Start => 3;

        public override int Fee => 4;

        public override MRace Race => MRace.Mech;

        internal override void AfterInsert(MainMinion minion)
        {
            if (minion.Race.Is(MRace.Mech))
            {
                this._attack += 1;
                this.SetDivienShield(true);
            }
        }
    }
}
