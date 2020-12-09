using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TavernChess.Minions;

namespace TavernChess
{
    public class MininoFactory
    {
        static List<MainMinion> minions = new List<MainMinion>();
        public static void Init()
        {
            var ams = System.AppDomain.CurrentDomain.GetAssemblies();
            var baseType = typeof(MainMinion);
            foreach (var asm in ams)
            {
                var ts = asm.GetTypes();
                foreach (var t in ts)
                {
                    if(baseType.IsAssignableFrom(t) && !t.IsAbstract && t.Name!="AddsMinion")
                    {
                        Console.WriteLine(t.Name);
                        minions.Add(Activator.CreateInstance(t) as MainMinion);
                    }
                }
            }
        }

        public static MainMinion CreateMinionWithDeath()
        {
            return minions.Where(t => t.isDeathMinion).RandomGet();
        }

        public static MainMinion GetMinionWithLengda()
        {
            return minions.Where(t => t.Legenda).RandomGet();
        }

        public static MainMinion CreateMinionByRace(MRace race)
        {
            return minions.Where(t => t.Race.Is(race)).RandomGet();
        }

        public static MainMinion CreateMinionByFee(int fee)
        {
            return minions.Where(t => t.Fee == fee).RandomGet();
        }
    }

    public static class ListRand
    {
        public static T RandomGet<T>(this IEnumerable<T> ilist)
        {
            var list = ilist.ToList();
            var rand = new Random(Guid.NewGuid().GetHashCode());
            return list[rand.Next(list.Count)];
        }
    }
}
