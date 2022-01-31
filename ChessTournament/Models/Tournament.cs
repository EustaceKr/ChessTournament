using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChessTournament
{
    public class Tournament
    {
        //Proporties
        public int Rounds { get; set; }
        //Constructor
        public Tournament(int rounds)
        {
            Rounds = rounds;
        }
        //Methods
        public void Start()
        {           
            PlayerService playerService = new PlayerService();
            TournamentService tourService = new TournamentService(playerService.Players);
            
            for (int i = 1; i <= Rounds; i++)
            {                
                Pairing pairing = new Pairing();
                pairing.GenerateRoundPairings();
                tourService.GameAllRound(pairing.Pairs, tourService.Points);
                Console.WriteLine($"Round {i}");
                Console.WriteLine("---------");
                foreach (var item in pairing.Pairs)
                {                    
                    Console.WriteLine($"{item[0]} vs {item[1]}");                  
                }
                Console.WriteLine("\n");
            }
            tourService.PrintRankings(tourService.Points);
        }
    }
}
