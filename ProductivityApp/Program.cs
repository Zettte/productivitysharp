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
					Console.Write(@"
					______              _            _   _       _ _             _                      
					| ___ \            | |          | | (_)     (_| |           | |                     
					| |_/ _ __ ___   __| |_   _  ___| |_ ___   ___| |_ _   _ ___| |__   __ _ _ __ _ __  
					|  __| '__/ _ \ / _` | | | |/ __| __| \ \ / | | __| | | / __| '_ \ / _` | '__| '_ \ 
					| |  | | | (_) | (_| | |_| | (__| |_| |\ V /| | |_| |_| \__ | | | | (_| | |  | |_) |
					\_|  |_|  \___/ \__,_|\__,_|\___|\__|_| \_/ |_|\__|\__, |___|_| |_|\__,_|_|  | .__/ 
											    __/ |                    | |    
											   |___/                     |_|       
					
					_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ 

					[ 1 ] Tasks.

					[ 2 ] Pomodoro.

					[ 3 ] Exit.

					Select an option:  ");

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
					Console.Write(@"
							  	       _____         _        
								      |_   _|       | |       
									| | __ _ ___| | _____ 
									| |/ _` / __| |/ / __|
									| | (_| \__ |   <\__ \
									\_/\__,_|___|_|\_|___/
					_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ 


					[ 1 ] Add a new task.

					[ 2 ] Delete all my tasks.

					[ 3 ] See all my tasks.

					[ 4 ] Return to main menu.

					Select an option:  ");
				
				}while( !int.TryParse(Console.ReadLine(), out Option) || Option < 1 || Option > 4);

				bool Back = false;

				switch(Option)
				{
					case 1:
						string? TaskName = String.Empty, Description = String.Empty;
						DateTime Date = DateTime.Now;
						
						Console.Write("\n\t\t\t\tPlease, enter the requested data below.\n\t\t\t\t[ Task name ]: ");
						TaskName = Console.ReadLine();
						
						Console.Write("\t\t\t\t[ Task description ]: ");
						Description = Console.ReadLine();

						Console.Write("\t\t\t\t[ Date to perform it ] (Format: mm/dd/yyyy): ");
						bool Convert = DateTime.TryParse(Console.ReadLine(), out Date);

						try
						{
							if(Date == null || Description == null || TaskName == null)
							{
								throw new NullReferenceException();
							}
						} catch(NullReferenceException e)
						{
							Console.WriteLine($"NullReferenceException {e}");
							Environment.Exit(1);
						}

						_Task.AddTask(TaskName, Description, Date);

						Console.WriteLine();
						break;
					case 2:

						Console.Write("\t\t\t\tAre you sure do you want to delete all your tasks? [Y/N]: ");
						string? Desition = Console.ReadLine();

						if(!String.IsNullOrEmpty(Desition))
						{
							if(Desition == "Y")
							{
								_Task.DeleteAllTasks();
							}
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
			string? Option = String.Empty;

			do
			{
				Console.Clear();
				Console.Write(@"
								______                         _                 
								| ___ \                       | |                
								| |_/ ___  _ __ ___   ___   __| | ___  _ __ ___  
								|  __/ _ \| '_ ` _ \ / _ \ / _` |/ _ \| '__/ _ \ 
								| | | (_) | | | | | | (_) | (_| | (_) | | | (_) |
								\_|  \___/|_| |_| |_|\___/ \__,_|\___/|_|  \___/ 
					_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ 

					[ * ] You're going to start pomodoro. How many minutes do you want to stay focused?
					
					Minutes:  ");

				bool Convert = int.TryParse(Console.ReadLine(), out Minutes);

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
