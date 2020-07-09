using CharacterUpgradingMenu.Interfaces;
using System;
using CharacterUpgradingMenu.Common;

namespace CharacterUpgradingMenu
{
	public class PointsKeeper : IPointsKeeper
	{
		private int _value;

		public PointsKeeper(int value)
		{
			_value = value;
		}

		public int Balance => _value;

		public void TransferToHero(IHero hero, string characteristicName, int amount)
		{
			#region validation

			if(hero == null)
				throw new ArgumentNullException(nameof(hero));

			characteristicName = characteristicName?.ToUpper();

			if (string.IsNullOrEmpty(characteristicName) ||
			    hero.Characteristics.ContainsKey(characteristicName) == false)
			{
				return;
			}

			#endregion

			UpdateCharacteristic(hero.Characteristics[characteristicName], amount);
		}

		#region private methods

		private void UpdateCharacteristic(ICharacteristic characteristic, int amount)
		{
			if (amount > _value)
				amount = _value;

			_value -= amount;

			characteristic.NotifyOverhead += Characteristic_NotifyOverhead;
			characteristic.Update(amount);
			characteristic.NotifyOverhead -= Characteristic_NotifyOverhead;
		}

		private void Characteristic_NotifyOverhead(object sender, EventArgs e)
		{
			if (e is CharacteristicEvenArgs overhead) 
				_value += overhead.Overhead;
		}

		#endregion
	}
}
