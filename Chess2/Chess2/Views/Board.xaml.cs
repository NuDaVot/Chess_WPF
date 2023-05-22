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
                for (int j = 0; j < 8; j++)
                {
                    Border myBorder = new Border();
                    myBorder.SetBinding(Grid.RowProperty, $"location_cells_row[{i}]");
                    myBorder.SetBinding(Grid.ColumnProperty, $"location_cells_column[{j}]");
                    myBorder.BorderThickness = new Thickness(3);
                    myBorder.BorderBrush = Brushes.SlateBlue;
                    //myBorder.SetBinding(, $"location_cells_column[{j}]");
                    //myBorder.MouseDown +=  new MouseButtonEventHandler(Border_MouseDown);

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
        private void ButtonCreatedByCode_Click(object sender, RoutedEventArgs e)
        {
            string sourceName = ((FrameworkElement)e.Source).Name;
            string senderName = ((FrameworkElement)sender).Name;

            Debug.WriteLine($"Routed event handler attached to {senderName}, " +
                $"triggered by the Click routed event raised by {sourceName}.");
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ((Border)sender).Background = Brushes.Gray;
        }
        //private void lbl1_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    Image lbl = (Image)sender;
        //    DragDrop.DoDragDrop(lbl, lbl.Source, DragDropEffects.Move);
        //}

        //private void txtTarget_Drop(object sender, DragEventArgs e)
        //{
        //    //MessageBox.Show(((string)e.Data.GetData(DataFormats.Text)).ToString());
        //  ((Image)sender).Source = (ImageSource)e.Data.GetData(DataFormats.UnicodeText);
        //}
        //public static Image global_sender;
        //private void Image_Drop(object sender, DragEventArgs e)
        //{
        //    //((Image) sender).Source = e.Source as ImageSource;

        //    //Image image = e.Source as Image;

        //    //((Image)sender).Source = image.Source;

        //    ((Image)sender).Source = global_sender.Source;
        //}

        //private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    // sender – объект, на котором произошло данное событие.
        //    Image lbl = sender as Image;
        //    global_sender = lbl;
        //    // Создаем источник.
        //    // Копируем содержимое метки Drop.
        //    // 1 параметр: Элемент управления, который будет источником.
        //    // 2 параметр: Данные, которые будут перемещаться.
        //    // 3 параметр: Эффект при переносе.
        //    DragDrop.DoDragDrop(lbl, lbl.Source, DragDropEffects.Move);

        //}

        //private void Image_DragEnter(object sender, DragEventArgs e)
        //{
        //    e.Effects = DragDropEffects.Copy;
        //}
    }
    
}
