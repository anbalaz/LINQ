using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace LINQ
{
    public class Practice
    {
        public static string Disemvowel(string input)
        {
            //string vowels = "euioayEUIOAY";
            //return new string(input.Where(n => !vowels.Contains(n)).ToArray());
            return new string(input.Where(n => !"EUIOAY".Contains(char.ToUpper(n))).ToArray());
        }

        public static string TwoToOne(string s1, string s2)
        {
            return new string(string.Concat(s1, s2).Distinct().OrderBy(n => n).ToArray());
        }

        public static List<int> RemoveMinimum(List<int> numbers)
        {
            //if (numbers.Any())
            //{
            //    numbers.Remove(numbers.Min());
            //}
            //return numbers;
            return numbers.Where((n, i) => i != numbers.IndexOf(numbers.Min())).ToList();
        }

        public static string CharacterError(string s)
        {
            string aToM = "abcdefghijklm";
            int i = s.Length;
            int e = s.Where(n => !aToM.Contains(n)).ToArray().Length;
            //return $"{e}/{i}";
            return $"{s.Count(c => c > 'm')}/{s.Length}";
        }

        public static int[] ArrayDiff(int[] a, int[] b)
        {

            return a.Where(n => !b.Contains(n)).ToArray();
        }

        public static bool IsIsogram(string str)
        {
            {                                    //Suppose "anik a" is a given string
                return str.Where(char.IsLetter) //filter only the letters ||here- only a, n, i, k, a will be taken 
                          .GroupBy(char.ToLower) //create group by characters(and transform them to lowercase) || here, there will be a group for each character a, n, i, k
                          .All(g => g.Count() == 1); //for every group, count the number of it's element and check if it's 1 
                                                     //|| here, 'a' group has 2 elements so it return false though other groups has only one element in their group
                                                     //return (str.ToUpper().Distinct().Count() == str.Length);
            }
        }

        public static string CreatePhoneNumber(int[] numbers)
        {
            return Regex.Replace(new string(numbers.Select(n => (char)(n + '0'))
                                                   .ToArray()),
                                @"(\d{3})(\d{3})(\d{4})", "($1) $2-$3");
        }

        public static int FindParityOutlier(int[] integers)
        {
            if (integers.Count(n => n % 2 == 0) > 1)
                return integers.First(n => n % 2 != 0);
            else
                return integers.First(n => n % 2 == 0);

            var cisla = integers.GroupBy(n => 2 % n).First(a => a.Count() == 1).First();

        }

        public static string PigLatin(string str)
        {

            return string.Join(" ", str.Split(' ')
                .Where(word => word.All(c => char.ToLower(c) >= 'a' &&
                                           char.ToLower(c) <= 'z'))
                                         .Select(word => word.Substring(1) + word[0] + "ay"));
        }

        public static string ChangeWeight(string strng)
        {
            return string.Join(" ", strng.Split(' ')
                .OrderBy(word => word.Sum(chr => chr - '0'))
                .ThenBy(word => word));
        }

        public static int DontGiveMeFive(int start, int end)
        {
            return Enumerable.Range(start, end - start + 1)
                .Count(n => !n.ToString().Contains("5"));
        }

        public static string DuplicateEncode(string word)
        {
            return new string(word.Select(chr => word
            .Count(chr2 => char.ToLower(chr) == char.ToLower(chr2)) == 1
            ? '('
            : ')').ToArray());
        }

        public static int OnesAndZeros(int[] binaryArray)
        {
            return Convert.ToInt32(new string(binaryArray.Select(b => b == 0 ? '0' : '1')
                                                           .ToArray()), 2);
        }

        public static int[] CountPositivesSumNegatives(int[] input)
        {
            if (input == null || input.Length == 0)
                return new int[] { };
            else
                return new int[] { input.Count(n => n > 0), input.Where(n => n < 0).Sum() };
        }
    }
}