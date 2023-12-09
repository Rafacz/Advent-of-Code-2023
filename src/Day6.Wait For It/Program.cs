namespace Day6.Wait_For_It
{
	public class Program
	{
		static void Main(string[] args)
		{
			Part1();
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
