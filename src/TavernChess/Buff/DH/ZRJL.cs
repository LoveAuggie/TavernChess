using System;
using System.Collections.Generic;
using System.Text;
using TavernChess.Minions;
using TavernChess.Minions.Adds;

namespace TavernChess.Buff.DH
{
    public class ZRJL : Deathrattle
    {
        private bool Gold;
        public ZRJL(bool isGold)
        {
            Gold = isGold;
        }

        internal override string Name => "侏儒降临";

        internal override void Run(MainMinion mainMinion)
        {
            if (Gold)
                mainMinion.Enemies.CallAddMinion(mainMinion,-1, new AddsMinion("克-恩霍尔", 3, 3, true, MRace.Beast));
            else
                mainMinion.Enemies.CallAddMinion(mainMinion, -1, new AddsMinion("克-恩霍尔", 3, 3, false, MRace.Beast));
        }
    }
}
