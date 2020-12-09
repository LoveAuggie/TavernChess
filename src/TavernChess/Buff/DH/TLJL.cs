using System;
using System.Collections.Generic;
using System.Text;
using TavernChess.Minions;
using TavernChess.Minions.Adds;

namespace TavernChess.Buff.DH
{
    class TLJL : Deathrattle
    {
        internal override string Name => "土狼降临";

        private bool isGold;
        public TLJL(bool isgold)
        {
            isGold = isgold;
        }

        internal override void Run(MainMinion mainMinion)
        {
            if (isGold)
            {
                mainMinion.Companions.CallAddMinion(mainMinion, 0, new AddsMinion("土狼", 4, 4, true, MRace.Beast), new AddsMinion("土狼", 4, 4, true, MRace.Beast));
            }
            else
            {
                mainMinion.Companions.CallAddMinion(mainMinion, 0, new AddsMinion("土狼", 2, 2, false, MRace.Beast), new AddsMinion("土狼", 2, 2, true, MRace.Beast));
            }
        }
    }
}
