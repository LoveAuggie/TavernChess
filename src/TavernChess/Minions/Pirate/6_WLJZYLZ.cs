using System;
using System.Collections.Generic;
using System.Text;

namespace TavernChess.Minions.Pirate
{
    public class WLJZYLZ : MainMinion
    {
        private int rCount = 1;
        public WLJZYLZ() : this(false) { }
        public WLJZYLZ(bool isgold)
            : base(isgold)
        {
            if (isgold)
            {
                Attack = 12;
                Hp = 14;
                rCount = 2;
            }
            else
            {
                Attack = 6;
                Hp = 7;
                rCount = 1;
            }
        }

        public override string Name => "亡灵舰长伊利扎";

        public override int Start => 6;

        public override int Fee => 6;

        public override MRace Race => MRace.Pirate;

        protected internal override void BeforCallDoAttack(MainMinion minion)
        {
            if (minion.Race.Is(MRace.Pirate))
            {
                for (int i = 0; i < minion.Companions.AliveList.Count; i++)
                {
                    var m = minion.Companions.AliveList[i];
                    m._attack += (2 * rCount);
                    m._hp += rCount;
                }
            }
        }
    }
}
