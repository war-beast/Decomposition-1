using System;

namespace CharacterUpgradingMenu
{
	class Program
	{
		static void Main(string[] args)
		{
			int age = 0, strength = 0, agility = 0, intelligence = 0, points = 25;

			Console.WriteLine("Добро пожаловать в меню выбора создания персонажа!");
			Console.WriteLine($"У вас есть {points} очков, которые вы можете распределить по умениям");
			Console.WriteLine("Нажмите любую клавишу чтобы продолжить...");
			Console.ReadKey();

			while (points > 0)
			{
				RefreshCharacteristicsInfo(strength, agility, intelligence, age);
				Console.WriteLine($"Поинтов - {points}");

				Console.WriteLine("Какую характеристику вы хотите изменить?");
				var subject = Console.ReadLine();

				Console.WriteLine(@"Что вы хотите сделать? +\-");
				var operation = Console.ReadLine();

				Console.WriteLine(@"Колличество поинтов которые следует {0}", operation == "+" ? "прибавить" : "отнять");
				var operandPoints = GetUserInput();

				switch (subject.ToLower())
				{
					case "сила":
						(strength, points) = GetUpdatedCharacteristic(operation, operandPoints, strength, points);
						break;
					case "ловкость":
						(agility, points) = GetUpdatedCharacteristic(operation, operandPoints, agility, points);
						break;
					case "интеллект":
						(intelligence, points) = GetUpdatedCharacteristic(operation, operandPoints, intelligence, points);
						break;
				}
			}

			Console.WriteLine("Вы распределили все очки. Введите возраст персонажа:");
			age = GetUserInput();

			RefreshCharacteristicsInfo(strength, agility, intelligence, age);
		}

		private static int GetUserInput()
		{
			int result;
			string inputRaw;
			do
			{
				inputRaw = Console.ReadLine();
			} while (!int.TryParse(inputRaw, out result));

			return result;
		}

		private static void RefreshCharacteristicsInfo(int strength, int agility, int intelligence, int age)
		{
			Console.Clear();
			var strengthVisual = ReloadCharacteristics(strength);
			var agilityVisual = ReloadCharacteristics(agility);
			var intelligenceVisual = ReloadCharacteristics(intelligence);
			Console.WriteLine($"Возраст - {age}\nСила - [{strengthVisual}]\nЛовкость - [{agilityVisual}]\nИнтеллект - [{intelligenceVisual}]");
		}

		private static (int, int) GetUpdatedCharacteristic(string operation, int operandPoints, int parameter, int points)
		{
			const int max = 10;
			const int min = 0;

			if (operation == "+")
			{
				var overhead = parameter + operandPoints;
				operandPoints = overhead < max 
					? operandPoints 
					: operandPoints - (overhead - max);
			}
			else
			{
				var overhead = parameter - operandPoints;
				operandPoints = overhead < min 
					? operandPoints + overhead - min
					: operandPoints;
			}

			parameter = operation == "+" ? parameter + operandPoints : parameter - operandPoints;
			points = operation == "+" ? points - operandPoints : points + operandPoints;
			return (parameter, points);
		}

		private static string ReloadCharacteristics(int value)
		{
			var result = string.Empty;
			return result.PadLeft(value, '#').PadRight(10, '_');
		}
	}
}
