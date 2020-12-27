using System;

namespace Horspool
{
	public static class Program
	{
		static void Main(string[] args)
		{
			//Apply for 5 tests
			for (int i = 0; i < 6; i++)
			{
				Test();
				Console.ReadKey();

			}
		}

		public static void Test()
		{
			Console.WriteLine("Shënoni një fjalë/fjali për t'u përshkuar - text:");
			string text = Console.ReadLine();

			Console.WriteLine();

			Console.WriteLine("Shënoni një fjalë/fjali kërkuese - pattern:");
			string pattern = Console.ReadLine();

			int match = BoyerMooreHorspool.Find(text, pattern);

			Console.Clear();

			if (match == -1)
			{
				Console.WriteLine("Asnjë përshtatje nuk u gjend!");
				return;
			}

			Console.WriteLine("Përshtatja në karakterin {0}", match);

			Console.WriteLine();
			Console.WriteLine(text);
			for (int i = 0; i < match; i++)
				Console.Write(" ");

			for (int i = 0; i < pattern.Length; i++)
				Console.Write("^");

		}
	}
}
