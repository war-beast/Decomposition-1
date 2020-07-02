using BossAttacking.Interfaces;

namespace BossAttacking
{
	public class Player : IPlayer
	{
		private int _health;
		private int _armor;

		public Player(int health, int armor)
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
