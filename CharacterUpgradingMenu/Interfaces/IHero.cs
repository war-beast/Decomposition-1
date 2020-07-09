using System.Collections.Generic;
using CharacterUpgradingMenu.ConcreteCharacteristics;

namespace CharacterUpgradingMenu.Interfaces
{
	public interface IHero
	{
		Dictionary<string, CharacteristicBase> Characteristics { get; }

		void ShowUpdatedState();

		void SetAge(int amount);
	}
}
