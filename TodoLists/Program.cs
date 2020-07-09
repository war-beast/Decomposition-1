using System;
using System.Collections.Generic;

namespace TodoLists
{
	class Program
	{
		static void Main(string[] args)
		{
			var goalsIndividual = new List<string>();
			var goalsWork = new List<string>();
			var goalsFamily = new List<string>();

			while (true)
			{
				Console.Clear();
				//поиск длинны самого длинного списка на данный момент
				var max = goalsIndividual.Count > goalsWork.Count ? goalsIndividual.Count : goalsWork.Count;
				max = max > goalsFamily.Count ? max : goalsFamily.Count;

				Console.WriteLine("Личный | Рабочий | Семейный");
				for (var i = 0; i < max; i++)
				{
					ShowGoal(goalsIndividual, i);
					ShowGoal(goalsWork, i);
					ShowGoal(goalsFamily, i);
					Console.WriteLine();
				}

				Console.WriteLine("Куда вы хотите добавить цель?");
				var listName = Console.ReadLine()?.ToUpper(); //то что введёт пользователь, переведённое в верхний регистр
				if (string.IsNullOrWhiteSpace(listName))
					continue;

				Console.WriteLine("Что это за цель?");
				var goal = Console.ReadLine();
				if (string.IsNullOrWhiteSpace(goal))
					continue;

				switch (listName)
				{
					case "ЛИЧНЫЙ":
						goalsIndividual.Add(goal);
						break;
					case "РАБОЧИЙ":
						goalsWork.Add(goal);
						break;
					case "СЕМЕЙНЫЙ":
						goalsFamily.Add(goal);
						break;
				}
			}
		}

		private static void ShowGoal(IReadOnlyList<string> goals, int i) =>
			Console.Write(goals.Count > i ? $"{goals[i]} | " : "Empty | ");
	}
}
