using System;
using System.Collections.Generic;
using System.Text;

namespace TavernChess.Minions.Pirate
{
    public class NHCZ : MainMinion
    {
        public NHCZ() : this(false)
        { }

        public NHCZ(bool isgold)
            : base(isgold)
        {
            if (isgold)
                Attack = Hp = 6;
            else
                Attack = Hp = 3;
        }
        public override string Name => "南海船长";

        public override int Start => 2;

        public override int Fee => 3;

        public override MRace Race => MRace.Pirate;

        protected internal override int GuangHuanAttack(MainMinion minion)
        {
            if (minion == this) return 0;
            if (!minion.Race.Is(MRace.Pirate)) return 0;
            return IsGold ? 2 : 1;
        }

        protected internal override int GuangHuanHp(MainMinion minion)
        {
            if (minion == this) return 0;
            if (!minion.Race.Is(MRace.Pirate)) return 0;
            return IsGold ? 2 : 1;
        }
    }
}
