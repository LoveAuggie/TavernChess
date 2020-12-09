using System;
using System.Collections.Generic;
using TavernChess.Minions;
using TavernChess.Minions.Beast;
using TavernChess.Minions.Normal;
using TavernChess.Minions.Pirate;

namespace TavernChess
{
    class Program
    {
        static void Main(string[] args)
        {
            MininoFactory.Init();
            var d = MininoFactory.CreateMinionWithDeath();

            Simulate();

            Console.ReadKey();
        }

        static void Simulate()
        {
            var m1 = new ListMinion()
            {
                Name = "D1",
                minions = new List<MainMinion>()
                {
                    new KDJ(){ Attack = 2, Hp =2},
                    new WYSQ (){ Attack=3, Hp =3, Taunt =true },
                    new XMM(){ Attack = 1, Hp =7},
                }
            };

            var m2 = new ListMinion()
            {
                Name = "D2",
                minions = new List<MainMinion>()
                {
                    new PLJR(){ Attack = 6, Hp = 7},
                    new KDJ(){ Attack = 1, Hp =20},
                    new WLJZYLZ{ Attack = 10, Hp = 10,Taunt = true}
                }
            };

            Fight(m1, m2);
        }

        static void Fight(ListMinion m1, ListMinion m2) 
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            var i = rand.Next(0, 10000) % 2;
            List<ListMinion> rList = new List<ListMinion>() { m1, m2 };

            i = 1;

            m1.Enemies = m2;
            m2.Enemies = m1;
            foreach (var m in m1.minions)
            {
                m.Companions = m1;
            }
            foreach (var m in m2.minions)
            {
                m.Companions = m2;
            }

            var cur = rList[i];
            cur.StartFight();
            i = GetNext(i);

            cur = rList[i];
            cur.StartFight();
            i = GetNext(i);

            while (true)
            {
                cur = rList[i];
                if (!cur.Attack())
                {
                    break;
                }
                i = GetNext(i);
            }
            i = GetNext(i);
            var win = rList[i];
            if (win.minions.Count > 0)
            {
                Console.WriteLine($"[{win.Name}] WIN!!!");
            }
            else
            {
                Console.WriteLine($"[{win.Name}] DROP!!!");
            }
        }

        static int GetNext(int index)
        {
            return index == 0 ? 1 : 0;
        }
    }
}
