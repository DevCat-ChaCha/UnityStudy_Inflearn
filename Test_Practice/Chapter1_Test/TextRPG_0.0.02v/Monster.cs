using System;
using System.Collections.Generic;
using System.Text;

namespace TextRPG_0._0._02v
{
    public enum MONSTERTYPE
    {
        NONE,
        SLIME,
        ORC,
        SKELETON,
    }

    class Monster : Creature
    {
        protected MONSTERTYPE monsterType = MONSTERTYPE.NONE;

        protected Monster(MONSTERTYPE monsterType) :base(CREATURE_TYPE.MONSTER)
        {
            this.monsterType = monsterType;
        }

        public MONSTERTYPE GetMonsterType() { return this.monsterType; }

        class Slime : Monster
        {
            public Slime() : base(MONSTERTYPE.SLIME)
            {
                SetInfo(10, 10);
            }
        }
        class Orc : Monster
        {
            public Orc() : base(MONSTERTYPE.ORC)
            {
                SetInfo(20, 25);
            }
        }
        class Skeleton : Monster
        {
            public Skeleton() : base(MONSTERTYPE.SKELETON)
            {
                SetInfo(15, 35);
            }
        }
    }
}
