using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;

namespace Hello_World
{
    /*
     * Player 1 will be O's
     * Player 2 will be X's
     * O's will be Blue and X's will be red
     * Valid text input will be 1-9 for each corresponding field.
    */
    class S7TicTacToe
    {
        protected TicTacCell[,] GameGrid = new TicTacCell[3, 3];
        protected byte _Player = 1;
        protected bool Playing = true;
        protected char Symbol = 'O';
        protected int Plays = 0;

        protected byte Player
        {
            get => _Player;
            set
            {
                _Player = value;
                switch (_Player)
                {
                    case 1:
                        Symbol = 'O';
                        break;
                    case 2:
                        Symbol = 'X';
                        break;
                    default:
                        Symbol = '~';
                        break;
                }
            }
        }


        public S7TicTacToe()
        {
            InitializeGrid();
            return;
        }

        public void Play()
        {
            Player = 1;
            Playing = true;
            Plays = 1;

            do
            {
                DrawScreen();
                bool ValidInput = false;
                do
                {
                    Console.WriteLine("");
                    Console.Write($"Player {Player}: Choose your field! ");
                    ValidInput = TakeInput(Console.ReadLine());
                    if (Playing == false) break;
                } while (ValidInput == false);
                
                Plays++;
                
                if (CheckWinner())
                {
                    DrawScreen();
                    Console.WriteLine($"\nCongratulations Player {Player}, you win!");
                    Console.Write("Play again (Y/N)? ");
                    if (Console.ReadLine().Trim().ToUpper().Contains('Y'))
                    {
                        Playing = true;
                        Plays = 1;
                        InitializeGrid();
                    }
                    else
                    {
                        Console.WriteLine("Thanks for playing, Goodbye!");
                        Playing = false;
                    }
                } 
                if (Player == 1) Player = 2;
                else Player = 1;
                if (Plays > 9)
                {
                    DrawScreen();
                    Console.WriteLine("\nThe game is a draw!");
                    Console.Write("Play again (Y/N)? ");
                    if (Console.ReadLine().Trim().ToUpper().Contains('Y'))
                    {
                        Playing = true;
                        Plays = 1;
                        InitializeGrid();
                    }
                    else
                    {
                        Console.WriteLine("Thanks for playing, Goodbye!");
                        Playing = false;
                    }
                }

            } while (Playing);

            return;
        }

        protected bool CheckWinner()
        {
            // Returns true if there is a winner.
            
            // Checking across
            for (int y = 0; y < 3; y++)
            {
                int Counter = 0;
                for (int x = 0; x < 3; x++)
                {
                    if (GameGrid[x, y].Value == Symbol)
                    {
                        Counter++;
                    }
                    //Console.WriteLine($"Counter = {Counter}");
                    //Console.ReadKey();
                    if (Counter == 3) return true;
                }
                    
            }

            // Checking up and down
            for (int x = 0; x < 3; x++)
            {
                int Counter = 0;
                for (int y = 0; y < 3; y++)
                {
                    if (GameGrid[x, y].Value == Symbol)
                    {
                        Counter++;
                    }
                    //Console.WriteLine($"Counter = {Counter}");
                    //Console.ReadKey();
                    if (Counter == 3) return true;
                }

            }

            if (GameGrid[0, 0].Value == Symbol && GameGrid[1, 1].Value == Symbol && GameGrid[2, 2].Value == Symbol) return true;
            if (GameGrid[2, 0].Value == Symbol && GameGrid[1, 1].Value == Symbol && GameGrid[0, 2].Value == Symbol) return true;

            return false;
        }

        protected bool TakeInput(string Input)
        {
            // Returns true if input is valid. False otherwise.
            // Will set Playing to false if the input -1 is detected. 
            int Selection = 0;
            if (!(int.TryParse(Input, out Selection)))
            {
                Console.WriteLine("Invalid Input: Please enter a single digit 1-9 or '-1' to quit.");
                return false;
            }
            if (Selection == -1)
            {
                Playing = false;
                return true;
            }
            if (Selection > 9 || Selection < 1)
            {
                Console.WriteLine("Invalid Input: Please enter a single digit 1-9 or '-1' to quit.");
                return false;
            }
            foreach (TicTacCell Cell in GameGrid)
            {
                if (Cell.Position == Selection)
                {
                    if (Cell.IsSet)
                    {
                        Console.WriteLine("You can't overwrite a filled space! Try again.");
                        return false;
                    }
                    else
                    {
                        Cell.Value = Symbol;
                    }
                }
            }
            return true;
        }

        protected void InitializeGrid()
        {
            int x = 0, y = 2, Counter = 1;
            while (y >= 0)
            {
                GameGrid[x, y] = new TicTacCell(Counter);
                Counter++;
                x++;
                if (x > 2)
                {
                    x = 0;
                    y--;
                }
            }
            return;
        }

        protected void DrawScreen()
        {
            string EmptyLine = "     |     |     ";
            string UnderscoreLine = "_____|_____|_____";
            string MidSpace = "  |  ";
            string SideSpace = "  ";

            Console.Clear();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(EmptyLine);
                Console.Write(SideSpace); GameGrid[0, i].WriteCharacter(); Console.Write(MidSpace); GameGrid[1, i].WriteCharacter(); Console.Write(MidSpace); GameGrid[2, i].WriteCharacter(); Console.WriteLine(SideSpace);
                if (i == 2) Console.WriteLine(EmptyLine);
                else Console.WriteLine(UnderscoreLine);
            }
            return;
        }
    }

    class TicTacCell
    {
        /*
         * The only things this class can do are:
         * 1) Set the value
         * 2) Write it's character to the console
         * You can optionally extract the value manually. 
        */
        protected ConsoleColor TextColor = ConsoleColor.Gray;
        protected char _Value = '-';
        protected bool _IsSet = false;
        protected int _Position = 0;
        public char Value
        {
            get => _Value;
            set
            {
                if (_IsSet) return;
                if (char.IsDigit(value))
                {
                    _Value = value;
                    _Position = int.Parse(value.ToString());
                    TextColor = ConsoleColor.Gray;
                }
                else if (value == 'O')
                {
                    _Value = value;
                    TextColor = ConsoleColor.Cyan;
                    _IsSet = true;
                }
                else if (value == 'X')
                {
                    _Value = value;
                    TextColor = ConsoleColor.Red;
                    _IsSet = true;
                }
                else _Value = '~';
            }
        }
        public bool IsSet
        {
            get => _IsSet;
        }
        public int Position
        {
            get => _Position;
        }

        public void ValueFromInt(int Value)
        {
            if (Value >= 1 && Value <= 9)
            {
                this._Value = Value.ToString()[0];
                this._Position = Value;
                TextColor = ConsoleColor.Gray;
            }
            return;
        }

        public TicTacCell()
        {
            return;
        }

        public TicTacCell(char Value)
        {
            this.Value = Value;
            return;
        }

        public TicTacCell(int Value)
        {
            ValueFromInt(Value);
            return;
        }

        internal void WriteCharacter()
        {
            Console.ForegroundColor = TextColor;
            Console.Write(_Value);
            Console.ForegroundColor = ConsoleColor.Gray;
            return;
        }
    }
}
