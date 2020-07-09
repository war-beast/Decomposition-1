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
			if (amount > _value)
				amount = _value;

			_value -= amount;

			var characteristic = hero.Characteristics[characteristicName.ToUpper()];
			characteristic.NotifyOverhead += Characteristic_NotifyOverhead;
			characteristic.Update(amount);
			characteristic.NotifyOverhead -= Characteristic_NotifyOverhead;
		}

		#region private methods

		private void Characteristic_NotifyOverhead(object sender, EventArgs e)
		{
			if (e is CharacteristicEvenArgs overhead) 
				_value += overhead.Overhead;
		}

		#endregion
	}
}
