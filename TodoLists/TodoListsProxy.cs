﻿using System;
using System.Collections.Generic;
using TodoLists.Interfaces;

namespace TodoLists
{
	public class TodoListsProxy : IListFactory
	{
		private readonly Dictionary<string, ITodoList> _todoLists;
		private readonly IListFactory _todoListFactory;

		public TodoListsProxy()
		{
			_todoListFactory = new TodoListsFactory();
			_todoLists = new Dictionary<string, ITodoList>();
		}

		public IReadOnlyList<string> GetNames() => _todoListFactory.GetNames();

		public ITodoList GetList(string key)
		{
			#region validation

			if (string.IsNullOrWhiteSpace(key))
				throw new ArgumentNullException(nameof(key));

			key = key.ToUpper();

			#endregion

			ITodoList list;

			if (!_todoLists.ContainsKey(key))
			{
				list = _todoListFactory.GetList(key);
				_todoLists.Add(key, list);
			}
			else
			{
				list = _todoLists[key];
			}

			return list;
		}

		public int MaxCount => _todoListFactory.MaxCount;
	}
}
