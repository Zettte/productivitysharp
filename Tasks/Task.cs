using System.Globalization;

namespace Tasks
{
	public class _Task
	{
		public static void AddTask(string Name, string Description, DateTime Date, bool Done = false)
		{

			string done = ( Done == false ) ? "Not done yet" : "Done";
			string TaskInfo = Name + ", " + Description + ", " + Date.ToString() + ", " + done; 

			using StreamWriter File = new ($@"..{Path.DirectorySeparatorChar}ProductivityApp{Path.DirectorySeparatorChar}tasks.txt", append:true);
			File.WriteLine(TaskInfo);

			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Task added succesfully!");
			Console.ResetColor();
		}

		public static void DeleteAllTasks()
		{
			File.Delete($@"..{Path.DirectorySeparatorChar}ProductivityApp{Path.DirectorySeparatorChar}tasks.txt");

			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("Your tasks were deleted succesfully.");
			Console.ResetColor();

			File.Create($@"..{Path.DirectorySeparatorChar}ProductivityApp{Path.DirectorySeparatorChar}tasks.txt");
		}
		
		public static void ReadTask()
		{ 
			if( new FileInfo($@"..{Path.DirectorySeparatorChar}ProductivityApp{Path.DirectorySeparatorChar}tasks.txt").Length == 0)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Please add some tasks.");
				Console.ResetColor();
			}
			else
			{
				string[] AllTasks = File.ReadAllLines($@"..{Path.DirectorySeparatorChar}ProductivityApp{Path.DirectorySeparatorChar}tasks.txt");
			
				Console.Clear();
				Console.WriteLine("Your current tasks are: ");
				foreach(string Line in AllTasks)
				{
					Console.WriteLine($"\t{Line}");
				}
				Console.WriteLine();
			}
		}
	}
}
