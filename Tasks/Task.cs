using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace Tasks
{
	public class _Task
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public DateTime Date { get; set; }
		public bool Done { get; set; }

		private static int TempId = 1;
		// Using CsvHelper to add a row in the task.csv file.

		public static void AddTask(string name, string desc, DateTime date, bool done = false)
		{
			var Records = new List<_Task>
			{
				new _Task {Id = TempId, Name = name, Description = desc, Date = date, Done = done}
			};
				
			// If you want to modify the path, make sure that is correctly typed and the folder contains a csv file.

			using (var Writer = new StreamWriter(@"../ProductivityApp/task.csv"))
			using (var Csv = new CsvWriter(Writer, CultureInfo.InvariantCulture))
			{
				Csv.WriteRecords(Records);
			}

			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Task added succesfully!");
			Console.ResetColor();

			TempId++;
		}

		// In this method, we pull all of the records into memory and then write 'em back to the file.

		public static void DeleteTask(int RemoveId)
		{
			List<_Task> Records;

			using (var Reader = new StreamReader(@"../ProductivityApp/task.csv"))
			using (var Csv = new CsvReader(Reader, CultureInfo.InvariantCulture))
			{
				Records = Csv.GetRecords<_Task>().ToList();

				for(int i = 0 ; i < Records.Count ; ++i)
				{
					if( Records[i].Id ==  RemoveId)
					{
						Records.RemoveAt(i);
					}
				}
			}

			using (var Writer = new StreamWriter(@"../ProductivityApp/task.csv"))
			using (var CsvWriter = new CsvWriter(Writer, CultureInfo.InvariantCulture))
			{
				CsvWriter.WriteRecords(Records);
			}

			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("Your task was deleted succesfully.");
			Console.ResetColor();
		}
		
		public static void ReadTask()
		{ 
			string[] AllTasks = File.ReadAllLines(@"../ProductivityApp/task.csv");
			Console.WriteLine("Your current tasks are: ");
			foreach(string Line in AllTasks)
			{
				if(Line != "Id,Name,Description,Date,Done")
					Console.WriteLine($"\t{Line}");
			}
		}
	}
}
