using System.Numerics;

namespace Day6.Wait_For_It
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

			var timeString = new string(lines[0].Split(':')[1].Where(c => !char.IsWhiteSpace(c)).ToArray());
			var distanceString = new string(lines[1].Split(':')[1].Where(c => !char.IsWhiteSpace(c)).ToArray());

			var time = BigInteger.Parse(timeString);
			var distance = BigInteger.Parse(distanceString);

			for (BigInteger i = 1; i < distance; i++)
			{
				if (i * (time - i) > distance)
				{
					Console.WriteLine(time - i - i + 1);
					break;
				}
			}

		}

		public static void Part1()
		{
			var lines = File.ReadAllLines("input.txt");

			var times = lines[0].Split(' ', StringSplitOptions.RemoveEmptyEntries)
				.Skip(1)
				.Select(int.Parse)
				.ToArray();

			var distances = lines[1].Split(' ', StringSplitOptions.RemoveEmptyEntries)
				.Skip(1)
				.Select(int.Parse)
				.ToArray();

			int result = 1;
			int count = 0;

			for (int i = 0; i < distances.Length; i++)
			{
				count = 0;

				for (int j = 0; j < times[i]; j++)
				{
					if ((times[i] - j) * j > distances[i])
					{
						count++;
					}
				}

				result *= count;
			}

			Console.WriteLine(result);
		}
	}
}
