namespace Day2.Cube_Conundrum
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
			string filePath = Directory.GetCurrentDirectory() + "/input.txt";

			using (StreamReader reader = new StreamReader(filePath))
			{
				string? line = string.Empty;
				int score = default;

				while ((line = reader.ReadLine()) != null)
				{
					int rMax = 0;
					int gMax = 0;
					int bMax = 0;

					var arr = line.Split(' ');
					int gameId = int.Parse(arr[1].Replace(":", string.Empty));
					string rounds = line.Substring(line.IndexOf(':') + 1);
					var roundArray = rounds.Split(';');

					foreach (var round in roundArray)
					{
						var rolls = round.Split(',');

						foreach (var roll in rolls)
						{
							string val = roll.Trim();

							int r = 0;
							int g = 0;
							int b = 0;

							if (roll.Contains("red"))
								r += int.Parse(val.Split(' ')[0].ToString());
							else if (roll.Contains("green"))
								g += int.Parse(val.Split(' ')[0].ToString());
							else if (roll.Contains("blue"))
								b += int.Parse(val.Split(' ')[0].ToString());

							if (r > rMax)
								rMax = r;
							if (g > gMax)
								gMax = g;
							if (b > bMax)
								bMax = b;
						}
					}

					score += rMax * gMax * bMax;
				}

				Console.WriteLine(score);
			}
		}

		public static void Part1()
		{
			string filePath = Directory.GetCurrentDirectory() + "/input.txt";

			using (StreamReader reader = new StreamReader(filePath))
			{
				string? line = string.Empty;
				int score = default;

				while ((line = reader.ReadLine()) != null)
				{
					var arr = line.Split(' ');
					int gameId = int.Parse(arr[1].Replace(":", string.Empty));
					string rounds = line.Substring(line.IndexOf(':') + 1);
					var roundArray = rounds.Split(';');

					bool isPossible = true;

					foreach (var round in roundArray)
					{
						var rolls = round.Split(',');

						foreach (var roll in rolls)
						{
							string val = roll.Trim();

							int r = 0;
							int g = 0;
							int b = 0;

							if (roll.Contains("red"))
								r += int.Parse(val.Split(' ')[0].ToString());
							else if (roll.Contains("green"))
								g += int.Parse(val.Split(' ')[0].ToString());
							else if (roll.Contains("blue"))
								b += int.Parse(val.Split(' ')[0].ToString());

							if (r > 12 || g > 13 || b > 14)
							{
								isPossible = false;
								break;
							}
						}
					}

					if (isPossible)
					{
						score += gameId;
						isPossible = false;
					}
				}

				Console.WriteLine(score);
			}
		}
	}
}
