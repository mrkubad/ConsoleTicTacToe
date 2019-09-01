using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace KolkoKrzyzyk
{
    class Program
    {
        static short playerId = 1;
        static List<char> table = Enumerable.Repeat('_', 9).ToList();
        static string PlayerFirstName, PlayerSecondName;
        static void Main(string[] args)
        {
            
            bool GameRunning = true;
            ushort GameSets = 0;

            int CursorX = 0, CursorY = 0;
            

            Console.WriteLine("First player name: ");
            PlayerFirstName = Console.ReadLine();

            Console.WriteLine("Second player name: ");
            PlayerSecondName = Console.ReadLine();

            Console.Clear();
            Console.SetCursorPosition(0, 0);


            while (GameRunning && !checkWinner() && GameSets < 9 )
            {
                if(Console.KeyAvailable)
                {

                    CursorX = Console.CursorLeft;
                    CursorY = Console.CursorTop;

                    var userInput = Console.ReadKey().Key;

                    Console.SetCursorPosition(CursorX, CursorY);

                    switch(userInput)
                    {
                        case ConsoleKey.LeftArrow:
                            {
                                
                                if (CursorX - 2 >= 0)
                                {
                                    CursorX -= 2;
                                    Console.SetCursorPosition(CursorX, CursorY);
                                }
                                   
                                break;
                            }
                        case ConsoleKey.RightArrow:
                            {
                                
                                if (CursorX + 2 <= 4)
                                {
                                    CursorX += 2;
                                    Console.SetCursorPosition(CursorX, CursorY);
                                }
                                    
                                break;
                            }
                        case ConsoleKey.UpArrow:
                            {
                                
                                if (CursorY -1 >= 0)
                                {
                                    --CursorY;
                                    Console.SetCursorPosition(CursorX, CursorY);
                                }
                                    
                                break;
                            }
                        case ConsoleKey.DownArrow:
                            {
                                if (CursorY + 1 < 3)
                                {
                                    ++CursorY;
                                    Console.SetCursorPosition(CursorX, CursorY);
                                }
                                    
                                break;
                            }
                        case ConsoleKey.S:
                            {
                                setPlayerSign(CursorX, CursorY);
                                GameSets++;
                                changePlayer();
                                break;
                            }
                        case ConsoleKey.Escape:
                            {
                                GameRunning = false;
                                break;
                            }
                    }
                    
                }
                Console.CursorVisible = false;
                Console.SetCursorPosition(0, 0);



                printGrid();


                Console.WriteLine("{0}'s turn", playerId == 1 ? PlayerFirstName : PlayerSecondName);


                Console.SetCursorPosition(CursorX, CursorY);
                Console.CursorVisible = true;


                Thread.Sleep(16);

            }
  
            if(GameSets == 9)
            {
                Console.SetCursorPosition(0, 5);
                Console.WriteLine("Draw!");
            }

            Console.ReadKey();
        }

        static void printGrid()
        {
            for(int i = 0; i < table.Count; ++i)
            {
                Console.Write(table[i]);
                if ((i + 1) % 3 == 0)
                {
                    Console.WriteLine();
                }
                else
                {
                    Console.Write('|');
                }
            }
        }

        static bool checkWinner()
        {
            ushort p1rowPoints, p2rowPoints, p1columnPoints, p2columnPoints, p1firstDiagonalPoints = 0, p2firstDiagonalPoints = 0,
                p1secondDiagonalPoints = 0, p2secondDiagonalPoints = 0;
                ;

            for (int i = 0; i < 3; ++i)
            {
                p1rowPoints = 0;
                p2rowPoints = 0;
                p1columnPoints = 0;
                p2columnPoints = 0;

                for (int j = 0; j < 3; j++)
                {
                    // check for row win
                    if (table[i * 3 + j] == 'X')
                    {
                        p1rowPoints++;
                    }
                    else if (table[i * 3 + j] == 'O')
                    {
                        p2rowPoints++;
                    }

                    // check for column win
                    if (table[j * 3 + i] == 'X')
                    {
                        p1columnPoints++;
                    }
                    else if (table[j * 3 + i] == 'O')
                    {
                        p2columnPoints++;
                    }

                    // check for first diagonal win
                    if (i == j && table[j * 3 + i] == 'X')
                    {
                        p1firstDiagonalPoints++;
                    }
                    else if (i == j && table[j * 3 + i] == 'O')
                    {
                        p2firstDiagonalPoints++;
                    }
                    //check for second diagonal
                    if(i+j == 2 && table[j * 3 + i] == 'X')
                    {
                        p1secondDiagonalPoints++;
                    }
                    else if (i + j == 2 && table[j * 3 + i] == 'O')
                    {
                        p2secondDiagonalPoints++;
                    }
                }

                if(p1columnPoints == 3 || p1rowPoints == 3 || p1firstDiagonalPoints == 3 || p1secondDiagonalPoints == 3)
                {
                    displayWinner(1);
                    return true;
                }
                else if( p2columnPoints == 3 || p2rowPoints == 3 || p2firstDiagonalPoints == 3 || p2secondDiagonalPoints == 3)
                {
                    displayWinner(-1);
                    return true;
                }

            }
            return false;
        }

        static void displayWinner(int playerId)
        {
            Console.SetCursorPosition(0, 5);
            Console.WriteLine("{0} wins the game! :)", playerId > 0 ? PlayerFirstName : PlayerSecondName);
        }

        static void changePlayer()
        {
            playerId *= -1;
        }

        static void setPlayerSign(int x, int y)
        {
            if (x == 4)
                x = 2;
            else if (x == 2)
                x = 1;

            int index = y * 3 + x;

            if(table[index] == '_')
                table[index] = playerId > 0 ? 'X' : 'O';
        }
    }
}   
