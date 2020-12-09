using System;
using System.Collections.Generic;
using System.Text;
using TavernChess.Minions;
using TavernChess.Minions.Adds;
using TavernChess.Minions.Beast;

namespace TavernChess.Buff.DH
{
    public class WPJL : Deathrattle
    {
        private bool Gold;
        public WPJL(bool isGold)
        {
            Gold = isGold;
        }

        internal override string Name => "外婆降临";

        internal override void Run(MainMinion mainMinion)
        {
            if (Gold)
                mainMinion.Companions.CallAddMinion(mainMinion, 0, new AddsMinion("狼外婆", 6, 4, true, MRace.Beast));
            else
                mainMinion.Companions.CallAddMinion(mainMinion, 0, new AddsMinion("狼外婆", 3, 2, false, MRace.Beast));
        }
    }
}
