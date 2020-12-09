using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TavernChess.Minions.Dragon
{
    public class HYCLG : MainMinion
    {
        private int rCount;
        public HYCLG() : this(false) { }

        public HYCLG(bool isgold)
            : base(isgold)
        {
            if (isgold)
            {
                Attack = 10;
                Hp = 12;
                rCount = 6;
            }
            else
            {
                Attack = 5;
                Hp = 6;
                rCount = 3;
            }
        }

        public override string Name => "火焰传令官";

        public override int Start => 4;

        public override int Fee => 5;

        public override MRace Race => MRace.Dragon;

        protected internal override void AfterAttck(int damage, MainMinion target)
        {
            if (damage <= target.Hp) return;

            var list = new List<MainMinion>();
            var TestList = target.Companions.AliveList;
            TestList.Remove(target);

            list.Add(TestList[0]);
            for (int i = 0; i < TestList.Count -1; i++)
            {
                if (TestList[i].Hp < rCount)
                {
                    list.Add(TestList[i + 1]);
                }
            }

            foreach (var a in list)
            {
                a.GetHurt(rCount);
            }
        }
    }
}
