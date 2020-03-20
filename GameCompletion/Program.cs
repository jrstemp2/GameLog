using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Threading;

namespace GameCompletion
{

    class Program
    {
        static void Main(string[] args)
        {
            int choice;

            string fileLocation = Directory.GetCurrentDirectory() + @"\GameInfo.txt";
            BackLog bl1 = new BackLog();
           
            List<string> gameslist1 = File.ReadAllLines(fileLocation).ToList();
            foreach (string record in gameslist1)
            {
                string[] records = record.Split(',');

                bl1.ReadTextList(new Game(int.Parse(records[0]), records[1], records[2], records[3], int.Parse(records[4]), records[5]));
            }
            List<string> output = new List<string>();
            
            
            //------------SplashScreen------------//
            CoolLogo();
            Loading();
            

            do
            {
                Console.WriteLine("Welcome to the Game Room.");
                Console.WriteLine();
                MainMenu();
                Console.WriteLine();
                choice = Worked("What would you like to do? >>> ");

                if (choice == 1)
                {
                    Console.Clear();
                    if (bl1.GameLog.Count == 0)
                    {
                        Console.WriteLine("Your Back Log is Empty.");
                        Console.WriteLine("Please Press ENTER to Return to the Main Menu");
                        Console.ReadLine();
                    }
                    else
                    {
                        bl1.PrintGameList();
                        Console.WriteLine("Please Press ENTER to return to the Main Menu");
                        Console.ReadLine();
                    }
                    Console.Clear();
                }
                else if (choice == 2)
                {
                    Console.Clear();
                    bl1.AddGame(bl1.AddGameMenu());
                    Console.Clear();
                }
                else if (choice == 3)
                {
                    Console.Clear();
                    bl1.PrintGameList();
                    Console.WriteLine();
                    Console.WriteLine();

                    Console.Write("Please Enter the ID of the Game you want to REMOVE: ");
                    int input = int.Parse(Console.ReadLine());
                    bl1.RemoveGame(input);
                }

                else if (choice == 4)
                {

                    EditMenu();
                }

                else if (choice == 5)
                {
                    Console.WriteLine("Save");

                    foreach (Game g in bl1.GameLog)
                    {
                        output.Add($"{g.Id},{g.Title},{g.Genre},{g.Console},{g.NumPlayers},{g.Status}");
                    }
                    Console.WriteLine("Writing");

                    File.WriteAllLines(fileLocation, output);
                    Console.WriteLine("Done");
                    Console.ReadLine();
                    Console.Clear();
                }
                
                else if (choice == 6)
                {
                    Console.WriteLine("Thank you for your time. Please press ENTER to exit the program...");
                    Console.ReadLine();
                }
                
                else
                {
                    Console.WriteLine("That is not a valid response. Please press ENTER to Try Again");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }   
            } while (choice != 6);
        }

        static void MainMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1. View Library");
            Console.WriteLine("2. Add a Game");
            Console.WriteLine("3. Remove a Game");
            Console.WriteLine("4. Update a Status");
            Console.WriteLine("5. Save");
            Console.WriteLine("6. Quit");
        }
        
        static int Worked(string s)
        {
            int input;
            bool worked;
            do
            {
                Console.Write("What Would You Like To Do? ");
                worked = Int32.TryParse(Console.ReadLine(), out input);
                if (worked == false)
                {
                    Console.WriteLine("That is not a number. ");
                    //Console.ReadLine();
                    //Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 2);
                    continue;
                }
                else
                {
                    break;
                }
            } while (worked == false);
            return input;
        }
        static void Logo()
        {
            Console.WriteLine(@"                             _____");
            Console.WriteLine(@"			    |     |");
            Console.WriteLine(@"			    |     |");
            Console.WriteLine(@"			    |     |");
            Console.WriteLine(@"			    |     |");
            Console.WriteLine(@"			    |     |");
            Console.WriteLine(@"			    |     |");
            Console.WriteLine(@"			    |     |");
            Console.WriteLine(@"			    |     |");
            Console.WriteLine(@"			    |     |");
            Console.WriteLine(@"			    |     |");
            Console.WriteLine(@"	       ____         |     | ");
            Console.WriteLine(@"	    __/____\______/\|_____|/\______________    ");
            Console.WriteLine(@"           /             /-----------\             \  ");
            Console.WriteLine(@"           \_______________________________________/");
            Console.WriteLine(@"            \_____________________________________/");
            Console.WriteLine(@"             |___________THE GAMES ROOM__________|");
            Console.WriteLine(@"             |___________________________________|");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press ANY KEY to Start");
        }
        static void Loading()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < 101; i++)
            {
                Console.WriteLine($"Loading Library: <---{i}%--->");
                Thread.Sleep(25);
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
            }
            Console.WriteLine("Load Complete. Press ENTER to view entire list of Movies.");
            Console.ReadLine();
            Console.Clear();
        }

        static void CoolLogo()
        {
            while (!Console.KeyAvailable)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Logo();
                Thread.Sleep(200);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Logo();
                Thread.Sleep(200);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Logo();
                Thread.Sleep(200);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Logo();
                Thread.Sleep(200);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Logo();
                Thread.Sleep(200);
                Console.Clear();
            }
            Console.Clear();
        }
        static void EditMenu()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Edit a Record");
            Console.WriteLine("=============");
            Console.ReadLine();
        }

    }
}
