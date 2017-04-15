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
        public int FirstRoll { get; set; }
        public int SecondRoll { get; set; }
        public bool Strike { get; set; }
        public bool Spair { get; set; }

        private readonly List<string> _firtsRow = new List<string>() {"Frame", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10"};
        private readonly List<string> _secondRow = new List<string>() { "Rolls", "", "", "", "", "", "", "", "", "", "" };
        private readonly List<string> _thirdRow = new List<string>() { "Score", "", "", "", "", "", "", "", "", "", "" };
        private readonly Random _random = new Random();

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

        public int NumOfPins(int border)
        {
            var temp = _random.Next(border);
            return temp;
        }

        public void FirstRollText(int numofpins)
        {
            if (numofpins == 10)
            {
                Console.WriteLine("Roll 1... Strike!Excellent!");
            }
            else
            {
                if (numofpins < 5)
                {
                    if (numofpins == 0)
                    {
                        Console.WriteLine("Roll 1... no pins down! You need more practice!");
                    }
                    else
                    {
                        Console.WriteLine("Roll 1... {0} pin down! Be more accurate!", numofpins);
                    }
                }
                else
                {
                    Console.WriteLine("Roll 1... {0} pins down! Very nice!", numofpins);
                }
            }
        }

        public void SecondRollText(int numofpins)
        {
            if (numofpins == 10)
            {
                Console.WriteLine("Roll 2... Spare! Way to go!!");
            }
            else
            {
                if (numofpins < 5)
                {
                    if (numofpins == 0)
                    {
                        Console.WriteLine("Roll 2... no pins down! You need more practice!");
                    }
                    else
                    {
                        Console.WriteLine("Roll 2... {0} pin down! Be more accurate!", numofpins);
                    }
                }
                else
                {
                    Console.WriteLine("Roll 2... {0} pins down! Very nice!", numofpins);
                }
            }
        }

        public void FirstRollTabletext(int numofpins, int numofframe)
        {
            _secondRow[numofframe] = "...-";
            Console.Clear();
            AddTable();
        }

        public void SecondRollTabletext(int numofpins1Roll, int numofframe)
        {
            _secondRow[numofframe] = numofpins1Roll + "-...";
            Console.Clear();
            AddTable();
            FirstRollText(numofpins1Roll);
        }

        public void AfterRollTableText(int numofpins1Roll, int numofpins2Roll, int numofframe)
        {
            _secondRow[numofframe] = numofpins1Roll + "-" + numofpins2Roll;
            Console.Clear();
            AddTable();
            FirstRollText(numofpins1Roll);
            SecondRollText(numofpins2Roll);
        }

        public void IfStrike(int numofframe)
        {
            _secondRow[numofframe] = "X";
            var previousRoll = _secondRow[numofframe - 1];

            if (numofframe == 1)
            {
                _thirdRow[numofframe] = "10";
            }
            else
            {
                var previousScore = Convert.ToInt32(_thirdRow[numofframe - 1]);
                _thirdRow[numofframe] = (previousScore + 10).ToString();
            }

            if (previousRoll == "X")
            {
                var previousScore = Convert.ToInt32(_thirdRow[numofframe - 1]);
                _thirdRow[numofframe - 1] = (previousScore + 10).ToString();
                previousScore = Convert.ToInt32(_thirdRow[numofframe - 1]);
                _thirdRow[numofframe] = (previousScore + 10).ToString();
            }

            if (previousRoll == "X" && _secondRow[numofframe - 2] == "X")
            {
                var previousScore = Convert.ToInt32(_thirdRow[numofframe - 1]);
                var prepreviousScore = Convert.ToInt32(_thirdRow[numofframe - 2]);
                _thirdRow[numofframe - 2] = (prepreviousScore + 10).ToString();
                _thirdRow[numofframe - 1] = (previousScore + 10).ToString();
                previousScore = Convert.ToInt32(_thirdRow[numofframe - 1]);
                _thirdRow[numofframe] = (previousScore + 10).ToString();
            }

            Console.Clear();
            AddTable();
            Console.WriteLine("Roll 1... Strike!Excellent!");
        }

        public void CalculatePoints(int numofpins1Roll, int numofpins2Roll, int numofframe)
        {
            int sum = numofpins1Roll + numofpins2Roll;

            if (Strike)
            {
                var previousframe = Convert.ToInt32(_thirdRow[numofframe - 1]);
                _thirdRow[numofframe - 1] = (previousframe + sum).ToString();
            }

            if (numofframe == 1)
            {
                _thirdRow[numofframe] = sum.ToString();
            }
            else
            {
                var previousframe = Convert.ToInt32(_thirdRow[numofframe - 1]);
                sum = (numofpins1Roll + numofpins2Roll);
                _thirdRow[numofframe] = (previousframe + sum).ToString();
            }

            Console.Clear();
            AddTable();
        }
    }
}
