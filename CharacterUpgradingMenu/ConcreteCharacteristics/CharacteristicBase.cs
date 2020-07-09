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
			Value += amount;
			if (Value > Max)
			{
				OnOverhead(new CharacteristicEvenArgs { Overhead = Value - Max });
				Value = Max;
			}
			else if (Value < Min)
			{
				OnOverhead(new CharacteristicEvenArgs { Overhead = Min - Value});
				Value = Min;
			}
		}

		protected virtual void OnOverhead(EventArgs args)
		{
			NotifyOverhead?.Invoke(this, args);
		}

		protected void ResetMaximum(int max)
		{
			Max = max;
		}
	}
}
