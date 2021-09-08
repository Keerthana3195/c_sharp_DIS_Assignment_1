using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DIS_Assignment_1
{
    class Program
    {
        //Question 1
        /*Approach: 
         * I divided the string in two equal halves.I then created a string variable "vowels" which has all the vowels.
         * I used a for loop to count the number of vowels in each half of the original string. I store both the counts in 2 diff variables. 
         * At the end, I check if the number of vowels in both halves are equal. If yes, then I return true.*/
        static public Boolean HalvesAreAlike(string s)
        {

            s = s.ToLower();
            string first_half = s.Substring(0, s.Length / 2);
            string second_half = s.Substring(s.Length / 2);
            int first_half_vowels = 0;
            int second_half_vowels = 0;
            string vowels = "aeiou";

            for(int i = 0; i < first_half.Length; i++)
            {
                if(vowels.Contains(first_half[i]))
                {
                    first_half_vowels++;
                }

                if (vowels.Contains(second_half[i]))
                {
                    second_half_vowels++;
                }
            }
            if (first_half_vowels == second_half_vowels && first_half_vowels != 0 && second_half_vowels != 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        //Question 2
        /*Approach:
         * I created a variable "alpha" which has all the 26 alphabets.
         * I then used two nested foreach loops to iterate over the alpha and the input panagram string, simultaniously.
         * The outer foreach loop runs 26 times equal to the no. of alphabets in the alpha variable.
         * I increase the count when the input string has the needed alphabet.
         * At the end, if the count=26 then I return true.*/
        static public Boolean CheckIfPangram(string s)
        {
            string alpha = "abcdefghijklmnopqrstuvwxyz";
            int count = 0;
            foreach (char c in alpha)
            {
                foreach (char l in s.ToLower())
                {
                    if (c == l)
                    {
                        count++;
                        break;
                    }
                }
            }
            if (count == 26)
                return true;
            else
                return false;
        }

        //Question 3
        /* Approach: 
         * I used nested for loops to iterate the nested array.
         * I took a variable "sum" which is equal to the sum of all the elements within the array at each index individually.
         * Simultaneously, I keep changing the value of the variable "largest" after comparing it with each value of the sum.
         */
        static public int MaximumWealth(int[,] arr)
        {

            int largest = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                int sum = 0;
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    sum += arr[i, j];
                }
                if (largest < sum)
                {
                    largest = sum;
                }
            }


            return largest;
        }

        /* Additional function to check if the input has all unique characters or not. Used it to check the imput of Questions 4 and 5
         */
        static public bool uniqueCharacters(string input)
        {
            for (int i = 0; i < input.Length - 1; i++)
            {
                for (int j = i + 1; j < input.Length; j++)
                {
                    if (input[i] == input[j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        //Question 4
        /* Approach:
         * for each character in string stones, I check if that character is present in string jewels.
         * If it is present, then I increase the count and return it at the end.
         */
        static public int NumJewelsInStones(string jewels, string stones)
        {
            int count = 0;
            foreach (char c in stones)
            {
                if (jewels.Contains(c))
                {
                    count++;
                }
            }
            return count;
        }

        //Question 5
        /* Approach:
         * I created a list having each character of the input string word2
         * then, foreach character in input string, I assign that char to index value of the list = count in that particular iteration
         */
        static public string RestoreString(string word2, int[] indices)
        {
            var new_list = new List<char>();
            foreach (char c in word2)
            {
                new_list.Add(c);
            }

            int count = 0;
            foreach (char c in word2)
            {
                if(indices[count] >=0 && indices[count] < word2.Length)
                {
                    new_list[indices[count]] = c;
                    count++;
                }  
            }

            string new_string = string.Join("", new_list);
            return new_string;
        }


        //Question 6
        /*Approach:
         * created an empty target list
         * then used forloop to insert each value of array nums at each index from the index array into the target list
         * convert the list to array at the end and return it.
         */
        static public int[] CreateTargetArray(int[] nums, int[] index)
        {
            var target_list = new List<int>(nums.Length);
            if (nums.Length == index.Length && nums.Length >= 1 && nums.Length <= 100 && index.Length >= 1 && index.Length <= 100)
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] >= 0 && nums[i] <= 100 && index[i] >= 0 && index[i] <= i)
                    {
                        target_list.Insert(index[i], nums[i]);
                    }
                }
            }
            int[] target_array = target_list.ToArray();
            return target_array;
        }
        static void Main(string[] args)
        {

            //Question 1
            Console.WriteLine("Q1 : Enter the string:");
            string s = Console.ReadLine();

            if (s.Length % 2 == 0 && s.Length >= 2 && s.Length <= 1000)
            {
                bool pos = HalvesAreAlike(s);
                if (pos)
                {
                    Console.WriteLine("Both Halfs of the string are alike");
                }
                else
                {
                    Console.WriteLine("Both Halfs of the string are not alike");
                }

            }
            else
            {
                Console.WriteLine("The length of string is not even. Please enter a string with even length. Thank you");
            }

            Console.WriteLine();

            //Question 2:
            Console.WriteLine(" Q2 : Enter the string to check for pangram:");
            string s1 = Console.ReadLine();
            bool flag = CheckIfPangram(s1);
            if (flag)
            {
                Console.WriteLine("Yes, the given string is a pangram");
            }
            else
            {
                Console.WriteLine("No, the given string is not a pangram");
            }
            Console.WriteLine();

            //Question 3:
            int[,] arr = new int[,] { { 2, 8, 7 }, { 7, 1, 3 }, { 1, 9, 5 } };
            int Wealth = MaximumWealth(arr);
            Console.WriteLine("Q3:");
            Console.WriteLine("Richest person has a wealth of {0}", Wealth);
            Console.WriteLine();


            //Question 4:
            string jewels = "aA";
            string stones = "aAAbbbb";
            Console.WriteLine("Q4:");
            bool unique_jewels = uniqueCharacters(jewels);
            bool jewels_alpha = Regex.IsMatch(jewels, "^[a-zA-Z]+$");
            bool stones_alpha = Regex.IsMatch(stones, "^[a-zA-Z]+$");

            if (jewels.Length >= 1 && jewels.Length <= 50 && stones.Length>=1 && stones.Length<=50 && unique_jewels && jewels_alpha && stones_alpha)
            {
                int num = NumJewelsInStones(jewels, stones);
                Console.WriteLine("the number of stones you have that are also jewels are {0}", num);
            }
            
            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Q5:");
            string word2 = "art";
            int[] indices = { 1, 0, 2 };
            int n = word2.Length;
            bool word2_letters = Regex.IsMatch(word2, "^[a-z]+$");
            string indices_string = string.Join("", indices);
            bool unique_indices = uniqueCharacters(indices_string);
            if (n==indices.Length && n>=1 && n<=100 && word2_letters && unique_indices)
            {
                string rotated_string = RestoreString(word2, indices);
                Console.WriteLine("The Final string after rotation is " + rotated_string);
            }
            Console.WriteLine();


            //Quesiton 6:
            Console.WriteLine("Q6: ");
            int[] nums = { 1, 2, 3, 4, 0 };
            int[] index = { 0, 1, 2, 3, 0 };
            int[] target = CreateTargetArray(nums, index);
            Console.WriteLine("Target array  for the Given array's is:");
            for (int i = 0; i < target.Length; i++)
            {
                Console.Write(target[i] + "\t");
            }
            Console.WriteLine();

        }
    }
}


/*My self reflection on assignment:
 * I actually got more confidence on creating functions and calling them in the main(). This is my first time using c#
 * Using data structures like arrays and lists was fun and knowledable.
 * I don't have any negative comments/recommendations on this assignment. 
 * This assignment is only helping me to become more proficient on the concepts on c# 
 * I liked the way sample program.cs was given in the appendix. It helped me a lot as a beginner to c#.
 * I personally did this assignment in 6-7 days. Each day, I did no more than one question with 30-45 mins per question.*/