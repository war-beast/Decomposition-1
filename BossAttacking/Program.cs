using System;
using System.Threading;

namespace BossAttacking
{
	class Program
	{
		static void Main(string[] args)
		{
			ShowActionMessage("Босс может атаковать в двух режимах: все атаки по очереди и случайной атакой", ConsoleColor.Yellow);

			var Health = 1000;
			var Armor = 20;

			var isRandomAttack = (DateTime.Now.Millisecond % 2) == 0;

			ShowActionMessage("Босс будет атаковать: " + (isRandomAttack ? "случайно" : "все атаки по очереди"), ConsoleColor.Yellow);

			ShowActionMessage("Нажмите enter для начала боя", ConsoleColor.Green);
			Console.ReadLine();

			var attackNumber = 0;
			while (Health > 0)
			{
				Console.Clear();
				ShowActionMessage($"У вас здоровья: {Health}", ConsoleColor.Red);

				if (isRandomAttack)
				{
					int rand = DateTime.Now.Millisecond % 3;
					if (rand == 0)
					{
						ShowActionMessage("Босс атаковал с немыслимой яростью своими руками", ConsoleColor.DarkRed);

						Health = Health - (100 - Armor);
					}
					else if (rand == 1)
					{
						ShowActionMessage("Босс исполнил новый альбом Ольги Бузовой", ConsoleColor.DarkMagenta);

						Health = Health - (140 - Armor);
					}
					else if (rand == 2)
					{
						ShowActionMessage("Босс приуныл и рассказал вам о своём долгом пути и дал пару советов, после выпил ритуальный стопарь боярки", ConsoleColor.DarkGray);

						Health = Health - (80 - Armor);
					}
				}
				else
				{
					if (attackNumber == 0)
					{
						ShowActionMessage("Босс атаковал с немыслимой яростью своими руками", ConsoleColor.DarkRed);

						Health = Health - (100 - Armor);
					}
					else if (attackNumber == 1)
					{
						ShowActionMessage("Босс исполнил новый альбом Ольги Бузовой", ConsoleColor.DarkMagenta);

						Health = Health - (140 - Armor);
					}
					else if (attackNumber == 2)
					{
						ShowActionMessage("Босс приуныл и рассказал вам о своём долгом пути и дал пару советов, после выпил ритуальный стопарь боярки", ConsoleColor.DarkGray);

						Health = Health - (80 - Armor);
					}

					attackNumber += 1;
					if (attackNumber > 2)
					{
						attackNumber = 0;
					}
				}

				Thread.Sleep(4000);
			}

			ShowActionMessage("Бой закончен, вы погибли", ConsoleColor.DarkGray);
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
