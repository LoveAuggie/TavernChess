using System;
using System.Collections.Generic;
using System.Text;
using TavernChess.Minions;

namespace TavernChess.Buff
{
    public abstract class Deathrattle
    {
        internal abstract string Name { get; }

        internal void LogRun(MainMinion mainMinion)
        {
            Console.WriteLine($"      => [{mainMinion.Companions.Name}][{mainMinion.Companions.Name}] Death =>{this.Name}");
            Run(mainMinion);
        }

        internal abstract void Run(MainMinion mainMinion);
    }
}
