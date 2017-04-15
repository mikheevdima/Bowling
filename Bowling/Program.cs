using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();
            for (int i = 1; i < 11; i++)
            {
                //game.FirstRoll = game.NumOfPins(11);
                game.FirstRoll = 10;
                game.SecondRoll = game.NumOfPins(11 - game.FirstRoll);

                game.FirstRollTabletext(game.FirstRoll, i);
                Console.ReadKey();

                if (game.FirstRoll == 10)
                {
                    game.IfStrike(i);
                    Console.ReadKey();

                    game.Strike = true;
                }

                else
                {
                    game.FirstRollText(game.FirstRoll);
                    Console.ReadKey();

                    game.SecondRollTabletext(game.FirstRoll, i);
                    Console.ReadKey();
                    game.SecondRollText(game.SecondRoll);
                    Console.ReadKey();

                    game.AfterRollTableText(game.FirstRoll, game.SecondRoll, i);
                    Console.ReadKey();

                    game.CalculatePoints(game.FirstRoll, game.SecondRoll, i);
                    Console.ReadKey();

                    game.Strike = false;
                }
                
            }


            Console.ReadKey();
        }
    }
}
