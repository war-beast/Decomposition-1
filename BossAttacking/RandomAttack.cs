using System;
using BossAttacking.Interfaces;

namespace BossAttacking
{
	public class RandomAttack : IAttackSequence
	{
		public Attack GetNextAttack(IAttackFactory attacks) => attacks.GetAttack(GetRandomFromZero(attacks.Count));

		private int GetRandomFromZero(int upperBoundary) => DateTime.Now.Millisecond % upperBoundary;
	}
}
