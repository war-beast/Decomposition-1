namespace BossAttacking.Interfaces
{
	public interface IPlayer
	{
		void Hit(IAttackPower attackPower);

		int GetHealth();
	}
}
