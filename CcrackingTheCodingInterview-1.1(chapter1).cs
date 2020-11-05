Question : Implement an algorithm to determine if a string has all unique characters. What if you cannot use additional data structures?

Solution : O(n)

class Program
	{
		
		static void Main(string[] args)
		{
			string name = Console.ReadLine();
			var r = isfindUnique(name) ? "Unique string" : "duplicate String";
			Console.WriteLine(r);
		}
    
		public static bool isfindUnique(string name)
		{
			string emptyStr = "";
			foreach (var item in name)
			{
				if (emptyStr.Contains(item))
				{
					return false;
				}
				emptyStr = emptyStr + item;
			}
			return true;
		}
	}
  
  
  Naive Solution : O(n^2)
  class Program
	{
		
		static void Main(string[] args)
		{
			string name = Console.ReadLine();
			var r = isfindUnique(name) ? "Unique string" : "duplicate String";
			Console.WriteLine(r);
		}
		public static bool isfindUnique(string name)
		{
			//string emptyStr = "";
			for (int i =0;i<name.Length;i++)
			{
				for (int j = i+1; j < name.Length; j++)
				{
					if (name[i] == name[j])
						return false;
				}

			}
			return true;
		}
	}
  
  
