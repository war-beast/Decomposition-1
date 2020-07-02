using BossAttacking.Interfaces;

namespace BossAttacking
{
	public class SerialAttack : IAttackSequence
	{
		private int _currentAttackNumber;

		public SerialAttack()
		{
			_currentAttackNumber = 0;
		}

		public Attack GetNextAttack(IAttackFactory attacks) => attacks.GetAttack(_currentAttackNumber++ % attacks.Count);
	}
}
