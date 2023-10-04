using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2.Model
{
    public class Board 
    {

        private Cell[,] _cells = new Cell[8, 8];
        readonly public ObservableCollection<Cell> cells = new ObservableCollection<Cell>();
        readonly public int[] location_number_letters;
        readonly public int[] revers_location_number_letters;
        readonly public bool isWhite;
        string[,] figureW = new string[2, 8] { { "PW", "PW", "PW", "PW", "PW", "PW", "PW", "PW" }, { "RW", "NW", "BW", "QW", "KW", "BW", "NW", "RW" }};
        string[,] figureB = new string[2, 8] { { "PB", "PB", "PB", "PB", "PB", "PB", "PB", "PB" }, { "RB", "NB", "BB", "KB", "QB", "BB", "NB", "RB" } };
        public Board(bool isWhite)
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if ((x + y) % 2 != 0)
                        _cells[x, y] = new Cell(x, y, "red_border", Visibility.Hidden/*, new Figure("BB")*/);
                    else
                        _cells[x, y] = new Cell(x, y, "transparent_border", Visibility.Hidden/*, new Figure("RW")*/);
                    cells.Add(_cells[x, y]);
                }
            }
            if (isWhite)
            {
                location_number_letters = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                revers_location_number_letters = new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };

                for (int x = 6; x < 8; x++)
                {
                    for (int y = 0; y < 8; y++)
                    {
                        _cells[x, y].figure = new Figure(figureW[x - 6, y]);
                    }
                }
                int i = 0;
                int j = 0;
                for (int x = 1; x >= 0; x--)
                {
                    for (int y = 7; y >= 0; y--)
                    {
                        _cells[i, j].figure = new Figure(figureB[x, y]);
                        j++;
                    }
                    i++;
                    j = 0;
                }
            }
            else
            {
                location_number_letters = new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
                revers_location_number_letters = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                for (int x = 6; x < 8; x++)
                {
                    for (int y = 0; y < 8; y++)
                    {
                        _cells[x, y].figure = new Figure(figureB[x - 6, y]);
                    }
                }
                int i = 0;
                int j = 0;
                for (int x = 1; x >= 0; x--)
                {
                    for (int y = 7; y >= 0; y--)
                    {
                        _cells[i, j].figure = new Figure(figureW[x, y]);
                        j++;
                    }
                    i++;
                    j = 0;
                }

            }
            this.isWhite = isWhite;
        }
        public void testc(int x, int y)
        {
            _cells[x, y].figure = new("QW");
            Debug.WriteLine($"Координаты в матрице: {x}, {y}");
            if (isWhite)
            {
                //Белые 
                Debug.WriteLine($"Координаты на доске:{revers_location_number_letters[x] - 2}, {y}");
                Debug.WriteLine($"__________________");
            }
            else
            {
                //Черный
                Debug.WriteLine($"Координаты на доске:{x}, {location_number_letters[y] - 2}");
                Debug.WriteLine($"__________________");
            }
        }
        
    }
}
