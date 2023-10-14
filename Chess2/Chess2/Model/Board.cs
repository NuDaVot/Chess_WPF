using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Chess2.Model
{
    public class Board
    {

        private Cell[,] _cells = new Cell[8, 8];
        readonly public ObservableCollection<Cell> cells = new ObservableCollection<Cell>();
        readonly public int[] location_number_letters;
        readonly public int[] revers_location_number_letters;
        readonly public bool isWhite;
        private Figure[,] figureW = new Figure[8, 2];
        private Figure[,] figureB = new Figure[8, 2];
        List<IntPoint> _hintFigure = new List<IntPoint>();
        List<IntPoint> _hintBoard = new List<IntPoint>();
        private int step = 0;
        

        public Board(bool isWhite)
        {
            #region Инициализируем фигуры для белых
            figureW[0, 0] = new Pawn("PW", true);
            figureW[1, 0] = new Pawn("PW", true);
            figureW[2, 0] = new Pawn("PW", true);
            figureW[3, 0] = new Pawn("PW", true);
            figureW[4, 0] = new Pawn("PW", true);
            figureW[5, 0] = new Pawn("PW", true);
            figureW[6, 0] = new Pawn("PW", true);
            figureW[7, 0] = new Pawn("PW", true);

            figureW[0, 1] = new Rook("RW", true);
            figureW[1, 1] = new Knight("NW", true);
            figureW[2, 1] = new Bishop("BW", true);
            figureW[3, 1] = new Queen("QW", true);
            figureW[4, 1] = new King("KW", true);
            figureW[5, 1] = new Bishop("BW", true);
            figureW[6, 1] = new Knight("NW", true);
            figureW[7, 1] = new Rook("RW", true);
            #endregion

            #region Инициализируем фигуры для черных
            figureB[0, 0] = new Pawn("PB", false);
            figureB[1, 0] = new Pawn("PB", false);
            figureB[2, 0] = new Pawn("PB", false);
            figureB[3, 0] = new Pawn("PB", false);
            figureB[4, 0] = new Pawn("PB", false);
            figureB[5, 0] = new Pawn("PB", false);
            figureB[6, 0] = new Pawn("PB", false);
            figureB[7, 0] = new Pawn("PB", false);

            figureB[0, 1] = new Rook("RB", false);
            figureB[1, 1] = new Knight("NB", false);
            figureB[2, 1] = new Bishop("BB", false);
            figureB[3, 1] = new Queen("QB", false);
            figureB[4, 1] = new King("KB", false);
            figureB[5, 1] = new Bishop("BB", false);
            figureB[6, 1] = new Knight("NB", false);
            figureB[7, 1] = new Rook("RB", false);
            #endregion


            for (short x = 0; x < 8; x++)
            {
                for (short y = 0; y < 8; y++)
                {
                    if ((x + y) % 2 != 0)
                        _cells[x, y] = new Cell(new IntPoint(x, y), "red_border", Visibility.Hidden);
                    else
                        _cells[x, y] = new Cell(new IntPoint(x, y), "transparent_border", Visibility.Hidden);
                    cells.Add(_cells[x, y]);
                }
            }
            
            if (isWhite)
            {
                location_number_letters = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                revers_location_number_letters = new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
                for (int x = 0; x < 8; x++)
                {
                    for (int y = 6; y < 8; y++)
                    {
                        if (figureW[x, y-6] != null)
                        {
                            _cells[x, y].figure = figureW[x, y-6];
                            figureW[x, y-6].point = _cells[x, y].point;
                        }
                    }
                }
                int i = 0;
                int j = 0;
                for (int x = 7; x >= 0; x--)
                {
                    for (int y = 1; y >= 0; y--)
                    {
                        _cells[i, j].figure = figureB[x, y];
                        figureB[x, y].point = _cells[i, j].point;
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
                for (int x = 0; x < 8; x++)
                {
                    for (int y = 6; y < 8; y++)
                    {
                        _cells[x, y].figure = figureB[x, y - 6];
                        figureB[x, y - 6].point = _cells[x, y].point;
                    }
                }
                int i = 0;
                int j = 0;
                for (int x = 7; x >= 0; x--)
                {
                    for (int y = 1; y >= 0; y--)
                    {
                        _cells[i, j].figure = figureW[x, y];
                        figureW[x, y].point = _cells[i, j].point;
                        j++;
                    }
                    i++;
                    j = 0;
                }
            }
            //_cells[5, 5].figure = figureW[1, 0];
            //figureW[1, 1].point = _cells[5, 5].point;
            this.isWhite = isWhite;
        }

        public Cell GetHints(Cell cell, Cell? pastCell = null)
        {
            if (pastCell != null && pastCell.figure != null && ((cell.GitVisibility() && pastCell.figure.isWhite == TurnOrder()) || (pastCell.figure.isWhite == TurnOrder())))
            {
                List<IntPoint> PastHint = pastCell.figure.GetHints();
                foreach (IntPoint hint in PastHint)
                {
                    _cells[hint.X, hint.Y].ChangeVisibility(false);
                }
                cell.figure = pastCell.figure;
                cell.figure.point = cell.point;
                pastCell.figure = null;
                if ((pastCell.point.X + pastCell.point.Y) % 2 != 0)
                    pastCell.RemuveStyle("red_border");
                else
                    pastCell.RemuveStyle("transparent_border");
                pastCell = null;
                step++;
                return pastCell;
            }
            cell.RemuveStyle("select_border");
            if (pastCell != null && pastCell != cell)
            {
                if ((pastCell.point.X + pastCell.point.Y) % 2 != 0)
                    pastCell.RemuveStyle("red_border");
                else
                    pastCell.RemuveStyle("transparent_border");
            }
            

            if (pastCell != null && pastCell != cell && pastCell.figure != null)
            {
                List<IntPoint> PastHint = pastCell.figure.GetHints();
                foreach (IntPoint hint in PastHint)
                {
                    _cells[hint.X, hint.Y].ChangeVisibility(false);
                }
            }
            if (cell.figure == null || isWhite != cell.figure.isWhite || cell == pastCell)
            {
                return cell;
            }
            _hintFigure = cell.figure.GetHints();
            if (cell.figure is Knight)
            {
                _hintBoard = GetHintsKnight(cell);
            }
            else if (cell.figure is Pawn)
            {
                _hintBoard = GetHintsPawn(cell);
            }
            else
            {
                _hintBoard = GetHintsBoard(cell);
            }

            foreach (IntPoint hint in _hintFigure)
            {
                if (_hintBoard.Contains(hint))
                    _cells[hint.X, hint.Y].ChangeVisibility(true);
            }
            return cell;
        }
        private List<IntPoint> GetHintsPawn(Cell cell)
        {
            List<IntPoint> NotLook = new();
            Pawn pawn = cell.figure as Pawn; // Приводим объект к типу Pawn
            if (pawn != null)
            {
                NotLook = pawn.GetAllHints();
                // Ваши действия с полученным списком hints
            }
            List<IntPoint> ListHint = new();
            for(int i = 0; i < NotLook.Count; i++)
            {
               
                if (NotLook[i].OutRange(cell.point))
                {
                    continue;
                }
                switch (i)
                {
                    case 0:
                        if(_cells[NotLook[i].SumPoint(cell.point).X, NotLook[i].SumPoint(cell.point).Y].figure == null || _cells[NotLook[i].SumPoint(cell.point).X, NotLook[i].SumPoint(cell.point).Y].figure.isWhite == isWhite)
                        {
                            continue;
                        }
                        break;
                    case 1:
                        if (_cells[NotLook[i].SumPoint(cell.point).X, NotLook[i].SumPoint(cell.point).Y].figure != null)
                        {
                            i++;
                            continue;
                        }
                        break;
                    case 2:
                        if (cell.point.Y != 6 || _cells[NotLook[i].SumPoint(cell.point).X, NotLook[i].SumPoint(cell.point).Y].figure != null)
                        {
                            continue;
                        }
                        break;
                    case 3:
                        if (_cells[NotLook[i].SumPoint(cell.point).X, NotLook[i].SumPoint(cell.point).Y].figure == null || _cells[NotLook[i].SumPoint(cell.point).X, NotLook[i].SumPoint(cell.point).Y].figure.isWhite == isWhite)
                        {
                            continue;
                        }
                        break;
                }
                ListHint.Add(NotLook[i].SumPoint(cell.point));
            }
            return ListHint;
        }
        private List<IntPoint> GetHintsKnight(Cell cell)
        {
            List<IntPoint> ListHint = new();
            foreach (IntPoint hint in cell.figure.GetHints())
            {
                if (_cells[hint.X, hint.Y].figure == null)
                {
                    ListHint.Add(hint);
                }
                else if (_cells[hint.X, hint.Y].figure.isWhite != isWhite)
                    ListHint.Add(hint);
            }
            return ListHint;
        }
        private List<IntPoint> GetHintsBoard(Cell cell)
        {
            int x = cell.point.X;
            int y = cell.point.Y;
            List<IntPoint> ListHint = new();
            int xR = 0; // relative
            int yR = 0; // relative
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    switch (i)
                    {
                        case 0:
                            xR = -1 - j; yR = -1 - j; break;
                        case 1:
                            xR = 0; yR = -1 - j; break;
                        case 2:
                            xR = 1 + j; yR = -1 - j; break;
                        case 3:
                            xR = 1 + j; yR = 0; break;
                        case 4:
                            xR = 1 + j; yR = 1 + j; break;
                        case 5:
                            xR = 0; yR = 1 + j; break;
                        case 6:
                            xR = -1 - j; yR = 1 + j; break;
                        case 7:
                            xR = -1 - j; yR = 0; break;
                    }

                    if ((x + xR) < 0 || (y + yR) < 0 || (x + xR) > 7 || (y + yR) > 7)
                    {
                        continue;
                    }
                    if (_cells[x + xR, y + yR].figure == null)
                    {
                        ListHint.Add(new IntPoint(x + xR, y + yR));
                    }
                    else
                    {
                        if (_cells[x + xR, y + yR].figure.isWhite != isWhite )
                            ListHint.Add(new IntPoint(x + xR, y + yR));
                        break;
                    }
                }
            }
            return ListHint;
        }
        private bool TurnOrder()
        {
            return step % 2 == 0;
        }

        //#region Debug
        //public void DebugBoardPoint(int x, int y)
        //{

        //    //_cells[x, y].figure = new ("QW");
        //    //figure[0].GetHints();
        //    Debug.WriteLine($"Координаты в матрице: {x}, {y}");
        //    if (isWhite)
        //    {
        //        //Белые 
        //        Debug.WriteLine($"Координаты на доске:{revers_location_number_letters[x] - 2}, {y}");
        //        Debug.WriteLine($"__________________");
        //    }
        //    else
        //    {
        //        //Черный
        //        Debug.WriteLine($"Координаты на доске:{x}, {location_number_letters[y] - 2}");
        //        Debug.WriteLine($"__________________");
        //    }
        //}
        //private int[,] test = new int[8, 8]
        //{ {0, 0, 0, 0, 0 , 0, 0, 0 },
        //  {0, 0, 0, 0, 1 , 0, 0, 0 },
        //  {0, 0, 0, 0, 0 , 0, 0, 0 },
        //  {0, 0, 0, 0, 0 , 0, 0, 0 },
        //  {0, 0, 0, 1, 1 , 0, 0, 1 },
        //  {0, 0, 0, 0, 0 , 0, 0, 0 },
        //  {0, 0, 0, 0, 0 , 0, 0, 0 },
        //  {0, 0, 0, 0, 1 , 0, 0, 0 }
        //};
        //private int[,] test2 = new int[8, 8]
        //{ {0, 0, 0, 0, 0 , 0, 0, 0 },
        //  {0, 0, 0, 0, 0 , 0, 0, 0 },
        //  {0, 0, 0, 0, 0 , 0, 0, 0 },
        //  {0, 0, 0, 0, 0 , 0, 0, 0 },
        //  {0, 0, 0, 0, 0 , 0, 0, 0 },
        //  {0, 0, 0, 0, 0 , 0, 0, 0 },
        //  {0, 0, 0, 0, 0 , 0, 0, 0 },
        //  {0, 0, 0, 0, 0 , 0, 0, 0 }
        //};
        //private void da()
        //{
        //    for (int i = 0; i < 8; i++)
        //    {
        //        for (int j = 0; j < 8; j++)
        //        {
        //            if (i == x && j == y)
        //            {
        //                Debug.Write("A\t");
        //            }
        //            else
        //            {
        //                Debug.Write($"{test2[i, j]}\t");
        //            }
        //        }
        //        Debug.Write("\n");
        //    }
        //    Debug.Write("_________________________\n");
        //}
        //int x;
        //int y;

        //public void DebugBoardFigure(int x = 4, int y = 4)
        //{
        //    this.x = x; this.y = y;
        //    for (int k = 0; k < 8; k++)
        //    {
        //        for (int i = -k; i <= k; i++)
        //        {
        //            for (int j = -k; j <= k; j++)
        //            {
        //                int newX = x + i;
        //                int newY = y + j;

        //                if (newX >= 0 && newX < 8 && newY >= 0 && newY < 8)
        //                {
        //                    test2[newX, newY] = 1;
        //                }
        //            }
        //        }
        //        da();
        //    }
        //}

        //#endregion


    }
}
