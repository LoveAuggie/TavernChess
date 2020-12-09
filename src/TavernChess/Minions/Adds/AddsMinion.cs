using System;
using System.Collections.Generic;
using System.Text;

namespace TavernChess.Minions.Adds
{
    /// <summary>
    /// 衍生物的基类
    /// </summary>
    public class AddsMinion :  MainMinion
    {

        private string _name;
        private MRace _race;
        public AddsMinion(string name, int attack, int hp, bool isgold, MRace race)
            :base(isgold)
        {
            _name = name;
            _race = race;
            this.Attack = attack;
            this.Hp = hp;
        }

        public override string Name => _name;

        public override int Start => 1;

        public override int Fee => 1;

        public override MRace Race => _race;

        public Action InsertAct { get; internal set; }

        public string InsertMethod { get; internal set; }

        internal void AfterAdd()
        {
            if (InsertAct != null)
                InsertAct.Invoke();

            if (!string.IsNullOrEmpty(InsertMethod))
            {
                var m = this.GetType().GetMethod(InsertMethod);
                if (m != null)
                {
                    m.Invoke(this, null);
                }
            }
        }
    }
}
