namespace CharacterUpgradingMenu.Interfaces
{
	public interface IPointsKeeper
	{
		int Balance { get; }

		/// <summary>
		/// Передать поинты персонажу 
		/// </summary>
		/// <param name="hero">Персонаж, получающий поинты</param>
		/// <param name="characteristicName">Характеристика для прокачки</param>
		/// <param name="amount">Количество поинтов</param>
		void TransferToHero(IHero hero, string characteristicName, int amount);
	}
}