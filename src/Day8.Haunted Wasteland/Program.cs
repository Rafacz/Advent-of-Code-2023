namespace Day8.Haunted_Wasteland
{
	public class Program
	{
		public class Cords
		{
			public Cords(string left, string right)
			{
				Left = left;
				Right = right;
			}

			public string Left { get; }
			public string Right { get; }
		}

		static void Main(string[] args)
		{
			Part1();
		}

		public static void Part1()
		{
			var lines = File.ReadAllLines("input.txt");

			var instructions = lines[0].ToCharArray();

			var cords = new Dictionary<string, Cords>();

			foreach (var line in lines.Skip(2))
			{
				var items = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

				cords.Add(items[0], new Cords(items[2].Substring(1, items[2].Length - 2),
					items[3].Substring(0, items[3].Length - 1)));
			}

			int result = 0;
			int instructionPointer = 0;
			string cordsPointer = "AAA";

			while (true)
			{

				if (instructions[instructionPointer] == 'R')
					cordsPointer = cords[cordsPointer].Right;
				else
					cordsPointer = cords[cordsPointer].Left;

				result++;

				if (cordsPointer == "ZZZ")
				{
					Console.WriteLine(result);
					break;
				}

				instructionPointer++;

				if (instructionPointer == instructions.Length)
					instructionPointer = 0;
			}
		}
	}

}
