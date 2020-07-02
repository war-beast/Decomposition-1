using System;
using BossAttacking.Interfaces;

namespace BossAttacking
{
	public class Attack : IAttackPower
	{
		public string Message { get; private set; }
		public int Damage { get; private set; }
		public ConsoleColor TextColor { get; private set; }

		public Attack(string message, int damage, ConsoleColor textColor)
		{
			Message = message ?? throw new ArgumentNullException(nameof(message));
			Damage = damage;
			TextColor = textColor;
		}
	}
}
