using BossAttacking.Interfaces;
using System;
using System.Collections.Generic;

namespace BossAttacking
{
	public class AttackFactory : IAttackFactory
	{
		private readonly Dictionary<int, Attack> _attacks = new Dictionary<int, Attack>();

		public AttackFactory()
		{
			_attacks.Add(0, new Attack("Босс атаковал с немыслимой яростью своими руками", 100, ConsoleColor.DarkRed));
			_attacks.Add(1, new Attack("Босс исполнил новый альбом Ольги бузовой", 140, ConsoleColor.DarkMagenta));
			_attacks.Add(2, new Attack("Босс приуныл и рассказал вам о своём долгом пути и дал пару советов, после выпил ритуальный стопарь боярки", 80,
				ConsoleColor.DarkGray));
		}

		public Attack GetAttack(int id)
		{
			return _attacks.ContainsKey(id) 
				? _attacks[id] 
				: throw new IndexOutOfRangeException(nameof(id));
		}

		public int Count => _attacks.Count;
	}
}
