using System.Collections.Generic;

namespace TodoLists.Interfaces
{
	public interface IListFactory
	{
		ITodoList GetList(string key);

		int MaxCount { get; }

		IReadOnlyList<string> GetNames();
	}
}
