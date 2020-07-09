using System;
using TodoLists.Interfaces;

namespace TodoLists
{
	class Program
	{
		static void Main(string[] args)
		{
			IListFactory todoLists = new TodoListsProxy();
			IListVisualizer listVisualizer = new ListVisualizer();

			while (true)
			{
				Console.Clear();
				listVisualizer.Show(todoLists);

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
	}
}
