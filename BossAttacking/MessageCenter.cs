using System;

namespace BossAttacking
{
	internal class MessageCenter
	{
		public static void ShowMessage(string message, ConsoleColor textColor)
		{
			var oldColor = Console.ForegroundColor;
			Console.ForegroundColor = textColor;
			Console.WriteLine(message);
			Console.ForegroundColor = oldColor;
		}
	}
}
