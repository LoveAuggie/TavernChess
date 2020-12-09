using System;
using System.Collections.Generic;
using System.Text;
using TavernChess.Minions;
using TavernChess.Minions.Adds;
using TavernChess.Minions.Beast;

namespace TavernChess.Buff.DH
{
    public class WYJL : Deathrattle
    {
        private bool isGold;
        public WYJL(bool isgold)
        {
            isGold = isgold;
        }

        internal override string Name => "瘟疫降临";

        internal override void Run(MainMinion mainMinion)
        {
            var count = mainMinion.Attack > 7 ? 7 : mainMinion.Attack;
            List<MainMinion> list = new List<MainMinion>();
            for (int i = 0; i < count; i++)
            {

                if (isGold)
                {
                    list.Add(new AddsMinion($"瘟疫鼠{i}", 2, 2, this.isGold, MRace.Beast));
                }
                else
                {
                    list.Add(new AddsMinion($"瘟疫鼠{i}", 1, 1, this.isGold, MRace.Beast));
                }
            }

            mainMinion.Companions.CallAddMinion(mainMinion, 0, list.ToArray());
        }
    }
}
