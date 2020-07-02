namespace BossAttacking.Interfaces
{
	public interface IAttackFactory
	{
		Attack GetAttack(int id);
		int Count { get; }
	}
}
