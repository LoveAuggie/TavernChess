using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TavernChess.Minions.Dragon
{
    public class HSCL : MainMinion
    {
        public HSCL() : this(false) { }

        public HSCL(bool isgold) :
            base(isgold)
        {
            if (isgold)
            {
                Attack = 2;
                Hp = 4;
            }
            else
            {
                Attack = 1;
                Hp = 2;
            }
        }

        public override string Name => "红色雏龙";

        public override int Start => 1;

        public override int Fee => 1;

        public override MRace Race => MRace.Dragon;

        protected override void StartGame()
        {
            var dCount = this.Companions.minions.Count(t => t.Race.Is(MRace.Dragon));

            var target = this.Enemies.minions.RandomGet();
            target.GetHurt(dCount);

            if (this.IsGold)
            {
                target = this.Enemies.minions.RandomGet();
                target.GetHurt(dCount);
            }
        }
    }
}
