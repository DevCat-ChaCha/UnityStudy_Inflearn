using System;
using System.Collections.Generic;
using System.Linq;

namespace TextRPG
{
    class TextRPG_Game
    {
        public enum CLASSTYPE
        {
            NONE = 0,
            KNIGHT = 1,
            MAGE = 2,
            ARROW = 3,
        }

        public struct CharacterData
        {
            public string charNickName;
            public CLASSTYPE classType;
            public int character_Level;
            public int character_Hp;
            public int character_AttackPower;
            public float character_Speed;
        };

        struct UserData
        {
            int UserId;
            string UserName;
            CharacterData[] charList;
        };

        static void Main(string[] args)
        {
            CharacterData charData = new CharacterData();
            charData.classType = CLASSTYPE.NONE;

            // 밸런스는?
            // 기사 (100 / 13) & 법사 ( 75 / 15 ) & 궁수 ( 90 / 11 ) 

            // 1. 직업을 선택한다.
           while (charData.classType == CLASSTYPE.NONE)
           {
                Console.WriteLine(" 직업을 골라주세요. ");
                Console.WriteLine(" (1) 기사  || (2) 법사  || (3) 궁사  ");

                // 클래스 타입이 NONE 이 아닐 때까지 계속 값을 받아온다. 
                string classtype = Console.ReadLine();
                int classNum = 0;
                int.TryParse(classtype, out classNum);
                charData.classType = SetClassType(classNum);
           }

           // 2. 캐릭터의 특성 맞춰주기
            CreatePlayer(charData.classType, out charData.character_Hp, out charData.character_AttackPower);
        }

        static public void SetUserData()
        {

        }

        static CLASSTYPE SetClassType(int classtype)
        {
            CLASSTYPE classType = CLASSTYPE.NONE;

            switch(classtype)
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

        static public void CreatePlayer(CLASSTYPE classtype, out int Hp, out int Attack)
        {
            switch(classtype)
            {
                case CLASSTYPE.KNIGHT:
                    {
                        Hp = 100;
                        Attack = 13;
                    }
                    break;
                case CLASSTYPE.MAGE:
                    {
                        Hp = 75;
                        Attack = 15;
                    }
                    break;
                case CLASSTYPE.ARROW:
                    {
                        Hp = 90;
                        Attack = 11;
                    }
                    break;
                default:
                    {
                        // out 초기화 값.
                        Hp = 0;
                        Attack = 0;
                    }
                    break;
            }

            Console.WriteLine(" 현재 내 캐릭터의 Hp / Attack 수치 : " + Hp + " / " + Attack);
        }
    }
}
