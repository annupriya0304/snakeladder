using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudoInitail
{
    class Program
    {
        

        static void Main(string[] args)
        {
            Console.WriteLine("Play Snakes and Ladder");
            Console.WriteLine("How many players want to play");
            int players = Convert.ToInt32(Console.ReadLine());

            if(players>4 || players<2)
            {
                Console.WriteLine("Invalid Player Numbers");
                players = Convert.ToInt32(Console.ReadLine());
            }
           Ludo ludo = new Ludo();
            ludo.CreatePath();
            for (int i=0; i <players; i++)
            {
                Console.WriteLine("What color will player " + (i+ 1).ToString());
                string color = Console.ReadLine();
              ludo.CreatePlayers(color);
            }

            Console.WriteLine("The game starts");

          

            while (!ludo.players.Any(x => x.CurrentPosition == 100))
            {
                int counter = 0;
                foreach (var player in ludo.players)
                {
                    if(ludo.players.Any(x=>x.CurrentPosition==100))
                    {
                        break;
                    }
                    counter++;
                    Console.WriteLine("Player " + counter + " chance. Please roll the dice");


                    ludo.DiceRoll(player);
                    Console.WriteLine();

                }
            }

            var index = ludo.players.FirstOrDefault(x => x.CurrentPosition == 100).color;
            Console.WriteLine(index +" won");
            Console.ReadKey();

        }


       


    }
}
