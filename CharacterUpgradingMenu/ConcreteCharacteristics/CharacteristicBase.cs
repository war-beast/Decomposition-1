using CharacterUpgradingMenu.Interfaces;
using System;
using CharacterUpgradingMenu.Common;

namespace CharacterUpgradingMenu.ConcreteCharacteristics
{
	public abstract class CharacteristicBase : ICharacteristic
	{
		#region private membrers

		protected virtual int Max { get; private set; }
		private const int Min = 0;

		#endregion

		public int Value { get; private set; }

		public string Name { get; protected set; }

		public event EventHandler NotifyOverhead;

		#region constructor

		protected CharacteristicBase()
		{
			Value = 0;
			Max = 10;
		}

		#endregion

		public virtual void Update(int amount)
		{
			var newValue = Value + amount;
			if (newValue > Max)
			{
				OnOverhead(new CharacteristicEvenArgs { Overhead = newValue - Max, Processed = Max - Value });
				Value = Max;
			}
			else if (newValue < Min)
			{
				OnOverhead(new CharacteristicEvenArgs { Overhead = Min + newValue, Processed = Value - Min });
				Value = Min;
			}
			else
			{
				Value = newValue;
			}
		}

		protected virtual void OnOverhead(CharacteristicEvenArgs args)
		{
			NotifyOverhead?.Invoke(this, args);
		}

		protected void ResetMaximum(int max)
		{
			Max = max;
		}
	}
}
