using System;
using System.Collections.Generic;
using System.Text;

namespace TavernChess.Minions.Normal
{
    public class KDJ : MainMinion
    {
        private int rCount;
        private string thisGuid;

        private string thisKey => $"kdj_{thisGuid}";

        public KDJ() : this(false) { }
        public KDJ(bool isgold)
            :base(isgold)
        {
            if (isgold)
            {
                Attack = Hp = 4;
                rCount = 2;
            }
            else
            {
                Attack = Hp = 2;
                rCount = 1;
            }
            thisGuid = Guid.NewGuid().ToString();
        }

        public override string Name => "卡德加";

        public override int Start => 3;

        public override int Fee => 2;

        public override MRace Race => MRace.None;

        internal void BeforeInsert2(List<MainMinion> list)
        {
            var nList = new List<MainMinion>();

            foreach (var minion in nList)
            {
                if (minion.properties.ContainsKey(this.thisKey))
                    break;

                nList.Add(minion);
                var nm = minion.MClone();
                nm.properties.Add(this.thisKey, true);
                nList.Add(nm);
            }
            list = nList;
        }

        internal override void AfterInsert(MainMinion minion)
        {
            if (minion.properties.ContainsKey(this.thisKey))
                return;

            var cm = minion.MClone();
            cm.properties[this.thisKey] = true;
            if (IsGold)
            {
                var cm2 = minion.MClone();
                cm.properties[this.thisKey] = true;
                minion.Companions.CallAddMinion(minion, 0, cm2);
            }
            minion.Companions.CallAddMinion(minion, 0, cm);
        }
    }
}
