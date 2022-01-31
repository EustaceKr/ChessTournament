using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament
{
    class Program
    {        
        static void Main(string[] args)
        {            
            Tournament tour = new Tournament(13);
            tour.Start();
            Console.ReadKey();
        }
    }
}
