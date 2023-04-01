using System.Data;
using System.Xml.XPath;

namespace DragonsWay.Logic
{
    public class Game
    {
        private char[,] _maze;

        public Game(int n, string pathDragon)
        {
            N = n;
            PathDragon = pathDragon;
            _maze = new char[N, N*2];
            FillMaze();
        }

        public int N { get; }

        public string PathDragon { get; }

        public override string ToString()
        {
            var output = string.Empty;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N*2; j++)
                {
                    output += $"{_maze[i, j]}";
                }
                output += "\n";
            }
            return output;
        }

        private void FillMaze()
        {
            FillBorders();
        }

        private void FillBorders()
        {
            _maze[0, 0] = '█';
            _maze[0, N * 2 - 1] = '█';
            for (int j = 1; j < N * 2 - 1; j++)
            {
                _maze[0, j] = '▀';
            }
            for (int j = 0; j < N * 2 - 1; j++)
            {
                _maze[1, j] = ' ';
            }
            _maze[1, N*2 - 1] = '█';
            for (int i = 2; i < N - 1; i++)
            {
                _maze[i, 0] = '█';
                for (int j = 1; j < N * 2 - 1; j++)
                {
                    _maze[i, j] = ' ';
                }
                _maze[i, N*2 - 1] = '█';
            }
            _maze[N - 2, N*2 - 1] = ' ';
            for (int j = 1; j < N * 2-1; j++)
            {
                _maze[N - 1, j] = '▄';
            }
            _maze[N-1, 0] = '█';
            _maze[N-1, N * 2 - 1] = '█';
        }

        private bool CanMoveRight(int col)
        {
            if (col == N * 2 - 2)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool CanMoveDown(int row)
        {
            if (row < N - 2)
            {
                return true;
            }
            return false;
        }

        private bool CanExit(int row, int col)
        {
            if (row == N - 2 && col == N * 2 - 2)
            {
                return true;
            } 
            else
            {
                return false;
            }
        }

        private bool ValidPath(string PathDragon)
        {
            // Validar que el camino del dragón solo contiene movimientos válidos
            foreach (char c in PathDragon)
            {
                if (c != '↓' && c != '→')
                {
                    Console.WriteLine("El camino del dragón contiene movimientos inválidos.");
                    return false;
                }
                
            }
            return true;
        }


        public bool Win()
        {
            if (!ValidPath(PathDragon))
            {
                return false;
            }

            int row = 1;
            int col = 0;
            _maze[row, col] = PathDragon[0];
            int elementPathDragon = 1;

            while (elementPathDragon < PathDragon.Length)
            {
                if (PathDragon[elementPathDragon] == '→')
                {
                    if (CanMoveRight(col))
                    {
                        col++;
                        _maze[row, col] = PathDragon[elementPathDragon];
                        elementPathDragon++;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (PathDragon[elementPathDragon] == '↓')
                {
                    if (CanMoveDown(row))
                    {
                        row++;
                        _maze[row, col] = PathDragon[elementPathDragon];
                        elementPathDragon++;
                    }
                    else
                    {
                        return false;
                    }
                }
                
                if (CanExit(row, col))
                {
                    return true;
                }

                if (!CanMoveRight(col) && !CanMoveDown(row) && !CanExit(row, col))
                {
                    return false;
                }

                //Console.Clear();
                //Console.BackgroundColor = ConsoleColor.Blue;
                //Console.ForegroundColor = ConsoleColor.White;
                //Console.WriteLine(this);
                //Thread.Sleep(10);
  
            }
            return true;
        }

    }
}