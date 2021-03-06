﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1_Test
{
    // 메소드 호출 (F11) => 영화 "Inception"
    // 현실 -> 1차 꿈 -> 2차 꿈 -> 3차 꿈 -> 깬다? -> 2차 꿈 -> 1차 꿈 -> 현실
    // Depth별로 나뉨
    
    // 호출 스택 = 지금까지 진행한 경로를 직접 볼 수 있게 함

    // 주요기능 1. 조건 걸기 2. 실행 순서 바꾸기

    class Program
    {
        public enum VALUE
        {
            GUGUDAN = 0,
            PRINT_STAR = 1,
            FACTORIAL = 2,

            EXIT = 10,
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Dictionary<int, string> dicActive = new Dictionary<int, string>
            {
                {0, "구구단 실행 !"},
                {1, "별 찍기 실행 !" },
                {2, "팩토리얼 실행 !" },
                {3, " 없음 ! " },

                {10, "프로그램 종료 !"},
            };
                string startInformation = "0) 구구단 실행 || 1) 별 찍기 실행 || 2) 팩토리얼 실행 || 10) 프로그램 종료!";
                Console.WriteLine(startInformation);

                var search = Console.ReadLine();
                int value;
                int.TryParse(search, out value);

                SetActive(value);
            }
            //Chapter1_Test.Program.GuGudan(9);
        }

        static void SetActive(int value)
        {
            switch((VALUE)value)
            {
                case VALUE.GUGUDAN:
                    Chapter1_Test.Program.GuGudan();
                    break;
                case VALUE.PRINT_STAR:
                    Chapter1_Test.Program.PrintStars();
                    break;
                case VALUE.FACTORIAL:
                    Chapter1_Test.Program.Factorial_Simple();
                    break;

                case VALUE.EXIT:
                    {
                        
                    }
                    break;
            }

            Console.WriteLine("해당 프로그램 실행이 완료되었습니다.");
        }

        static void GuGudan()
        {
            Console.WriteLine("숫자를 입력하세요 !");
            var search = Console.ReadLine();
            int value;
            int.TryParse(search, out value);

            for(int i = 2; i <= value; ++i)
            {
                for(int j = 1; j <= value; ++j)
                {
                    Console.WriteLine($"{i} x {j} = {i*j}");
                }
                Console.WriteLine("\n");
            }
        }

        static void PrintStars()
        {
            Console.WriteLine("찍고자 하는 별 라인 수를 입력하세요 !");
            var value = Console.ReadLine();
            int stars;
            int.TryParse(value, out stars);

            for (int i=1; i<= stars; ++i)
            {
                string star = "";

                for (int j = 1; j<=i; ++j)
                {
                    star += "*";
                }
                Console.WriteLine(star);
            }
        }

        static void Factorial()
        {
            Console.WriteLine("계산하고자 하는 팩토리얼 넘버를 입력하세요 !");
            var value = Console.ReadLine();
            int factorial;
            int.TryParse(value, out factorial);

            int result = 1;

            for(int i=factorial; i>0; --i)
            {
                result *= i;
            }

            Console.WriteLine(result);
        }

        static int Function_Factorial(int n)
        {
            if (n <= 1)
                return 1;

            return n * Function_Factorial(n - 1);
        }

        static void Factorial_Simple()
        {
            Console.WriteLine("계산하고자 하는 팩토리얼 넘버를 입력하세요 !");
            var value = Console.ReadLine();
            int factorial;
            int.TryParse(value, out factorial);

            Console.WriteLine(Function_Factorial(factorial));
        }

    }
}
