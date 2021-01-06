using System;
using System.Collections.Generic;
using System.Text;

namespace TavernChess.Minions.Normal
{
    public class RWDRNJ : MainMinion
    {
        public RWDRNJ() : this(false) { }
        public RWDRNJ(bool isgold)
            : base(isgold)
        {
            if (isgold)
            {
                Attack = 2;
                Hp = 14;
            }
            else
            {
                Attack = 1;
                Hp = 7;
            }
        }

        public override string Name => "瑞文戴尔男爵";

        public override int Start => 5;

        public override int Fee => 5;

        public override bool Legenda => true;

        public override MRace Race => MRace.None;

        internal override void AfterCallDeath(MainMinion minion)
        {
            if (minion.deathList == null || minion.deathList.Count <= 0) return;

            if (IsGold)
            {
                if (!minion.properties.ContainsKey("rwdrnj_gold"))
                {
                    minion.properties["rwdrnj_gold"] = true;
                    minion.CallDeath();
                    minion.CallDeath();
                }
            }
            else
            {
                if (!minion.properties.ContainsKey("rwdrnj"))
                {
                    minion.properties["rwdrnj"] = true;
                    minion.CallDeath();
                }
            }
        }
    }
}
