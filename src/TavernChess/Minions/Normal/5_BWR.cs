using System;
using System.Collections.Generic;
using System.Text;

namespace TavernChess.Minions.Normal
{
    public class BWR : MainMinion
    {
        private int rCount;
        public BWR() : this(false) { }
        public BWR(bool isgold)
            :base(isgold)
        {
            if (isgold)
            {
                Attack = 2;
                Hp = 14;
                rCount = 4;
            }
            else 
            {
                Attack = 1;
                Hp = 4;
                rCount = 2;
            }
        }

        public override string Name => "浴火者伯瓦尔";

        public override int Start => 5;

        public override int Fee => 6;

        public override bool Legenda => true;

        public override MRace Race => MRace.None;

        public override bool DivienShield { get; set; } = true;

        internal override void DivienShieldChange(bool value, MainMinion minion)
        {
            this._attack += rCount;
        }
    }
}
