using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudoInitail
{
   public class Ludo
    {
        public Ludo()
        {
            players = new List<Players>();
        }


      public  List <Players> players { get; set; }
        public int dice { get; set; }
        public int[] Path { get; set; }
        public int[] PathIncrementDecrement { get; set; }
      

        public void CreatePath()
        {

           this.Path = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100 };

            this.PathIncrementDecrement = new int[] { 0, 0, 48, 0, 0, 21, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 50, 0, 0, 0, 0, -20, 0, 0, 0, 0, 0,0,0,0,-33,0,19,0,0,0,0,0,0,0,0,0,0,-28,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,32,0,-13,0,0,30,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-30,0,0,0,-30,0,0,0,0,0,0,0,-30,0 };
            //this.Path = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30 };
        }

        public void CreatePlayers(string color)
        {
            this.players.Add(new Players
            {

                color = color,

                CurrentChance = 0,
                CurrentPosition = 0,

            });


        }

        public  void DiceRoll(Players player)
        {
            Random rnd = new Random();
            player.CurrentChance = rnd.Next(1, 6);
            Console.WriteLine("Ur current roll is " + player.CurrentChance);

            int sixcounter=0;

            if (player.CurrentChance == 6)
            {
                sixcounter++;
                if (sixcounter < 3)
                {
                    player.CurrentPosition += 6;
                    DiceRoll(player);
                }
            }

            else
            {
                if (player.CurrentPosition + player.CurrentChance <= 100)
                {
                    player.CurrentPosition += player.CurrentChance;
                    var index = Array.FindIndex(Path, row => row == player.CurrentPosition);
                    player.CurrentPosition += PathIncrementDecrement[index];
                    if (PathIncrementDecrement[index] < 0) { Console.WriteLine("Opps Snake bike!! :("); }
                    if (PathIncrementDecrement[index] > 0) { Console.WriteLine("Wohooo U climbed a ladder !!! :) :)"); }
                    Console.WriteLine( player.color +" is currently at " + player.CurrentPosition);
                }
                else
                {
                    Console.WriteLine("Opps u cnt make a move");
                }

            }


        }

    }


   public class Players
    {
       public string color { get; set; }
        public int CurrentPosition { get; set; }
        public int CurrentChance { get; set; }
      //  public List<Tokens> tokens {get;set;}

    }

   public class Tokens
    {
        public int position { get; set; }
    }



 
}
