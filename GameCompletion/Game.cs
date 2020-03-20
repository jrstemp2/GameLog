using System;
using System.Collections.Generic;
using System.Text;

namespace GameCompletion
{
    public class Game
    {
        private int id;
        private string title;
        private string genre;
        private string console;
        private int numPlayers;
        private string status;


        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public string Genre { get => genre; set => genre = value; }
        public string Console { get => console; set => console = value; }
        public int NumPlayers { get => numPlayers; set => numPlayers = value; }
        public string Status { get => status; set => status = value; }


        public Game(int id, string title, string genre, string console, int numPlayers, string status)
        {
            this.id = id;
            this.title = title;
            this.genre = genre;
            this.console = console;
            this.numPlayers = numPlayers;
            this.status = status;

        }
        public override string ToString()
        {
            return String.Format("{0,0} {1,35} {2,25} {3,25} {4,11} {5,10}", id, title, genre, console, numPlayers, status);
        }
    }
}
