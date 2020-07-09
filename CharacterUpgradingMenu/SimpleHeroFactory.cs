using CharacterUpgradingMenu.Interfaces;

namespace CharacterUpgradingMenu
{
	public class SimpleHeroFactory : IHeroFactory
	{
		public IHero Create()
		{
			return new SimpleHero();
		}
	}
}
