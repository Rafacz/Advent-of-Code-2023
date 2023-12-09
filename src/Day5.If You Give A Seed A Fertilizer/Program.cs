using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Day5.If_20You_Give_A_Seed_A_Fertilizer
{
	public class Seed
	{
		public Seed(int id, BigInteger value)
		{
			Id = id;
			Value = value;
		}
		public int Id { get; set; }
		public BigInteger Value { get; set; }
	}
	public record Area(string desc, BigInteger SeedL, BigInteger SeedH, BigInteger DestL, BigInteger DestH);
	public class Program
	{
		public static void Main(string[] args)
		{
			var data = ExtractData();
			Part1(data);
			Part2(data);

			Console.ReadLine();
		}

		public static void Part2((List<Seed>, List<Area>) data)
		{

		}

		public static void Part1((List<Seed>, List<Area>) data)
		{
			string currentArea = data.Item2[0].desc;
			var result = data.Item1.Max(x => x.Value);

			foreach (var seed in data.Item1)
			{
				foreach (var areaGroup in data.Item2.GroupBy(area => area.desc))
				{
					bool isFound = false;

					foreach (var area in areaGroup)
					{
						currentArea = area.desc;
						var offset = area.DestL - area.SeedL;
						var seedDestination = seed.Value + offset;

						if (!isFound && seedDestination >= area.DestL && seedDestination <= area.DestH)
						{
							seed.Value = seedDestination;
							isFound = true;

							if (currentArea == "to-loca" && seed.Value < result)
							{
								result = seed.Value;
							}
						}
					}
				}
			}
			Console.WriteLine(result);
		}

		private static (List<Seed>, List<Area>) ExtractData()
		{
			var seeds = new List<Seed>();
			var areas = new List<Area>();

			string? line = string.Empty;
			string? dataSet = string.Empty;

			using StreamReader reader = new StreamReader("input.txt");
			{
				while ((line = reader.ReadLine()) != null)
				{
					if (string.IsNullOrEmpty(line))
					{
						dataSet = string.Empty;
						continue;
					}

					if (line.StartsWith("seeds:"))
					{
						var contents = line.Split(' ');

						int i = 0;

						for (i = 1; i < contents.Length; i++)
						{
							seeds.Add(new Seed(i, BigInteger.Parse(contents[i])));
						};

						continue;
					}

					else if (char.IsLetter(line[0]))
					{
						dataSet = line;
					}

					if (!string.IsNullOrEmpty(dataSet) && char.IsDigit(line[0]))
					{
						var contents = line.Split(' ');

						BigInteger f = BigInteger.Parse(contents[0]);
						BigInteger s = BigInteger.Parse(contents[1]);
						BigInteger t = BigInteger.Parse(contents[2]);

						areas.Add(new Area(dataSet.Substring(dataSet.IndexOf("to-"), 7), s, t + s - 1, f, t + f - 1));
					}
				}
			}

			return (seeds, areas);
		}
	}
}