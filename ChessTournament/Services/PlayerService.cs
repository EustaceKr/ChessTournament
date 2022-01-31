using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament
{
    class PlayerService
    {
        //Properties
        private List<Player> _players;
        public List<Player> Players {
            get
            { 
                return _players; 
            }
            private set { } 
        }

        //Constructors
        public PlayerService()
        {
            _players = new List<Player>();
            GeneratePlayers();   
            
        }

        //Methods
        private int AddPlayer(Player player)
        {
            if (Players.Contains(player))
            {
                return 0;
            }
            else
            {
                Players.Add(player);
                return 1;
            }
        }

        public void GeneratePlayers()
        {
            AddPlayer(new Player("Magnus Carlsen", 12345, new DateTime(1990, 11, 30), 2855));
            AddPlayer(new Player("Gary Casparov", 23456, new DateTime(1963, 4, 13), 2812));                      
            AddPlayer(new Player("Ding Liren", 34567, new DateTime(1992, 10, 24), 2799));
            AddPlayer(new Player("Fabiano Caruana", 23445, new DateTime(1992, 07, 30), 2791));
            AddPlayer(new Player("Levon Aronian", 12344, new DateTime(1982, 10, 06), 2782));
            AddPlayer(new Player("Ian Nepomniachtchi", 97686, new DateTime(1990, 07, 14), 2782));
            AddPlayer(new Player("Anish Giri", 44356,new DateTime(1994, 06, 28), 2774));
            AddPlayer(new Player("Alexander Grischuk", 64367, new DateTime(1983, 10, 31), 2773));
            //AddPlayer(new Player("Wesley So", 676456,  new DateTime(1993, 10, 09), 2772));
        }                
    }
}
