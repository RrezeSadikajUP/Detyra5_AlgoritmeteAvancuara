using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Horspool
{
	public static class BoyerMooreHorspool
	{
		public static int Find(string text, string pattern)
		{
			// If substring is bigger than string, no match exists
			if (pattern.Length > text.Length)
				return -1;

			// If the substring has characters not in the string, no match exists
			if (pattern.Except(text).Any())
				return -1;

			Dictionary<char, int> BadMatchTable = new Dictionary<char, int>();

			// Initializes every letter with the default value
			foreach (char c in text)
			{
				if (!BadMatchTable.Keys.Contains(c))
					BadMatchTable.Add(c, pattern.Length);
			}

			// The formula for every letter in the pattern (except the last) is lenght - index - 1
			for (int i = 0; i < pattern.Length - 1; i++)
			{
				BadMatchTable[pattern[i]] = pattern.Length - i - 1;

			}

			int index = 0;

			while (index < text.Length - pattern.Length)
			{
				bool match = true;

				for (int i = pattern.Length - 1; i >= 0; i--)
				{
					if (pattern[i] != text[index + i])
					{
						match = false;
						index += BadMatchTable[text[index + pattern.Length - 1]];
						if (index >= text.Length)
						{
							break;
						}
					}
				}

				if (match)
					return index;
			}

			return -1;
		}
	}
}
