using System;

namespace StringChapter
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Harry Potter";

            // 1. 찾기
            // (1) Contains = 포함되었는지 bool 값 반환
            var found = name.Contains("Harry");
            Console.WriteLine(found);

            // (2) IndexOf
            // 해당 문자가 몇번째 인덱스에 위치했는지 반환을 한다.
            // 해당 문자가 존재하지 않으면 -1 반환
            int index = name.IndexOf('P');
            Console.WriteLine(index);

            // 2. 변형
            // (1) 뒤에 string 덧붙임
            name = name + " Junior";
            Console.WriteLine(name);

            // (2) 대문자 / 소문자로 전체 변형
            var lowerName = name.ToLower();
            var upperName = name.ToUpper();

            Console.WriteLine(lowerName);
            Console.WriteLine(upperName);

            // (3) 문자 변형
            string newName = name.Replace('r', 'l');
            Console.WriteLine(newName);

            // (4) 분할
            // Split : ' ' 구간을 경계로 문자열을 배열로 나눈다.
            string[] splitName = name.Split(new char[] {' '});
            Console.WriteLine(splitName[0]);
            Console.WriteLine(splitName[1]);

            // Substring : 인덱스 정보를 받아서, 해당 인덱스에서부터 끝까지 잘라서 따로 저장한다.
            string subStringName = name.Substring(6);
            Console.WriteLine(subStringName);
        }
    }
}
