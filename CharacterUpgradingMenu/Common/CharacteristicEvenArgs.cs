using System;

namespace CharacterUpgradingMenu.Common
{
	public class CharacteristicEvenArgs : EventArgs
	{
		public int Overhead { get; set; }

		public int Processed { get; set; }
	}
}
