namespace Pomodoro
{
	public class PomodoroTimer
	{
		public static void Timer(int Minutes)
		{
			int Seconds = 1;
			
			while(Minutes >= 0 && Seconds > 0)
			{
				Seconds--;
				if (Seconds == 0)
				{
					Minutes--;
					Seconds += 59;

					if (Minutes == -1)
						break;
				}
				
				string Time = ( Minutes < 10 && Seconds < 10 )? $"0{Minutes}:0{Seconds}" : ( Minutes < 10 )? $"0{Minutes}:{Seconds}" : $"{Minutes}:{Seconds}";

				Console.Clear();
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine($@"	Pomodoro Timer

	.---------.
	|  {Time}  |
	.---------.
	");
			Thread.Sleep(1000);
			}

			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("\n\tPomodoro has stoped!\n");
			Console.ForegroundColor = ConsoleColor.White;
		}
	}
}
