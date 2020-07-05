Question : This problem was  asked by Google.

Given a list of numbers and a number k, return whether any two numbers from the list add up to k.

For example, given [10, 15, 3, 7] and k of 17, return true since 10 + 7 is 17.

Bonus: Can you do this in one pass?

Solution :

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProblemPractice2
{
    public static class Problem1
    {
		
        public static void TakeInput()
        {
            var lists = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            var k = int.Parse(Console.ReadLine());
            var r = Result(lists, k) ? "sum exist" : "does not exist" ;
            Console.WriteLine(r);
        }

        public static bool Result(List<int> lists, int k)
        {
            if (lists is null)
            {
                throw new ArgumentNullException(nameof(lists));
            }

            var ds  = new HashSet<int>();

            foreach (int item in lists)
            {
                var remain = k - item;

                if (ds.Contains(remain))
                {
                    Console.WriteLine(remain + " , " + item);
                    return true;
                }

                ds.Add(item);


            }

            return false;

        }



	}
}
