using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventCode
{
    class Program
    {


        private const string inputDay1FilePath = @"..\..\..\inputDay1.txt";

        /*
         Given a list of numbers, find the two that sum 2020
         */
        public static void Day1()
        {

            List<int> numbers = new List<int> { };

            foreach (string line in File.ReadAllLines(inputDay1FilePath))
            {
                numbers.Add(Int32.Parse(line));
            }

            // Which two numbers sum 2020

            for (int i = 0; i < numbers.Count; i++)
            {
                for (int j = i + 1; j < numbers.Count; j++)
                {
                    if (numbers[i] + numbers[j] == 2020)
                        Console.WriteLine("The numbers " + numbers[i] + " and " + numbers[j] + " sum 2020 \n");
                }
            }

        }

        public static List<int> FindNumbersThatSumValue(int sumValue)
        {
            //Function Names
            //Constants
            //String interpolation
            //LINQ

            var lines = File.ReadAllLines(inputDay1FilePath);
            List<int> numbers = lines.Select(line => int.Parse(line))
                                     .ToList();

            var numbersWithComplementary = numbers.Where(ComplementaryExist(sumValue, numbers))
                                                  .ToList();

            RemoveComplementaries(sumValue, numbersWithComplementary);
            return numbersWithComplementary;
        }

        private static void ExecuteDay1()
        {
            var total = 2020;
            var numbers = FindNumbersThatSumValue(total);
            numbers.ForEach(number => Console.WriteLine($"The numbers {number} and {GetComplementary(number, total)} sum {total}"));
        }

        private static void RemoveComplementaries(int sumValue, List<int> numbersWithComplementary)
        {
            for (var i = 0; i < numbersWithComplementary.Count(); i++)
            {
                var number = numbersWithComplementary[i];
                var complementary = GetComplementary(number, sumValue);
                numbersWithComplementary.Remove(complementary);
            }
        }

        private static Func<int, bool> ComplementaryExist(int sumValue, List<int> numbers)
        {
            return number => numbers.Exists(listNumber => listNumber == sumValue - number);
        }

        public static int GetComplementary(int number, int total)
        {
            return total - number;
        }

        static void Main(string[] args)
        {

            Day1();
            ExecuteDay1();

        }
    }
}

