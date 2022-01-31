using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChessTournament
{
    
    class Pairing
    {       
        //Properties
        public PlayerService playerService { get; set; }
        public List<Player[]> Pairs { get; set; }
        private static Random _random = new Random();

        //Constructors
        public Pairing()
        {
            Pairs = new List<Player[]>();
            playerService = new PlayerService();
        }

        //Methods
        public void GenerateRoundPairings()
        {
            int numOfPairs = (playerService.Players.Count / 2) ;
            List<Player> tempList = playerService.Players;

            
            for (int i = 0; i < numOfPairs; i++)
            {
                
                CreateRandomPair(tempList);
            }
            
        }

        public void CreateRandomPair(List<Player> list)
        {

            Player player1;
            Player player2;
            Player[] pair = new Player[2];

            player1 = list[_random.Next(0, list.Count)];
            pair[0] = player1;
            list.Remove(player1);

            player2 = list[_random.Next(0, list.Count)];
            list.Remove(player2);           
            pair[1] = player2;
            
            Pairs.Add(pair);
            //Console.WriteLine($"{Pairs[Pairs.Count - 1][0].Name} vs {Pairs[Pairs.Count - 1][1].Name}");
        }
    }
}


