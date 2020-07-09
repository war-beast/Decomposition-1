using System;
using System.Collections.Generic;
using TodoLists.Interfaces;

namespace TodoLists
{
	class Program
	{
		static void Main(string[] args)
		{
			IListFactory todoLists = new TodoListsProxy();

			while (true)
			{
				Console.Clear();
				//поиск длинны самого длинного списка на данный момент
				var max = todoLists.MaxCount;

				var todoListNames = todoLists.GetNames();
				Console.WriteLine(string.Join(" | ", todoListNames));
				for (var i = 0; i < max; i++)
				{
					foreach (var name in todoListNames)
					{
						var goals = todoLists
							.GetList(name)
							.Goals;
						ShowGoal(goals, i);
					}
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

				todoLists.GetList(listName).Append(goal);
			}
		}

		private static void ShowGoal(IReadOnlyList<string> goals, int i) =>
			Console.Write(goals.Count > i ? $"{goals[i]} | " : "Empty | ");
	}
}
