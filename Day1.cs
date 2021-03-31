using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventCode
{
    public class Day1Class
    {
        private const string inputDay1FilePath = @"..\..\..\inputDay1.txt";

        public static void Day1Part1(int total)
        {

            var lines = File.ReadAllLines(inputDay1FilePath);
            List<int> numbers = lines.Select(line => int.Parse(line))
                                     .ToList();

            // Which two numbers sum 2020

            for (int i = 0; i < numbers.Count; i++)
            {
                for (int j = i + 1; j < numbers.Count; j++)
                {
                    if (numbers[i] + numbers[j] == total)
                    {
                        Console.WriteLine($"The numbers {numbers[i]} and {numbers[j]} sum {total}");
                        Console.WriteLine($"The key result is {numbers[i] * numbers[j]}");
                    }
                }
            }

        }

        public static void Day1Part2(int total)
        {

            var lines = File.ReadAllLines(inputDay1FilePath);
            List<int> numbers = lines.Select(line => int.Parse(line))
                                     .ToList();

            // Which three numbers sum 2020

            for (int i = 0; i < numbers.Count; i++)
            {
                for (int j = i + 1; j < numbers.Count; j++)
                {
                    for (int k = j + 1; k < numbers.Count; k++)
                    {
                        if (numbers[i] + numbers[j] + numbers[k] == total)
                        {
                            Console.WriteLine($"The numbers {numbers[i]}, {numbers[j]} and {numbers[k]} sum {total}");
                            Console.WriteLine($"The key result is {numbers[i] * numbers[j] * numbers[k]}");
                        }
                    }
                }
            }

        }

        public static void ExecuteDay1(int total)
        {
            var numbers = FindNumbersThatSumValue(total);
            numbers.ForEach(number => Console.WriteLine($"The numbers {number} and {GetComplementary(number, total)} sum {total}"));
        }
        private static List<int> FindNumbersThatSumValue(int sumValue)
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


    }
}