
Question : 
This problem was asked by Stripe.

Given an array of integers, find the first missing positive integer in linear time and constant space. In other words, find the lowest positive integer that does not exist in the array. The array can contain duplicates and negative numbers as well.

For example, the input [3, 4, -1, 1] should give 2. The input [1, 2, 0] should give 3.

You can modify the input array in-place.

Answer : 

using System;
using System.Collections.Generic;
using System.Linq;

namespace ProblemPractice2
{
    public class MainProgram
    {
        static void Main(string[] args)
        {
            Problem3.TakeInput();

        }
    }


    public class Problem3
    {
        public static void TakeInput()
        {
            //var numbers = Console.ReadLine()
            //    .Split(' ')
            //    .Select(int.Parse)
            //    .ToList();

            List<int> numbers = new List<int>() { 3, 4, -1, 1 };
            //Remeber we can use here hashset too just by using HashSet<int> numbers
            var r = Result(numbers);
            Console.WriteLine(r + "e hochhe min number");
        }

        public static int Result(List<int> numbers)
        {
            if (numbers is null)
            {
                throw new ArgumentNullException(nameof(numbers));
            }

            int k = 1;
            while (true)
            {

                if (!numbers.Contains(k))
                {
                    Console.WriteLine(k + " list a nai ");
                    break;
                }
                k++;
            }
            return k;
        }
    }


}
