namespace Pluralize
{
	public static class PluralizeTask
	{
		public static string PluralizeRubles(int count)
		{
			// Функция склонения "рубля" в зависимости от предшествующего числительного count.
			if (count % 10 == 1 && (count - 11) % 100 != 0)
				return "рубль";
			else if (count % 10 >= 2 && count % 10 <= 4 && !(count % 100 >= 11 && count % 100 <= 19))
				return "рубля";
			else
				return "рублей";
		}
	}
}
