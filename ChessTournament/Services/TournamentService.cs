using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament
{
    class TournamentService
    {
        //Properties
        public Dictionary<Player, double> Points { get; set; }
        public List<Player> PlayerList { get; set; }

        private static Random _rand1 = new Random();
        private static Random _rand2 = new Random();
        //Constructors
        public TournamentService(List<Player> list)
        {
            Points = new Dictionary<Player, double>();
            PlayerList = list;
            foreach (var player in PlayerList)
            {
                Points.Add(player, 0);
            }
        }

        public Dictionary<Player, double> Game(Player player1, Player player2, Dictionary<Player, double> points)
        {            
            double change1 = 0;
            double change2 = 0;
            
            int HP1 = player1.HitPoints;
            int HP2 = player2.HitPoints;

            do
            {
                HP1 -= (player1.Clarity + player1.ProfficiencyBonus + player1.Mentality) * _rand1.Next(1, 9);
                HP2 -= (player2.Clarity + player2.ProfficiencyBonus + player2.Mentality) * _rand2.Next(1, 8);
            } while (HP1 >= 0 && HP2 >= 0);

            if (HP1 <= 0 && HP2 >= 2000)
            {
                change1 = 0;
                change2 = 1;
            }
            else if (HP2 <= 0 && HP1 >= 2000)
            {
                change1 = 1;
                change2 = 0;
            }
            else
            {
                change1 = 0.5;
                change2 = 0.5;
            }
            points[player1] += change1;
            points[player2] += change2;

            return points;
        }
        public void PrintRankings(Dictionary<Player, double> dict)
        {
            var totalrankings = dict.ToList();
            totalrankings.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));
            foreach (var value in totalrankings)
            {                
                Console.WriteLine($"{value.Key.Name} : {value.Value} points");
            }
        }
        public void GameAllRound(List<Player[]> list, Dictionary<Player, double> dict)
        {
            foreach (var player in list)
            {
                Game(player[0], player[1], dict);
            }
        }
    }
}
