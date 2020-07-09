using System;

namespace CharacterUpgradingMenu.Interfaces
{
	public interface ICharacteristic
	{
		int Value { get; }

		string Name { get; }

		/// <summary>
		/// Изменение значения характеристики
		/// </summary>
		/// <param name="amount">Целое число со знаком</param>
		void Update(int amount);

		/// <summary>
		/// Уведомление о выходе значения за пределы допустимых границ
		/// </summary>
		event EventHandler NotifyOverhead;
	}
}
