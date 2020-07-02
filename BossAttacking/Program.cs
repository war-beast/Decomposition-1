using System;
using System.Threading;

namespace BossAttacking
{
	class Program
	{
		const int Armor = 20;

		static void Main(string[] args)
		{
			ShowActionMessage("Босс может атаковать в двух режимах: все атаки по очереди и случайной атакой", ConsoleColor.Yellow);

			var Health = 1000;

			var isRandomAttack = (DateTime.Now.Millisecond % 2) == 0;

			ShowActionMessage("Босс будет атаковать: " + (isRandomAttack ? "случайно" : "все атаки по очереди"), ConsoleColor.Yellow);

			ShowActionMessage("Нажмите enter для начала боя", ConsoleColor.Green);
			Console.ReadLine();

			var attackNumber = 0;
			while (Health > 0)
			{
				Console.Clear();
				ShowActionMessage($"У вас здоровья: {Health}", ConsoleColor.Red);

				var attackType = isRandomAttack
					? DateTime.Now.Millisecond % 3
					: attackNumber++ % 3;

				Health = SwitchBossAttack(attackType, Health);

				Thread.Sleep(4000);
			}

			ShowActionMessage("Бой закончен, вы погибли", ConsoleColor.DarkGray);
		}

		private static int SwitchBossAttack(int attackType, int health)
		{
			switch (attackType)
			{
				case 0:
					ShowActionMessage("Босс атаковал с немыслимой яростью своими руками", ConsoleColor.DarkRed);
					return health - (100 - Armor);
				case 1:
					ShowActionMessage("Босс исполнил новый альбом Ольги бузовой", ConsoleColor.DarkMagenta);
					return health - (140 - Armor);
				case 2:
					ShowActionMessage(
						"Босс приуныл и рассказал вам о своём долгом пути и дал пару советов, после выпил ритуальный стопарь боярки",
						ConsoleColor.DarkGray);
					return health - (80 - Armor);
			}

			return health;
		}

		private static void ShowActionMessage(string message, ConsoleColor textColor)
		{
			ConsoleColor oldColor = Console.ForegroundColor;
			Console.ForegroundColor = textColor;
			Console.WriteLine(message);
			Console.ForegroundColor = oldColor;
		}
	}
}
