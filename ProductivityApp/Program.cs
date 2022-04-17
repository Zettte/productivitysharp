using Pomodoro; 
using Tasks;

namespace Productivity
{
	class Program
	{
		static void MainMenu()
		{
			while(true)
			{
				int Option;

				do
				{
					Console.Clear();
					Console.WriteLine("\t.----------------.\n\t| Productity App |\n\t.----------------.");

					Console.WriteLine("\n\tSelect an option. \n\t[ 1 ] Tasks.\n\t[ 2 ] Pomodoro. \n\t[ 3 ] Exit.\n");
					Console.Write("Option: ");

				} while( !int.TryParse(Console.ReadLine(), out Option) || Option < 1 || Option > 3);

				Console.Clear();

				switch(Option)
				{
					case 1: 
						TaskMenu();
						break;
					case 2:
						PomodoroMenu();
						break;
					case 3:
						Environment.Exit(0);
						break;
					default:
						Console.WriteLine("Oops, tha's not a valid option.");
						break;
				}
			}	
		}

		static void TaskMenu()
		{
			Console.Clear();
			while(true)
			{
				int Option;

				do
				{

					Console.WriteLine("\t.----------------.\n\t Tasks Menu \n\t.----------------.");

					Console.WriteLine("\n\tSelect and option. \n\t[ 1 ] Add task.\n\t[ 2 ] Delete task. \n\t[ 3 ] See all my tasks.\n\t[ 4 ] Return to main menu.\n");
					Console.Write("Option: ");
				
				}while( !int.TryParse(Console.ReadLine(), out Option) || Option < 1 || Option > 4);

				bool Back = false;

				switch(Option)
				{
					case 1:
						string TaskName = String.Empty, Description = String.Empty;
						DateTime Date = DateTime.Now;
						
						Console.Write("\nPlease, enter the requested data below.\n[ Task name ]: ");
						TaskName = Console.ReadLine();
						
						Console.Write("[ Task description ]: ");
						Description = Console.ReadLine();

						Console.Write("[ Date to perform it ] (Format: mm/dd/yyyy): ");
						Date = DateTime.Parse(Console.ReadLine());

						_Task.AddTask(TaskName, Description, Date);

						Console.WriteLine();
						break;
					case 2:

						Console.Write("Are you sure do you want to delete all your tasks? [Y/N]: ");
						string Desicion = Console.ReadLine();
						if(Desicion == "Y")
						{
							_Task.DeleteAllTasks();
						}

						break;
					case 3:
						_Task.ReadTask();
						break;
					case 4:
						Back = true;
						break;
				}

				if(Back) return;
			}
		}

		static void PomodoroMenu()
		{
			int Minutes = 1;
			string Option = String.Empty;

			do
			{
				Console.Clear();
				Console.WriteLine("\t.----------------.\n\t| Pomodoro |\n\t.----------------.");

				Console.Write("\nHow many mimutes do you want to stay focused? Wehn the time has finished you will have a 5 minutes break: ");

				Minutes = int.Parse(Console.ReadLine());

				PomodoroTimer.Timer(Minutes);
				PomodoroTimer.Timer(5);
			
				Console.Write("Do you want to continue?[Y/N]: ");
				Option = Console.ReadLine();

			} while(Option != "N");
		}


		static void Main(string[] args)
		{
			MainMenu();
		}

	}
}
