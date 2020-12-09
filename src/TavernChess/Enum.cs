using System;
using System.Collections.Generic;
using System.Text;

namespace TavernChess
{
    public enum MRace
    {
        None,
        Dragon, // 龙
        Beast,  // 野兽
        Demon,  // 恶魔
        Elamental, // 元素
        Murlor, // 鱼人
        Mech,   // 机械
        Pirate, // 海盗
        All
    }

    public static class RaceExtend
    {
        public static bool Is(this MRace race, MRace com)
        {
            return race == MRace.All || race == com;
        }
    }
}
