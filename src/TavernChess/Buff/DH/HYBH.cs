using System;
using System.Collections.Generic;
using System.Text;
using TavernChess.Minions;

namespace TavernChess.Buff.DH
{
    public class HYBH : Deathrattle
    {
        internal override string Name => "红衣庇护";

        internal override void Run(MainMinion mainMinion)
        {
            foreach (var m in mainMinion.Companions.AliveList)
            {
                if (m.Race.Is(MRace.Dragon))
                {
                    m.SetDivienShield(true);
                }
            }
        }
    }
}
