using System;
using System.Collections.Generic;
using System.Linq;

namespace TextRPG
{
    class TextRPG_Game
    {
        // 캐릭터에 대한 정보는 static 전역 변수로 관리 하여 접근이 용이하도록 하나, 불필요한 접근 및 수정을 최대한 배재 해야 할 것.
        static CharacterData charData = new CharacterData();

        public enum CLASSTYPE
        {
            NONE = 0,
            KNIGHT = 1,
            MAGE = 2,
            ARROW = 3,
        }

        public enum MONSTERTYPE
        {
            OAK = 0,
            SKELETON = 1,
            GHOST = 2,
            BOSS = 3,
        }

        public struct CharacterData
        {
            public string charNickName;
            public CLASSTYPE classType;
            public int character_Level;
            public int character_Hp;
            public int character_AttackPower;
            public double character_Speed;
        };

        public struct MonsterData
        {
            public MONSTERTYPE monsterType;
            public string monsterNickName;
            public int monster_Hp;
            public int monster_AttackPower;
        }

        struct UserData
        {
            int UserId;
            string UserName;
            CharacterData[] charList;
        };

        static void Main(string[] args)
        {
            charData.classType = CLASSTYPE.NONE;

            // 밸런스는?
            // 기사 (100 / 13) & 법사 ( 75 / 15 ) & 궁수 ( 90 / 11 ) 

            // 1. 직업을 선택한다.
            while (/*charData.classType == CLASSTYPE.NONE*/true)
            {
                Console.WriteLine(" 직업을 골라주세요. ");
                Console.WriteLine(" (1) 기사  || (2) 법사  || (3) 궁사  ");

                // 클래스 타입이 NONE 이 아닐 때까지 계속 값을 받아온다. 
                string classtype = Console.ReadLine();
                int classNum = 0;
                int.TryParse(classtype, out classNum);
                charData.classType = SetClassType(classNum);

                // 2. 캐릭터의 특성 맞춰주기
                CreatePlayer(charData.classType, ref charData);

                // 3. 게임 시작
                EnterGame();
            }
        }

        static CLASSTYPE SetClassType(int classtype)
        {
            CLASSTYPE classType = CLASSTYPE.NONE;

            switch (classtype)
            {
                case 1:
                    classType = CLASSTYPE.KNIGHT;
                    Console.WriteLine(" 기사를 선택하셨습니다. ");
                    break;
                case 2:
                    classType = CLASSTYPE.MAGE;
                    Console.WriteLine(" 법사를 선택하셨습니다. ");
                    break;
                case 3:
                    classType = CLASSTYPE.ARROW;
                    Console.WriteLine(" 궁사를 선택하셨습니다. ");
                    break;
            }
            return classType;
        }

        static public void CreatePlayer(CLASSTYPE classtype, ref CharacterData data)
        {
           
            switch (classtype)
            {
                case CLASSTYPE.KNIGHT:
                    {
                        data.character_Hp = 100;
                        data.character_AttackPower = 13;
                        data.character_Speed = 1f;
                    }
                    break;
                case CLASSTYPE.MAGE:
                    {
                        data.character_Hp = 75;
                        data.character_AttackPower = 15;
                        data.character_Speed = 1.3f;
                    }
                    break;
                case CLASSTYPE.ARROW:
                    {
                        data.character_Hp = 90;
                        data.character_AttackPower = 11;
                        data.character_Speed = 0.8f;
                    }
                    break;
                default:
                    {
                        // out 초기화 값.
                        data.character_Hp = 0;
                        data.character_AttackPower = 0;
                        data.character_Speed = 1f;
                    }
                    break;
            }
            Console.WriteLine(" 현재 내 캐릭터의 Hp / Attack / AttackSpeed 수치 : " + data.character_Hp + " / " + data.character_AttackPower + " / " + data.character_Speed);
        }

        static void EnterGame()
        {
            while (true)
            {
                int value = 0;

                Console.WriteLine("마을에 접속했습니다.");
                Console.WriteLine("[1] 필드로 간다 | [2] 로비로 돌아가기");

                var readData = Console.ReadLine();
                int.TryParse(readData, out value);

                switch(value)
                {
                    case 1:
                        {
                            EnterField();
                        }
                        break;
                    case 2:
                        {
                            Console.WriteLine("로비로 돌아갑니다");
                        }
                        return;
                    default:
                        {
                            Console.WriteLine("잘못된 값이 입력되었습니다.");
                        }
                        break;
                }

            }
        }

        static void EnterField()
        {
            Console.WriteLine("필드에 접속했습니다");

            // 플레이어의 hp 가 0 이하일 때는 필드에 접속 불가
            if(charData.character_Hp <= 0)
            {
                Console.WriteLine("플레이어의 남은 hp 를 확인하세요!");
                Console.WriteLine("마을로 다시 돌아갑니다...");

                return;
            }

            // 랜덤으로 1-3 개의 몬스터중 하나를 랜덤으로 생성
            // 1. 몬스터 생성
            MonsterData monster = new MonsterData();
            CreateRandomMonster(ref monster);
            
            // 1) 전투 모드로 돌입
            // 2) 일정 확률로 마을로 도망
            Console.WriteLine("[1] 전투 모드로 돌입 ! | [2] 일정 확률로 마을로 도망..");
            var input = Console.ReadLine();
            int value = 0;
            int.TryParse(input, out value);

            switch (value)
            {
                // 전투 모드로 돌입
                case 1:
                    {
                        Fight(ref charData, ref monster);
                    }
                    break;
                // 일정 확률로 마을로 도망
                case 2:
                    {
                        int randomValue = 33;

                        Random rand = new Random();
                        if(rand.Next(0, 101) <= randomValue)
                        {
                            Console.WriteLine("다행히.. 마을로 도망칠 수 있었습니다. 휴..");
                            return;
                        }
                        else
                        {
                            Console.WriteLine("싸움을 피할 수가 없었습니다..");
                            Fight(ref charData, ref monster);
                        }
                    }
                    break;
            }
        }

        static void Fight(ref CharacterData player, ref MonsterData monster)
        {
            Console.WriteLine("전투 시작!!");
            var timer = DateTime.Now.AddSeconds(player.character_Speed);

            while (true)
            {
                if (timer <= DateTime.Now)
                {
                    // 플레이어 선빵
                    monster.monster_Hp -= player.character_AttackPower;
                    if (monster.monster_Hp <= 0)
                        monster.monster_Hp = 0;
                    
                    Console.WriteLine("플레이어의 공격! 몬스터의 체력은 " + monster.monster_Hp + "이(가) 되었다!");
                    if (monster.monster_Hp <= 0)
                    {
                        Console.WriteLine("몬스터를 이겼다! 야호!");
                        break;
                    }

                    // 몬스터 공격 차례
                    player.character_Hp -= monster.monster_AttackPower;
                    if (player.character_Hp <= 0)
                        player.character_Hp = 0;

                    Console.WriteLine("몬스터의 공격! 플레이어의 체력은 " + player.character_Hp + "이(가) 되었다!");
                    if (player.character_Hp <= 0)
                    {
                        Console.WriteLine("몬스터에게 졌다.. 플레이어 사망!");
                        break;
                    }

                    // Timer 초기화
                    timer = DateTime.Now.AddSeconds(player.character_Speed);
                }
            }
        }

        static void CreateRandomMonster(ref MonsterData data)
        {
            Random rand = new Random();

            int randMonster = rand.Next(1, 5);
            switch(randMonster)
            {
                case 1:
                    {
                        Console.WriteLine(" 오크 타입의 몬스터가 출현했습니다. ");
                        data.monsterNickName = "OAK";
                        data.monster_AttackPower = 10;
                        data.monster_Hp = 30;
                        data.monsterType = MONSTERTYPE.OAK;
                    }
                    break;
                case 2:
                    {
                        Console.WriteLine(" 스켈레톤 타입의 몬스터가 출현했습니다. ");
                        data.monsterNickName = "SKELETON";
                        data.monster_AttackPower = 8;
                        data.monster_Hp = 40;
                        data.monsterType = MONSTERTYPE.SKELETON;
                    }
                    break;
                case 3:
                    {
                        Console.WriteLine(" 고스트 타입의 몬스터가 출현했습니다. ");
                        data.monsterNickName = "GHOST";
                        data.monster_AttackPower = 12;
                        data.monster_Hp = 33;
                        data.monsterType = MONSTERTYPE.GHOST;
                    }
                    break;
                case 4:
                    {
                        Console.WriteLine(" 보스 타입의 몬스터가 출현했습니다. ");
                        data.monsterNickName = "BOSS";
                        data.monster_AttackPower = 10;
                        data.monster_Hp = 50;
                        data.monsterType = MONSTERTYPE.BOSS;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
