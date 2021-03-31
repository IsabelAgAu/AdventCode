using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventCode
{
    class Day2Class
    {

        private const string inputDay2FilePath = @"..\..\..\inputDay2.txt";
        private const string blankSpliter = " ";
        private const string twoDotSpliter = ":";
        private const string spaceRegex = @"\s";

        public static void Day2Part1()
        {
            var lines = File.ReadAllLines(inputDay2FilePath);
            List<string> passwordList = lines.Select(line => line).ToList();


            int validPasswords = passwordList.Count(IsValidPassword);

            /*
            for (int i = 0; i< passwordList.Count; i++) {
                auxSplit = passwordList[i].Split(":");
                password = auxSplit[1];
                auxSplit = auxSplit[0].Split(" ");
                letter = auxSplit[1];
                rule = auxSplit[0];

                password = Regex.Replace(password, @"\s+", "");
                if (IsPasswordValidPart2(letter, password, rule))
                {
                    //Console.WriteLine($"Valid password: {password} with rule {rule} and letter {letter}");
                    validPasswords++;
                }
            }*/

            Console.WriteLine($"There are {validPasswords} valid passwords");
        }

        private static bool IsValidPassword(string line)
        {
                string rule;
                string letter;
                string password;
                string[] auxSplit;

                auxSplit = line.Split(twoDotSpliter);
                password = auxSplit[1];
                auxSplit = auxSplit[0].Split(blankSpliter);
                letter = auxSplit[1];
                rule = auxSplit[0];

                password = Regex.Replace(password, spaceRegex, string.Empty);

                //return IsPasswordValid(letter, password, rule);
                return CheckPasswordPart2(letter, password, rule);
            
        }

        private static bool CheckPassword(string letter, string password, string interval)
        {
            int count = password.Count(x => x.ToString().Equals(letter));

            string[] limit = interval.Split("-");

            if (limit.Count() != 2) return false;

            if (count >= int.Parse(limit[0]) && count <= int.Parse(limit[1]))
                return true;

            return false;
        }

        private static bool CheckPasswordPart2(string letter, string password, string interval) 
        {
            string[] limit = interval.Split("-");
            
            if (
                (password[int.Parse(limit[0]) - 1].Equals(char.Parse(letter)) 
                && !password[int.Parse(limit[1]) - 1].Equals(char.Parse(letter))) ||
                (!password[int.Parse(limit[0]) - 1].Equals(char.Parse(letter)) 
                && password[int.Parse(limit[1]) - 1].Equals(char.Parse(letter))))
            {
                return true;
            }
            return false;
        }
    }
}
