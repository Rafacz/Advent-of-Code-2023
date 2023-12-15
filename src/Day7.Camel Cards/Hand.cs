namespace Day7.Camel_Cards
{
	public class Hand : IComparable<Hand>
	{
		private readonly Dictionary<char, int> cards = new()
		{
			{'A', 14},
			{'K', 13},
			{'Q', 12},
			{'J', 11},
			{'T', 10},
			{'9', 9},
			{'8', 8},
			{'7', 7},
			{'6', 6},
			{'5', 5},
			{'4', 4},
			{'3', 3},
			{'2', 2}
		};

		public bool IsJoker { get; }
		public int Bid { get; }
		public string Cards { get; }
		public int Strength { get; }
		public Dictionary<char, int> Kvp { get; set; }


		public Hand(bool isJoker, int bid, string str, Dictionary<char, int> kvp)
		{
			Bid = bid;
			Kvp = kvp;
			Cards = str;
			IsJoker = isJoker;
			Strength = SetStrength();
		}

		private int SetStrength()
		{
			if (IsJoker && Kvp.ContainsKey('J'))
			{
				cards['J'] = 1;
				int jokers = Kvp['J'];

				if (Kvp.Any(x => x.Value == (5 - jokers)))
				{
					return 7;
				}
				else if (Kvp.Any(x => x.Value >= (4 - jokers)))
				{
					return 6;
				}
				else if ((Kvp.Any(x => x.Value == 3) && Kvp.Any(x => x.Value == 2)) ||
						(jokers == 1 && Kvp.Count(x => x.Value == 2) == 2) ||
						(jokers >= 2 && Kvp.Any(x => x.Value == 2)))
				{
					return 5;
				}
				else if (Kvp.Any(x => x.Value == (3 - jokers)))
				{
					return 4;
				}
				else if (Kvp.Count(x => x.Value == 2) == 2 ||
					(jokers == 1 && Kvp.Count(x => x.Value == 2) >= 1) ||
					(jokers == 2))
				{
					return 3;
				}
				else if (Kvp.Any(x => x.Value == (2 - jokers)))
				{
					return 2;
				}
			}

			else
			{
				if (Kvp.Any(x => x.Value == 5))
				{
					return 7;
				}
				else if (Kvp.Any(x => x.Value == 4))
				{
					return 6;
				}
				else if (Kvp.Any(x => x.Value == 3) && Kvp.Any(x => x.Value == 2))
				{
					return 5;
				}
				else if (Kvp.Any(x => x.Value == 3))
				{
					return 4;
				}
				else if (Kvp.Count(x => x.Value == 2) == 2)
				{
					return 3;
				}
				else if (Kvp.Any(x => x.Value == 2))
				{
					return 2;
				}
			}

			return 1;
		}

		public int CompareTo(Hand? other)
		{
			if (other is null)
				throw new ArgumentNullException();

			var strengthCmp = Strength.CompareTo(other.Strength);

			if (strengthCmp != 0)
			{
				return strengthCmp;
			}

			for (int i = 0; i < Cards.Length; i++)
			{
				char thisCard = Cards[i];
				char otherCard = other.Cards[i];

				int thisCardValue = cards[thisCard];
				int otherCardValue = cards[otherCard];

				int cardCmp = thisCardValue.CompareTo(otherCardValue);

				if (cardCmp != 0)
				{
					return cardCmp;
				}
			}

			return 0;
		}
	}
}
