using System.Collections.Generic;

namespace TodoLists.Interfaces
{
	public interface ITodoList
	{
		string Name { get; }

		List<string> Goals { get; }

		void Append(string goal);

		string GetGoal(int id);
	}
}
