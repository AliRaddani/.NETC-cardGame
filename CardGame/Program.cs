//created by ali raddani on 2/18/2020
//last updated on 2//19/2020
//main tester class for card game.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Program
    {
        static void Main(string[] args)
        {
           
            while (true)
            {
                List<Player> myList = new List<Player>();
                CardDeck cd = new CardDeck();
                GameLogic game = new GameLogic();

                game.playGame(myList, cd);
                Console.WriteLine("Play again? Yes|No");
                if (!Console.ReadLine().StartsWith("Y", StringComparison.OrdinalIgnoreCase)) break;
            }
                
        }
    }
}
