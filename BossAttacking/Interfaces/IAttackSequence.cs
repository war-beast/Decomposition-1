namespace BossAttacking.Interfaces
{
	public interface IAttackSequence
	{
		Attack GetNextAttack(IAttackFactory attacks);
	}
}
