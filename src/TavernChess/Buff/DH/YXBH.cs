using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TavernChess.Minions;

namespace TavernChess.Buff.DH
{
    public class YXBH : Deathrattle
    {
        internal override string Name => "英雄庇护";

        private int rCount = 1;
        public YXBH(bool isgold)
        {
            rCount = isgold ? 2 : 1;
        }

        internal override void Run(MainMinion mainMinion)
        {
            var list = mainMinion.Companions.AliveList.Where(t => !t.DivienShield && !t.isDie && t.Hp > 0).ToList();
            for (int i = 0; i < rCount; i++)
            {
                if (list.Count <= 0) return;
                var m = list.RandomGet();
                m.SetDivienShield(true);
                list.Remove(m);
            }
        }
    }
}
