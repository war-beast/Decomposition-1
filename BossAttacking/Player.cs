using BossAttacking.Interfaces;

namespace BossAttacking
{
	public class Player : IPlayer
	{
		private int _health;
		private readonly int _armor;

		public Player(int health = 100, int armor = 20)
		{
			_health = health;
			_armor = armor;
		}

		public void Hit(IAttackPower attackPower)
		{
			_health -= (attackPower.Damage - _armor);
		}

		public int GetHealth()
		{
			return _health;
		}
	}
}
