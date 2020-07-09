using System.Collections.Generic;
using TodoLists.Interfaces;

namespace TodoLists.ConcreteLists
{
	public abstract class TodoListBase : ITodoList
	{
		public List<string> Goals { get; private set; }

		public string Name { get; protected set; }

		protected TodoListBase()
		{
			Goals = new List<string>();
		}

		public void Append(string goal)
		{
			Goals.Add(goal);
		}

		public string GetGoal(int id) => Goals[id];
	}
}
