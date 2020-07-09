namespace CharacterUpgradingMenu.ConcreteCharacteristics
{
	public class Age : CharacteristicBase
	{
		private const int MaxAge = 100;

		public Age()
		{
			Name = "Возраст";
			ResetMaximum(MaxAge);
		}
	}
}
