﻿using System;
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
    /// Логика взаимодействия для BoardView.xaml
    /// </summary>
    public partial class BoardView : Page
    {
        public BoardView()
        {
            InitializeComponent();
            //var viewModel = new BoardViewModel(true); // Здесь передайте нужные параметры
            //DataContext = viewModel;
        }
    }
    
}
