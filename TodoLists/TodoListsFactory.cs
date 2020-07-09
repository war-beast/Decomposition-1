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

		public TodoListsFactory()
		{
			ITodoList familyList = new FamilyGoals();
			ITodoList individualList = new IndividualGoals();
			ITodoList workList = new WorkGoals();

			_todoLists = new Dictionary<string, ITodoList>
			{
				{ individualList.Name.ToUpper(), individualList },
				{ workList.Name.ToUpper(), workList },
				{ familyList.Name.ToUpper(), familyList }
			};
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
