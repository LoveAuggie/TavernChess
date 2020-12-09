using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TavernChess.Minions;

namespace TavernChess.Buff
{
    public class JLBH : Deathrattle
    {
        internal override string Name => "巨狼庇护";

        private int Count;
        public JLBH(bool gold)
        {
            Count = gold ? 10 : 5;
        }

        internal override void Run(MainMinion mainMinion)
        {
            var beats = mainMinion.Companions.AliveList.Where(t => t.Race.Is(MRace.Beast)).ToList();
            foreach (var m in beats)
            {
                m._attack += Count;
                m._hp += Count;
            }
        }
    }
}
