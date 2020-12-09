using System;
using System.Collections.Generic;
using System.Text;
using TavernChess.Buff.DH;

namespace TavernChess.Minions.Beast
{
    public class YSJM : MainMinion
    {
        public YSJM() : this(false) { }
        public YSJM(bool isgold)
            : base(isgold)
        {
            if (isgold)
            {
                Attack = Hp = 14;
                this.deathList.Add(new JMJL(4));
            }
            else
            {
                Attack = Hp = 7;
                this.deathList.Add(new JMJL(2));
            }
        }

        public override string Name => "阴森巨蟒";

        public override int Start => 6;

        public override int Fee => 6;

        public override MRace Race => MRace.Beast;

        // 暂时这个字段，仅用于阴森巨蟒召唤其他亡语随从使用，所以将自己先排除掉
        public override bool isDeathMinion { get; set; } = false;
    }
}
