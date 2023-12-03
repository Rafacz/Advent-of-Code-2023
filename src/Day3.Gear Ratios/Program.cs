
namespace Day3.Gear_Ratios
{
	public record Area(int x1, int y1, int x2, int y2, int value);
	public record Point(int x, int y, char c);

	public class Program
	{
		public static void Main(string[] args)
		{


			Console.ReadLine();
		}
		public static void Part1()
		{
			string filePath = Directory.GetCurrentDirectory() + "/input.txt";

			var lines = File.ReadAllLines(filePath);

			var areas = GetAreas(lines).ToList();
			var points = GetPoints(lines).ToList();

			int sum = 0;

			foreach (var area in areas)
			{
				if (IsPointWithinPlain(area, ref points))
				{
					sum += area.value;
				}
			}

			Console.WriteLine(sum);
		}

		public static void Part2()
		{
			string filePath = Directory.GetCurrentDirectory() + "/input.txt";

			var lines = File.ReadAllLines(filePath);

			var areas = GetAreas(lines).ToList();
			var points = GetPoints(lines).ToList();

			int sum = 0;

			foreach (var point in points)
			{
				if (point.c != '*')
					continue;

				sum += PointWithinTwoAreasSum(point, ref areas);
			}

			Console.WriteLine(sum);
		}

		private static bool IsPointWithinPlain(Area area, ref List<Point> points)
		{
			foreach (var point in points)
			{
				if (point.x >= area.x1 && point.y >= area.y1 &&
					point.x <= area.x2 && point.y <= area.y2)
				{
					return true;
				}
			}
			return false;
		}

		private static IEnumerable<Area> GetAreas(string[]? lines)
		{
			var str = string.Empty;
			int ptr1 = -2;
			int ptr2 = -2;

			for (int x = 0; x < lines?.Length; x++)
			{
				for (int y = 0; y < lines[x].Length; y++)
				{
					if (char.IsDigit(lines[x][y]))
					{
						str += lines[x][y];
						if (ptr1 == -2)
							ptr1 = y;
						if (ptr2 == -2)
							ptr2 = x;
					}
					else
					{
						if (ptr1 != -2)
						{
							yield return new Area(ptr2 - 1, ptr1 - 1, ptr2 + 1, ptr1 + str.Length, int.Parse(str));
							str = string.Empty;
							ptr1 = -2;
							ptr2 = -2;
						}
					}
				}
				if (!string.IsNullOrEmpty(str))
				{
					yield return new Area(ptr2 - 1, ptr1 - 1, ptr2 + 1, ptr1 + str.Length, int.Parse(str));
					str = string.Empty;
					ptr1 = -2;
					ptr2 = -2;
				}
			}

		}

		private static IEnumerable<Point> GetPoints(string[]? lines)
		{
			for (int x = 0; x < lines?.Length; x++)
			{
				for (int y = 0; y < lines[x].Length; y++)
				{
					if (!char.IsLetterOrDigit(lines[x][y]) && lines[x][y] != '.')
					{
						yield return new Point(x, y, lines[x][y]);
					}
				}
			}
		}
		private static int PointWithinTwoAreasSum(Point point, ref List<Area> areas)
		{
			int sum = 0;

			foreach (var area in areas)
			{
				if (point.x >= area.x1 && point.y >= area.y1 &&
					point.x <= area.x2 && point.y <= area.y2)
				{
					if (sum == 0)
					{
						sum += area.value;
					}
					else
					{
						sum *= area.value;
						return sum;
					}
				}
			}
			return 0;
		}
	}
}