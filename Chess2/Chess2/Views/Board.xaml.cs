using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chess2.Views
{
    /// <summary>
    /// Логика взаимодействия для Board.xaml
    /// </summary>
    public partial class Board : Page
    {
        public Board()
        {
            InitializeComponent();
            for (int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    Border myBorder = new Border();
                    myBorder.SetBinding(Grid.RowProperty, $"location_cells_row[{i}]");
                    myBorder.SetBinding(Grid.ColumnProperty, $"location_cells_column[{j}]");
                    if ((i + j) % 2 == 0)
                    {
                        myBorder.Style = (Style)myBorder.FindResource("transparent_border");
                    }
                    else
                    {
                        myBorder.Style = (Style)myBorder.FindResource("red_border");
                    }
                    
                    fild_borders.Children.Add(myBorder);
                    Grid.SetZIndex(myBorder, 2);

                    Grid grid = new Grid();
                    grid.RowDefinitions.Add(new RowDefinition());
                    grid.RowDefinitions.Add(new RowDefinition());
                    grid.RowDefinitions.Add(new RowDefinition());
                    grid.ColumnDefinitions.Add(new ColumnDefinition());
                    grid.ColumnDefinitions.Add(new ColumnDefinition());
                    grid.ColumnDefinitions.Add(new ColumnDefinition());
                    grid.SetBinding(Grid.RowProperty, $"location_cells_row[{i}]");
                    grid.SetBinding(Grid.ColumnProperty, $"location_cells_column[{j}]");

                    Ellipse ell = new Ellipse();
                    Grid.SetRow(ell, 1);
                    Grid.SetColumn(ell, 1);
                    ell.Style = (Style)ell.FindResource("turquoise_ellipse");
                    ell.SetBinding(VisibilityProperty, $"visibility_ellipses[{i}][{j}]");

                    grid.Children.Add(ell);
                    Grid.SetZIndex(grid, 4);

                    fild_borders.Children.Add(grid);
                }
            }
            
        }
    }
}
