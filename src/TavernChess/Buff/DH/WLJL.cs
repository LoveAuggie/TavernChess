using System;
using System.Collections.Generic;
using System.Text;
using TavernChess.Minions;
using TavernChess.Minions.Adds;

namespace TavernChess.Buff.DH
{
    public class WLJL : Deathrattle
    {
        internal override string Name => "无赖降临";

        private bool isGold;
        public WLJL(bool isgold)
        {
            isGold = isgold;
        }

        internal override void Run(MainMinion mainMinion)
        {
            var count = isGold ? 2 : 1;
            var wl = new AddsMinion("无赖", count, count, isGold, MRace.Pirate);
            wl.InsertMethod = "StartAttack";
            wl.Enemies = mainMinion.Enemies;
            wl.Companions = mainMinion.Companions;
            mainMinion.Companions.CallAddMinion(mainMinion, 0, wl);
        }
    }
}
