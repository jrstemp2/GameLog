using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCompletion
{
    public class BackLog
    {
        private List<Game> gameLog;

        internal List<Game> GameLog { get => gameLog; set => gameLog = value; }

        public BackLog()
        {
            this.gameLog = new List<Game>();
        }


        //------------------Add Game Methods------------------//
        public int GenerateID()
        {
            Random num = new Random();
            int id = num.Next(10000,99999);
            return id;
        }
        public Game AddGameMenu()
        {
            bool duplicate;
            int id;
            Game game;

            do
            {
                id = GenerateID();
                Console.WriteLine("Please Enter the following details:");
                Console.WriteLine();
                string title = ValidateInput("GAME TITLE: ").ToUpper();
                string genre = ValidateInput("GAME GENRE: ").ToUpper();
                string console = ValidateInput("GAME CONSOLE: ").ToUpper();
                int numPlayers = IntValidateInput("GAME NUMBER OF PLAYERS: ");
                string status = ValidateInput("COMPLETION STATUS: ").ToUpper();

                game = new Game(id, title, genre, console, numPlayers, status);
                duplicate = CheckGame(game);

                if (duplicate == true)
                {
                    Console.WriteLine("That game already exists for that console. Please press ENTER to Try again:");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }
                else
                {
                    break;
                }
                
            } while (duplicate == true);
            //Game game = new Game(id, title, genre, console, numPlayers, status);
            return game;

        }
        public void AddGame(Game g)
        {
            gameLog.Add(g);
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("You have added a Game.");
            Console.WriteLine(String.Format("{0,0} {1,35} {2,25} {3,25} {4,11} {5,10}", "| ID |", "| TITLE |", "| GENRE |", "| CONSOLE |", "| PLAYERS |", "| STATUS |"));
            Console.WriteLine("=====================================================================================================================");
            Console.WriteLine(ColorCode(g));
            Console.WriteLine();
            Console.WriteLine("Please Press ENTER to return to the Main Menu");
            Console.ReadLine();
        }
        public void PrintGameList()
        {
            Console.WriteLine(String.Format("{0,0} {1,35} {2,25} {3,25} {4,11} {5,10}", "| ID |", "| TITLE |", "| GENRE |", "| CONSOLE |", "| PLAYERS |", "| STATUS |"));
            
            foreach (Game g in gameLog)
            {
                Console.WriteLine("=====================================================================================================================");
                
                Console.WriteLine(ColorCode(g));
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.WriteLine();
        }

        public string ValidateInput(string s)
        {
            string input;
            do
            {
                Console.WriteLine(s);
                input = Console.ReadLine();
            } while (String.IsNullOrWhiteSpace(input));
            return input;
        }
        public int IntValidateInput(string s)
        {
            int input;
            bool worked;
            do
            {
                Console.WriteLine(s);
                worked = Int32.TryParse(Console.ReadLine(), out input);
            } while (worked == false);
            return input;
        }

        public void ReadTextList(Game g)
        {
            gameLog.Add(g);
        }
        public void RemoveGame(int input)
        {

            int myIndex = GameLog.FindIndex(g => g.Id == input);
            Console.WriteLine(myIndex);
            Console.ReadLine();

            if (myIndex >= 0)
            {
                for (int i = 0; i < GameLog.Count; i++)
                {
                    if (GameLog[i].Id == input)
                    {
                        GameLog.Remove(GameLog[i]);
                    }
                }
            }
            else
            {
                Console.WriteLine("That Record does not Exist. Please press ENTER to Try Again.");
            }
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("The Game has been removed.");
            Console.ReadLine();
        }

        public bool CheckGame(Game g)
        {
            

            for (int i = 0; i < GameLog.Count; i++)
            {
                if ((GameLog[i].Title == g.Title) && (GameLog[i].Console == g.Console))
                {
                    return true;
                }
                
            }
            
            return false;
        }

        public Game ColorCode(Game g)
        {

            if (g.Genre == "ACTION")
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (g.Genre == "RPG")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            else 
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            return g;
        }


    }
}
