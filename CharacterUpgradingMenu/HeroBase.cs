using System;
using System.Collections.Generic;
using CharacterUpgradingMenu.ConcreteCharacteristics;
using CharacterUpgradingMenu.Interfaces;

namespace CharacterUpgradingMenu
{
	public abstract class HeroBase : IHero
	{
		#region private members

		private ICharacteristic _strength;
		private ICharacteristic _agility;
		private ICharacteristic _intelligence;
		private ICharacteristic _age;

		#endregion

		public Dictionary<string, ICharacteristic> Characteristics { get; }

		protected HeroBase()
		{
			_strength = new Strength();
			_agility = new Agility();
			_intelligence = new Intelligence();
			_age = new Age();

			Characteristics = new Dictionary<string, ICharacteristic>
			{
				{ _strength.Name.ToUpper(), _strength },
				{ _agility.Name.ToUpper(), _agility },
				{ _intelligence.Name.ToUpper(), _intelligence },
				{ _age.Name.ToUpper(), _age }
			};
		}

		public void ShowUpdatedState()
		{
			Console.Clear();
			Console.WriteLine(GetInfo());
		}

		public void SetAge(int amount)
		{
			Characteristics[_age.Name.ToUpper()].Update(amount);
		}

		#region private methods

		private string GetInfo()
		{
			var strengthVisual = ReloadCharacteristics(Characteristics[_strength.Name.ToUpper()].Value);
			var agilityVisual = ReloadCharacteristics(Characteristics[_agility.Name.ToUpper()].Value);
			var intelligenceVisual = ReloadCharacteristics(Characteristics[_intelligence.Name.ToUpper()].Value);
			var ageVisual = Characteristics[_age.Name.ToUpper()].Value;
			return $"Возраст - {ageVisual}\nСила - [{strengthVisual}]\nЛовкость - [{agilityVisual}]\nИнтеллект - [{intelligenceVisual}]";
		}

		private static string ReloadCharacteristics(int value)
		{
			var result = string.Empty;
			return result.PadLeft(value, '#').PadRight(10, '_');
		}

		#endregion
	}
}
