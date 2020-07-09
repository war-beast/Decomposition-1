using System;

namespace CharacterUpgradingMenu
{
	class Program
	{
		static void Main(string[] args)
		{
			var points = new PointsKeeper(25);
			var hero = new SimpleHeroFactory().Create();

			Console.WriteLine("Добро пожаловать в меню выбора создания персонажа!");
			Console.WriteLine($"У вас есть {points.Balance} очков, которые вы можете распределить по умениям");
			Console.WriteLine("Нажмите любую клавишу чтобы продолжить...");
			Console.ReadKey();

			while (points.Balance > 0)
			{
				hero.ShowUpdatedState();
				Console.WriteLine($"Поинтов - {points.Balance}");

				Console.WriteLine("Какую характеристику вы хотите изменить?");
				var subject = Console.ReadLine();

				Console.WriteLine(@"Что вы хотите сделать? +\-");
				var operation = Console.ReadLine();

				Console.WriteLine(@"Колличество поинтов которые следует {0}", operation == "+" ? "прибавить" : "отнять");
				var operandPoints = GetUserInput();

				operandPoints = operation.Equals("+", StringComparison.CurrentCultureIgnoreCase)
					? operandPoints
					: -operandPoints;

				points.TransferToHero(hero, characteristicName: subject.ToUpper(), amount: operandPoints);
			}

			Console.WriteLine("Вы распределили все очки. Введите возраст персонажа:");
			hero.SetAge(GetUserInput());

			hero.ShowUpdatedState();
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
	}
}
