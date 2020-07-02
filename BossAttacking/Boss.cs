using BossAttacking.Interfaces;
using System;

namespace BossAttacking
{
	public class Boss : IBoss
	{
		private readonly IAttackSequence _attackSequence;
		private readonly IAttackFactory _attackFactory;

		public Boss(IAttackSequence attackSequence)
		{
			_attackSequence = attackSequence ?? throw new ArgumentNullException(nameof(attackSequence));
			_attackFactory = new AttackFactory();
		}

		public void AttackPlayer(IPlayer player)
		{
			var attack = _attackSequence.GetNextAttack(_attackFactory);
			MessageCenter.ShowMessage(attack.Message, attack.TextColor);
			player.Hit(attack);
		}
	}
}
