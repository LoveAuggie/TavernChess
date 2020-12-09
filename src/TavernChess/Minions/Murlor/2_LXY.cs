using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TavernChess.Minions.Murlor
{
    public class LXY : MainMinion
    {
        public LXY() : this(false) { }
        public LXY(bool isgold)
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

        public override string Name => "老瞎眼";

        public override int Start => 2;

        public override int Fee => 4;

        public override MRace Race => MRace.Murlor;

        protected internal override int GuangHuanAttack(MainMinion minion)
        {
            // 认为是只对自己生效的光环
            if (minion == this)
            {
                int sum = -1; // 由于会包含自己，所以先-1
                sum += this.Enemies.AliveList.Where(t => t.Race.Is(MRace.Murlor)).Count();
                sum += this.Companions.AliveList.Where(t => t.Race.Is(MRace.Murlor)).Count();
                return sum;
            }
            return 0;
        }
    }
}
