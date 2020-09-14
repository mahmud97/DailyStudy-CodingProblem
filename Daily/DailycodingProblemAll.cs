***********************************Main calss or driver class from where funcition is calling******************* 
using System;
using System.Collections.Generic;
using System.Text;

namespace ProblemPractice2
{
	class DailyCodingProblemsBaseClass
	{
	
		static void Main(string [] args)
		{
			var ob = new DailyCodingProblems();
			//ob.Problem1();
			//ob.problem2();
			//ob.problem4();
			//ob.problem7();
			//ob.problem9();
			//ob.Problem9Updated();
			//ob.problem11Updated();
			ob.problem11();
		}

	}
}



*****************************Solution*****************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProblemPractice2
{
	public class DailyCodingProblems
	{
		//problem 1

		public void Problem1()
		{
			var listofno = Console.
				ReadLine().
				Split(' ')
				.Select(int.Parse)
				.ToList();

			var number = Convert.ToInt32(Console.ReadLine());

			string msg = IsPairPossible(number, listofno) ? "Posiible" : "Not Possible";

			Console.WriteLine(msg);

		}


		public static bool IsPairPossible(int input, List<int> numbers)
		{

			var emptylist = new List<int>();
			int result;
			foreach (var number in numbers)
			{
				result = input - number;

				if (emptylist.Contains(result))
					return true;
				emptylist.Add(number);

			}

			return false;



		}

		//problem 2

		public void problem2()
		{
			var numbers = Console.
				ReadLine().
				Split(' ')
				.Select(int.Parse)
				.ToArray();
			int[] res;

			res = GetNewArray(numbers);

			foreach (var number in res)
			{
				Console.Write(number + " ");
			}


		}
		public static int[] GetNewArray(int[] a)
		{
			int[] newarray = new int[a.Length];

			for (int i = 0; i < a.Length; i++)
			{
				int product = 1;
				for (int j = 0; j < a.Length; j++)
				{
					if (i != j)
						product = product * a[j];
				}
				newarray[i] = product;

			}

			return newarray;



		}

		//problem 4

		public void problem4()
		{
			var numbers = Console.
				ReadLine().
				Split(' ')
				.Select(int.Parse)
				.ToHashSet();


			var res = FindFirstMissingPositive(numbers);
			Console.WriteLine("this is the minimum positive number " + res);



		}

		public int FindFirstMissingPositive(HashSet<int> numbers)
		{
			//Hashset This is a set of collection that contains no duplicate elements 
			//and there is no specific order for the elements stored in it.
			int minnum = 1;

			while (true)
			{

				if (!numbers.Contains(minnum))
				{
					break;
				}

				minnum++;

			}
			return minnum;

		}


		//Problem 7

		public void problem7()
		{
			var input = Console.ReadLine();
			int result = NumberOfWaysToDecode(input,0);
			Console.WriteLine(result);
		}


		public static int NumberOfWaysToDecode(string message, int index)
		{
			if (index == message.Length)
			{
				return 1;
			}

			var waysToDecode = 0;

			var currentNumber = int.Parse(message[index].ToString());

			if (currentNumber > 0)
			{
				waysToDecode += NumberOfWaysToDecode(message, index + 1);
			}

			if (index < message.Length - 1)
			{
				currentNumber = int.Parse(message.Substring(index, 2));

				if (currentNumber < 27)
				{
					waysToDecode += NumberOfWaysToDecode(message, index + 2);
				}
			}

			return waysToDecode;
		}

		//problem 9 noob solution 

		public void problem9()
		{
			var numbers = Console.
				ReadLine().
				Split(' ')
				.Select(int.Parse)
				.ToArray();

			int result = GetLargestNonadjacentSum(numbers);
			Console.WriteLine(result);
		}

		public static int GetLargestNonadjacentSum(int [] numbers)
		{
			int sum, res= 0,j=0; 
			

			for(int i = 0; i < 2; i++)
			{
				sum = 0;
				for(int k= j; k < numbers.Length; k = k + 2)
				{
					if (k<numbers.Length-1 && numbers[k + 1] > numbers[k])
					{
						sum += numbers[k + 1];
					}
					else
					{
						sum += numbers[k];
					}
				}

				j = 1;
				if(sum>res)
				res = sum;


			}

			return res;
		}

		//problem 9

		public void Problem9Updated()
		{
			var numbers = GetInput();

			var maxSum = GetMaxSum(numbers);

			Console.WriteLine(maxSum);
		}

		public static int[] GetInput()
		{
			var input = Console.ReadLine()
				.Split(' ')
				.Select(int.Parse)
				.ToArray();

			return input;
		}

		public static int GetMaxSum(int[] numbers)
		{
			var maxSum = FindMaxSum(numbers, 0, 0, false);

			return maxSum;
		}

		private static int FindMaxSum(int[] numbers, int currentIndex, int currentSum, bool isPreviousAdded)
		{
			if (currentIndex == numbers.Length)
			{
				return currentSum;
			}

			var currentMaxSum = currentSum;

			if (!isPreviousAdded)
			{
				var maxIfAddCurrent = FindMaxSum(numbers, currentIndex + 1, currentSum + numbers[currentIndex], true);

				currentMaxSum = Math.Max(maxIfAddCurrent, currentMaxSum);
			}

			var maxIfDontAddCurrent = FindMaxSum(numbers, currentIndex + 1, currentSum, false);

			currentMaxSum = Math.Max(currentMaxSum, maxIfDontAddCurrent);

			return currentMaxSum;
		}

		//problem 11
		public  void problem11Updated()
		{
			var trie = new Problem11();

			trie.Add("dog");
			trie.Add("deer");
			trie.Add("deal");

			var results = trie.Search("de");

			foreach (var item in results)
			{
				Console.WriteLine(item);
			}
		}

    //problem 11
		public void problem11()
		{
			List<string> qrstrings = new List<string>();
			int n = 3;
			Console.WriteLine("enter lists of string");
			for(int i = 0; i < n; i++)
			{
				var inp =Console.ReadLine();
				qrstrings.Add(inp);
			}

			List<string> res = IsExistPrefix(qrstrings);

			foreach(var item in res)
			{
				Console.WriteLine(item);
			}

		}

		public static List<string> IsExistPrefix(List<string>qrstr)
		{
			List<string> result = new List<string>();
			Console.WriteLine("enter input string");
			var inp = Console.ReadLine();
			int i;
			foreach(var qr in qrstr)
			{
				i = 0;
				if (inp[i] == qr[i])
				{
					i++;

					if (inp[i] == qr[i])
					{
						result.Add(qr);
					}


				}

			}
			return result;

		}





	}

	public class Problem11
	{
		private class Node
		{
			public Node()
			{
				this.Children = new Dictionary<char, Node>();
			}

			public Node(char value)
				: this()
			{
				this.Character = value;
			}

			public char? Character { get; set; }

			public string Text { get; set; }

			public IDictionary<char, Node> Children { get; set; }
		}

		private Node root = new Node();

		public void Add(string text)
		{
			var currentNode = this.root;

			for (int i = 0; i < text.Length; i++)
			{
				var current = text[i];

				if (!currentNode.Children.ContainsKey(current))
				{
					var newNode = new Node(current);

					currentNode.Children.Add(current, newNode);
				}

				currentNode = currentNode.Children[current];
			}

			currentNode.Text = text;
		}

		public IEnumerable<string> Search(string queryString)
		{
			var node = this.Find(queryString);

			var result = this.GetTexts(node);

			return result;
		}

		private IEnumerable<string> GetTexts(Node node)
		{
			var result = new List<string>();

			if (node == null)
			{
				return result;
			}

			if (!string.IsNullOrEmpty(node.Text))
			{
				result.Add(node.Text);
			}

			foreach (var kvp in node.Children)
			{
				result.AddRange(GetTexts(kvp.Value));
			}

			return result;
		}

		private Node Find(string queryString)
		{
			var currentNode = this.root;

			for (int i = 0; i < queryString.Length; i++)
			{
				var current = queryString[i];

				if (currentNode.Children.ContainsKey(current))
				{
					currentNode = currentNode.Children[current];
				}
				else
				{
					return null;
				}
			}

			return currentNode;
		}
	}

}


