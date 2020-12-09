using System;
using System.Collections.Generic;
using System.Text;

namespace TavernChess.Minions.Normal
{
    public class LHZSZ : MainMinion
    {
        public LHZSZ() : this(false) { }
        public LHZSZ(bool isgold) 
            :base(isgold)
        {
            if (isgold)
                Attack = Hp = 6;
            else
                Attack = Hp = 3;
        }

        public override string Name => "灵魂杂耍者";

        public override int Start => 3;

        public override int Fee => 3;

        public override MRace Race => MRace.None;

        internal override void AfterDie(MainMinion minion)
        {
            if (minion.Race.Is(MRace.Demon))
            {
                // 先选择，后伤害，防止如亡语，召唤的效果
                var choose1 = this.Enemies.AliveList.RandomGet();
                if (IsGold)
                {
                    var choose2 = this.Enemies.AliveList.RandomGet();
                    choose2.GetHurt(3);
                }
                choose1.GetHurt(3);
            }
        }

        private void Shot()
        {
        }
    }
}
