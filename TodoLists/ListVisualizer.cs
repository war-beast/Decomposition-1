using System;
using System.Collections.Generic;
using System.Text;
using TodoLists.Interfaces;

namespace TodoLists
{
	public class ListVisualizer : IListVisualizer
	{
		public void Show(IListFactory listFactory)
		{
			//поиск длинны самого длинного списка на данный момент
			var max = listFactory.MaxCount;

			var todoListNames = listFactory.GetNames();
			Console.WriteLine(string.Join(" | ", todoListNames));
			for (var i = 0; i < max; i++)
			{
				foreach (var name in todoListNames)
				{
					var goals = listFactory
						.GetList(name)
						.Goals;
					ShowGoal(goals, i);
				}
				Console.WriteLine();
			}
		}

		#region private methods

		private static void ShowGoal(IReadOnlyList<string> goals, int i) =>
			Console.Write(goals.Count > i ? $"{goals[i]} | " : "Empty | ");

		#endregion
	}
}
