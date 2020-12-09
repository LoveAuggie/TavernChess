using System;
using System.Collections.Generic;
using System.Text;

namespace TavernChess.Minions.Murlor
{
    public class YRLJ : MainMinion
    {
        public YRLJ() : this(false) { }
        public YRLJ(bool isgold)
            : base(isgold)
        {
            if (isgold)
                Attack = Hp = 6;
            else
                Attack = Hp = 3;
        }

        public override string Name => "鱼人领军";

        public override int Start => 2;

        public override int Fee => 3;

        public override MRace Race => MRace.Murlor;

        protected internal override int GuangHuanAttack(MainMinion minion)
        {
            if (minion.Race.Is(MRace.Murlor))
                return 2;
            return base.GuangHuanAttack(minion);
        }
    }
}
