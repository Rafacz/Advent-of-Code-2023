using System.Text;

namespace Day1.Trebuchet
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Part1();
			Part2();

			Console.ReadKey();
		}

		private static void Part2()
		{
			string filePath = Directory.GetCurrentDirectory() + "/input.txt";

			var dict = new Dictionary<string, string>()
		{
			{ "one", "1" },
			{ "two", "2" },
			{ "three", "3" },
			{ "four", "4" },
			{ "five", "5" },
			{ "six", "6" },
			{ "seven", "7" },
			{ "eight", "8" },
			{ "nine", "9" }
		};

			var sb = new StringBuilder();

			using (StreamReader reader = new StreamReader(filePath))
			{
				long sum = 0;
				string? line = string.Empty;

				while ((line = reader.ReadLine()) != null)
				{
					string val1 = string.Empty;
					string val2 = string.Empty;
					sb.Clear();
					sb.Insert(0, line);
					for (int i = 0; i < line.Length; i++)
					{
						if (char.IsDigit(line[i]))
						{
							val1 += line[i];
							break;
						}

						val1 += dict.FirstOrDefault(
							keyValuePair => sb.ToString().StartsWith(keyValuePair.Key)).Value;

						if (!string.IsNullOrEmpty(val1))
						{
							break;
						}

						sb.Remove(0, 1);
					}

					sb.Clear();

					for (int x = line.Length - 1; x > -1; x--)
					{
						if (char.IsDigit(line[x]))
						{
							val2 += line[x];
							break;
						}
						else
						{
							sb.Insert(0, line[x]);
							val2 += dict.FirstOrDefault(
								keyValuePair => sb.ToString().StartsWith(keyValuePair.Key)).Value;

							if (!string.IsNullOrEmpty(val2))
							{
								break;
							}

						}
					}

					var result = string.Concat(val1, val2);
					sum += int.Parse(result);
				}
				Console.WriteLine($"Sum: {sum}");
			}
		}

		private static void Part1()
		{
			string filePath = Directory.GetCurrentDirectory() + "/input.txt";

			using (StreamReader reader = new StreamReader(filePath))
			{
				long sum = 0;
				string val = string.Empty;
				string? line = string.Empty;

				while ((line = reader.ReadLine()) != null)
				{
					for (int i = 0; i < line.Length; i++)
					{
						if (char.IsDigit(line[i]))
						{
							val += line[i];
							break;
						}
					}

					for (int j = line.Length - 1; j > -1; j--)
					{
						if (char.IsDigit(line[j]))
						{
							val += line[j];
							break;
						}
					}

					sum += int.Parse(val);
					val = string.Empty;
				}

				Console.WriteLine($"Sum: {sum}");
			}
		}
	}
}
