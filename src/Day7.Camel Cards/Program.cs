namespace Day7.Camel_Cards
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
			var hands = new List<Hand>();

			using StreamReader sr = new StreamReader("input.txt");
			{
				string line;
				while ((line = sr.ReadLine()!) != null)
				{
					var cards = line.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0];
					var hand = new Dictionary<char, int>();

					foreach (var c in cards)
					{
						if (hand.ContainsKey(c))
						{
							hand[c]++;
						}
						else
						{
							hand.Add(c, 1);
						}
					}

					hands.Add(new Hand(true, int.Parse(line.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1]), cards, hand));
				}
			}
			hands = hands.OrderBy(x => x.Strength).ToList();
			hands.Sort();

			int count = 1;
			int result = 0;

			foreach (var hand in hands)
			{
				result += hand.Bid * count;
				count++;
			}

			Console.WriteLine(result);
		}

		public static void Part1()
		{
			var hands = new List<Hand>();

			using StreamReader sr = new StreamReader("input.txt");
			{
				string line;
				while ((line = sr.ReadLine()!) != null)
				{
					var cards = line.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0];
					var hand = new Dictionary<char, int>();

					foreach (var c in cards)
					{
						if (hand.ContainsKey(c))
						{
							hand[c]++;
						}
						else
						{
							hand.Add(c, 1);
						}
					}

					hands.Add(new Hand(false, int.Parse(line.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1]), cards, hand));
				}
			}
			hands = hands.OrderBy(x => x.Strength).ToList();
			hands.Sort();

			int count = 1;
			int result = 0;

			foreach (var hand in hands)
			{
				result += hand.Bid * count;
				count++;
			}

			Console.WriteLine(result);
		}

	}
}
