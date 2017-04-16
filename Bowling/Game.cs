using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
        public int ThirdRoll { get; set; }
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

        public void SecondRollText(int numofpins1Roll, int numofpins2Roll)
        {
            var sum = numofpins1Roll + numofpins2Roll;
            if (sum == 10)
            {
                Console.WriteLine("Roll 2... Spare! Way to go!!");
            }
            else
            {
                if (numofpins2Roll < 5)
                {
                    if (numofpins2Roll == 0)
                    {
                        Console.WriteLine("Roll 2... no pins down! You need more practice!");
                    }
                    else
                    {
                        Console.WriteLine("Roll 2... {0} pin down! Be more accurate!", numofpins2Roll);
                    }
                }
                else
                {
                    Console.WriteLine("Roll 2... {0} pins down! Very nice!", numofpins2Roll);
                }
            }
        }

        public void ThirdRollText(int numofpins)
        {
            if (numofpins == 10)
            {
                Console.WriteLine("Roll 3... Strike!Excellent!");
            }
            else
            {
                if (numofpins < 5)
                {
                    if (numofpins == 0)
                    {
                        Console.WriteLine("Roll 3... no pins down! You need more practice!");
                    }
                    else
                    {
                        Console.WriteLine("Roll 3... {0} pin down! Be more accurate!", numofpins);
                    }
                }
                else
                {
                    Console.WriteLine("Roll 3... {0} pins down! Very nice!", numofpins);
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
            var sum = numofpins1Roll + numofpins2Roll;
            if (sum == 10)
            {
                IfSpareChangeRolls(numofframe, numofpins1Roll);
            }
            else
            {
                _secondRow[numofframe] = numofpins1Roll + "-" + numofpins2Roll;
            }
            Console.Clear();
            AddTable();
            FirstRollText(numofpins1Roll);
            SecondRollText(numofpins1Roll, numofpins2Roll);
        }

        public void IfStrike(int numofframe)
        {
            _secondRow[numofframe] = "X";

            var previousRoll = _secondRow[numofframe - 1];

            if (numofframe == 1) // рассматриваем случай первого хода
            {
                _thirdRow[numofframe] = "10";
            }
            else
            {
                var previousScore = Convert.ToInt32(_thirdRow[numofframe - 1]);
                if (Spair)
                {
                    _thirdRow[numofframe - 1] = (previousScore + 10).ToString();
                    Spair = false;
                }
                _thirdRow[numofframe] = (previousScore + 10).ToString();
            }

            if (previousRoll == "X") // если прошлый бросок был страйком
            {
                var previousScore = Convert.ToInt32(_thirdRow[numofframe - 1]);
                _thirdRow[numofframe - 1] = (previousScore + 10).ToString();
                previousScore = Convert.ToInt32(_thirdRow[numofframe - 1]);
                _thirdRow[numofframe] = (previousScore + 10).ToString();
            }

            if (previousRoll == "X" && _secondRow[numofframe - 2] == "X") // если прошлые 2 броска были страйками
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

        private void IfSpareChangeRolls(int numofframe, int numofpins1Roll)
        {
            _secondRow[numofframe] = numofpins1Roll + "/";
        }

        public void IfSpare(int numofpins1Roll, int numofpins2Roll)
        {
            Spair = false;
            var sum = numofpins1Roll + numofpins2Roll;
            if (sum == 10)
            {
                Spair = true;
            }
        }

        public void CalculatePoints(int numofpins1Roll, int numofpins2Roll, int numofframe)
        {
            int sum = numofpins1Roll + numofpins2Roll;

            if (numofframe == 1)
            {
                _thirdRow[numofframe] = sum.ToString();
            }
            else
            {
                var previousframe = Convert.ToInt32(_thirdRow[numofframe - 1]);

                if (Strike)
                {
                    _thirdRow[numofframe - 1] = (previousframe + sum).ToString();
                    Strike = false;
                }

                if (Spair)
                {
                    _thirdRow[numofframe - 1] = (previousframe + numofpins1Roll).ToString();
                    Spair = false;
                }
                previousframe = Convert.ToInt32(_thirdRow[numofframe - 1]);
                _thirdRow[numofframe] = (previousframe + sum).ToString();
            }

            Console.Clear();
            AddTable();
        }

        public void IfSpare10Frame(int numofpins1Roll, int numofpins2Roll)
        {
            if (Spair)
            {
                Console.Clear();
                var previousRoll = _secondRow[10];
                _secondRow[10] = _secondRow[10] + "-...";
                AddTable();
                FirstRollText(numofpins1Roll);
                SecondRollText(numofpins1Roll, numofpins2Roll);


                Console.ReadKey();


                ThirdRoll = NumOfPins(11);
                ThirdRollText(ThirdRoll);
                Console.ReadKey();

                Console.Clear();
                _secondRow[10] = previousRoll + ThirdRoll;
                AddTable();
                FirstRollText(numofpins1Roll);
                SecondRollText(numofpins1Roll, numofpins2Roll);
                ThirdRollText(ThirdRoll);
                Console.ReadKey();

                var previousScore = Convert.ToInt32(_thirdRow[10]);
                _thirdRow[10] = (previousScore + ThirdRoll).ToString();
                Console.Clear();
                AddTable();
            }
        }

        public void Congrats()
        {
            Console.WriteLine("Congratulations, {0}! Your final score: {1} points!", Name, _thirdRow[10]);
        }
    }
}
