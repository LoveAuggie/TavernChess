using System;
using System.Collections.Generic;
using System.Text;
using TavernChess.Minions;
using TavernChess.Minions.Adds;

namespace TavernChess.Buff.DH
{
    public class LZJL : Deathrattle
    {
        internal override string Name => "狼蛛降临";

        private bool isGold;
        public LZJL(bool isgold)
        {
            isGold = isgold;
        }

        internal override void Run(MainMinion mainMinion)
        {
            if (isGold)
            {
                mainMinion.Companions.CallAddMinion(mainMinion, 0, new AddsMinion("狼蛛", 2, 2, true, MRace.Beast), new AddsMinion("狼蛛", 2, 2, true, MRace.Beast));
            }
            else
            {
                mainMinion.Companions.CallAddMinion(mainMinion, 0, new AddsMinion("狼蛛", 1, 1, false, MRace.Beast), new AddsMinion("狼蛛", 1, 1, true, MRace.Beast));
            }
        }
    }
}
