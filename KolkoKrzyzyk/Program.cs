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
        static char[,] grid = new char[3, 3] { { '_', '_', '_' }, { '_', '_', '_' }, { '_', '_', '_' } };
        static short playerId = 1;
        static void Main(string[] args)
        {
            bool GameRunning = true;

            var CursorX = Console.CursorLeft;
            var CursorY = Console.CursorTop;

            //char userInput;

            while (GameRunning)
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
                Console.Clear();


                printGrid();

                Console.SetCursorPosition(CursorX, CursorY);


                Thread.Sleep(33);
                


            }

            Console.ReadKey();
        }

        static void printGrid()
        {

            for(int i = 0; i < 3; ++i)
            {
                Console.WriteLine($"{grid[i, 0]}|{grid[i, 1]}|{grid[i, 2]}");

            }
        }

        static void changePlayer()
        {
            playerId *= -1;
        }

        static void setPlayerSign(int x, int y)
        {
            if(playerId == 1)
            {
                if (x == 4)
                    x = 3;
                if (grid[y, (x == 0 ? x : x - 1)] == '_')
                {
                    grid[y, (x == 0 ? x : x - 1)] = 'X';
                }
            }
            else
            {
                if (x == 4)
                    x = 3;
                if (grid[y, (x == 0 ? x : x - 1)] == '_')
                {
                    grid[y, (x == 0 ? x : x - 1)] = 'O';
                }
            }
        }
    }
}
