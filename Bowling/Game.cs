using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleUtilities;

namespace Bowling
{
    class Game
    {
        public string Name { get; set; }
        private readonly List<string> _firtsRow = new List<string>() {"Frame", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10"};
        private readonly List<string> _secondRow = new List<string>() { "Rolls", "...-", "", "", "", "", "", "", "", "", "" };
        private readonly List<string> _thirdRow = new List<string>() { "Score", "", "", "", "", "", "", "", "", "", "" };

        public void Start()
        {
            Console.WriteLine("Write your name, please");
            Name = Console.ReadLine();
            Console.WriteLine("Greetings, {0}! Press any button to start the game", Name);
            Console.ReadKey();
            Console.Clear();
        }

        public void AddTable()
        {
            var settings = new ConsoleTableSettings('|', '-');
            var table = new ConsoleTable(_firtsRow, settings);
            table.AddRow(_secondRow);
            table.AddRow(_thirdRow);
            table.WriteToConsole();
        }

        private int NumOfPins(int border)
        {
            var random = new Random();
            var temp = random.Next(border);
            return temp;
        }


    }
}
