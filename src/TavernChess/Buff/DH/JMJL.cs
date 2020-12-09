using System;
using System.Collections.Generic;
using System.Text;
using TavernChess.Minions;

namespace TavernChess.Buff.DH
{
    public class JMJL : Deathrattle
    {
        private int rCount;
        public JMJL(int count) 
        {
            rCount = count;
        }

        internal override string Name => "巨蟒降临";

        internal override void Run(MainMinion mainMinion)
        {
            List<MainMinion> minions = new List<MainMinion>();
            for (int i = 0; i < rCount; i++)
            {
                var m = MininoFactory.CreateMinionWithDeath();
                minions.Add(m);
            }
            mainMinion.Companions.CallAddMinion(mainMinion, 0, minions.ToArray());
        }
    }
}
