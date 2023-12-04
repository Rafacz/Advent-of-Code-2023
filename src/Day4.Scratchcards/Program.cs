namespace Day4.Scratchcards
{
	public class Program
	{
		static void Main(string[] args)
		{
			Part1();
			Part2();
		}

		public static void Part2()
		{
			var lines = File.ReadAllLines("input.txt");

			var keys = Enumerable.Range(0, lines.Length);
			var dict = keys.ToDictionary(key => key, value => 1);

			for (int x = 0; x < lines.Length; x++)
			{
				var sCards = new HashSet<int>();
				var wCards = new HashSet<int>();

				var items = lines[x].Split('|');
				var sNumbers = items[0].Split(':')[1].Split(' ');
				var wNumbers = items[1].Split(' ');

				foreach (var wNumber in wNumbers)
				{
					if (int.TryParse(wNumber, out int wCard))
						wCards.Add(wCard);
				}

				foreach (var sNumber in sNumbers)
				{
					if (int.TryParse(sNumber, out int sCard))
						sCards.Add(sCard);
				}

				int count = 0;

				foreach (var wCard in wCards)
				{
					if (sCards.Contains(wCard))
					{
						count++;
					}
				}

				for (int i = 0; i < dict[x]; i++)
				{
					for (int j = 1; j < count + 1; j++)
					{
						dict[j + x]++;
					}
				}
			}

			Console.WriteLine(dict.Values.Sum());
		}

		public static void Part1()
		{
			using (StreamReader reader = new StreamReader("input.txt"))
			{
				string? line = string.Empty;
				int sum = 0;

				while ((line = reader.ReadLine()) != null)
				{
					int count = 0;

					var sCards = new HashSet<int>();
					var wCards = new HashSet<int>();

					var items = line.Split('|');
					var sNumbers = items[0].Split(':')[1].Split(' ');
					var wNumbers = items[1].Split(' ');

					foreach (var sNumber in sNumbers)
					{
						if (int.TryParse(sNumber, out int sCard))
							sCards.Add(sCard);
					}

					foreach (var wNumber in wNumbers)
					{
						if (int.TryParse(wNumber, out int wCard))
							wCards.Add(wCard);
					}

					foreach (var wCard in wCards)
					{
						if (sCards.Contains(wCard))
							count++;
					}

					sum += (int)Math.Pow(2, count - 1);
				}

				Console.WriteLine(sum);
			}
		}
	}
}
