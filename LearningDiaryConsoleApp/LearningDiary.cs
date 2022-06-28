using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

//pull request testikommentti
namespace LearningDiary
{
	public class Topic
	{

		private static string AsciiArt = @"
______________
||            ||
|| Johanna's  ||
||  learning  ||
||   diary    ||
||____________||
|______________|
 \\1234567890!?\\
  \\************\\
   \ ************ \   
    \_____\___\____\";
		public string path;
		
		public int Id { get; private set; }
		public string Title { get; private set; }
		public string Description { get; private set; }
		public string Source { get; private set; }
		public double EstimatedTimeToMaster { get; private set; }
		public DateTime StartLearningDate { get; set; }
		public DateTime CompletionDate { get; set; }

		public string Note { get; set; }
		public bool InProgress { get; private set; }
		private bool progress;
		public bool Progress
		{
			get
			{
				return progress;
			}
			set
			{
				progress = value;
				//tarkasta onko valmista vai ei
				InProgress = true;
				if (DateTime.Now != CompletionDate)
					InProgress = false;

			}
		}

		public Topic()
		{

		}
		public Topic(string title, string description, string source)
		{

		}

		public Topic(DateTime startLearningDate, DateTime completionDate, double estimatedTimeToMaster)
		{

		}

		public Topic(string path)
		{
			this.path = path;
		}
		static void PressKey()
		{

			Console.WriteLine("\nPress any key... ");
			Console.ReadKey();


		}
		public void StartTopic()
		{

			string path = @"C:\Users\Johanna\source\repos\LearningDiaryConsoleApp\MyLearningDiary.txt";
			if (File.Exists(path))
			{
				using StreamWriter sw = File.CreateText(path);

				Topic topics = new Topic();
				sw.WriteLine("Give a title for your project: ");
				topics.Title = Console.ReadLine();
				sw.WriteLine("Write a short description: ");
				topics.Description = Console.ReadLine();
				sw.WriteLine("Source material you are using: ");
				topics.Source = Console.ReadLine();
				sw.WriteLine("The time you are going to use for learning in hours, eg. 2,5 ");
				topics.EstimatedTimeToMaster = Convert.ToDouble(Console.ReadLine());
				sw.WriteLine("The date you start your project: ");
				topics.StartLearningDate = Convert.ToDateTime(Console.ReadLine());
				sw.WriteLine("The date you estimate you have learned this:  ");
				topics.CompletionDate = Convert.ToDateTime(Console.ReadLine());

			}

		}

		private void ShowStartMessage()
		{
			Console.WriteLine(AsciiArt);
			Console.WriteLine("\nWelcome to your learning diary.");
			Console.WriteLine("Here you can keep track of your learning process, check your time management, and write notes.");
			PressKey();
		}

		private void ShowEndMessage()
		{
			Console.Clear();
			Console.WriteLine(AsciiArt);
			Console.WriteLine("Hope you learned a lot. Have a nice day!");
			PressKey();
		}

		private void DisplayTopics()
		{
			string topicText = File.ReadAllText(path);
			Console.WriteLine("\n*****  Topics *****");
			Console.WriteLine(topicText);
			Console.WriteLine("\n******************");
			PressKey();
		}


		private void ShowDiaryTopics()
		{
			string choice = "";
            while (choice != "E")
			{
				Console.WriteLine(Environment.NewLine);
				Console.WriteLine("Choose an option:");
				Console.WriteLine("----------------------------\r");
				Console.WriteLine("1 - Start a new topic");
				Console.WriteLine("2 - Check your topics");
				Console.WriteLine("3 - Remove a topic");
				Console.WriteLine("4 - Follow your progress");
				Console.WriteLine("5 - Write a note");
				Console.WriteLine("E - Exit ");
				Console.WriteLine("----------------------------\r");
				Console.Write("\r\nSelect an option: ");
				choice = Console.ReadLine();

				switch (choice)
				{
					case "1":
						StartTopic();
						;
						break;
					case "2":
						DisplayTopics();
						break;
					case "3":
						//RemoveTopic();
						break;
					case "4":
						//FollowProgress();
						break;
					case "5":
						//WriteNote();
						break; ;
					case "E":
						break; ;
					default:
						Console.WriteLine("This is not valid option. Please choose again.");
						break;
				}
				Console.ReadKey();
			}
			
		}
		static void Main(string[] args)
		{
			Topic topic = new Topic();
			topic.ShowStartMessage();
			Console.WriteLine(Environment.NewLine);
			topic.ShowDiaryTopics();
			topic.DisplayTopics();

			topic.ShowEndMessage();
		}
	}
}


	/*
	static void ClearEntry()		//NÄMÄ EIVÄT NYT VIELÄ OIKEIN TOIMI TÄÄLLÄ...
	{

		string clearEntry = "   ";
		File.WriteAllText(string path, clearEntry);
		Console.WriteLine("\nEntry cleared!");
		PressKey();

	}
	static void AddEntry()
	{

		Console.WriteLine("\nWrite a note: ");
		string appendText = Console.ReadLine();
		File.WriteAllText(path, appendText + Environment.NewLine);       //HALUAISIN JOTENKIN MUOTOILLA TÄTÄ , ettei kaikki tule yhtenä pötkönä
		Console.WriteLine("The note has been saved");
		PressKey();

	}*/



	