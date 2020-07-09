using System;
using System.Collections.Generic;
using System.Linq;
using TodoLists.ConcreteLists;
using TodoLists.Interfaces;

namespace TodoLists
{
	public class TodoListsFactory : IListFactory
	{
		private readonly Dictionary<string, ITodoList> _todoLists;
		private readonly List<ITodoList> _lists = new List<ITodoList>
		{
			new FamilyGoals(),
			new IndividualGoals(),
			new WorkGoals()
		};

		public TodoListsFactory()
		{
			_todoLists = _lists.ToDictionary(key => key.Name.ToUpper(), value => value);
		}

		public IReadOnlyList<string> GetNames()
		{
			return _lists.Select(x => x.Name).ToList();
		}

		public ITodoList GetList(string key)
		{
			#region validation

			if(string.IsNullOrWhiteSpace(key))
				throw new ArgumentNullException(nameof(key));

			key = key.ToUpper();

			if(!_todoLists.ContainsKey(key))
				throw new InvalidOperationException($"Не удалось получить список дел по имени: {key}");

			#endregion

			return _todoLists[key];
		}

		public int MaxCount => _todoLists
			.Select(x => x.Value.Goals.Count)
			.Max();
	}
}
