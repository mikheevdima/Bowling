﻿using System;
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

            game.AddTable();

            

            Console.ReadKey();
        }
    }
}
