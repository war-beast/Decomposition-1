using System;
using System.Threading;
using BossAttacking.Interfaces;

namespace BossAttacking
{
	class Program
	{
		static void Main(string[] args)
		{
			MessageCenter.ShowMessage("Босс может атаковать в двух режимах: все атаки по очереди и случайной атакой", ConsoleColor.Yellow);

			var player = new Player(health: 1000, armor: 20);

			var isRandomAttack = (DateTime.Now.Millisecond % 2) == 0;
			var attackSequence = isRandomAttack 
				? (IAttackSequence) new RandomAttack() 
				: new SerialAttack();

			var boss = new Boss(attackSequence);

			MessageCenter.ShowMessage("Босс будет атаковать: " + (isRandomAttack ? "случайно" : "все атаки по очереди"), ConsoleColor.Yellow);

			MessageCenter.ShowMessage("Нажмите enter для начала боя", ConsoleColor.Green);
			Console.ReadLine();

			while (player.GetHealth() > 0)
			{
				Console.Clear();
				MessageCenter.ShowMessage($"У вас здоровья: {player.GetHealth()}", ConsoleColor.Red);

				boss.AttackPlayer(player);

				Thread.Sleep(4000);
			}

			MessageCenter.ShowMessage("Бой закончен, вы погибли", ConsoleColor.DarkGray);
		}
	}
}
