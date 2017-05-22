using Caliburn.Micro;
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
using System.Windows.Shapes;
using TicTacToe.Models;
using TicTacToe.ViewModels;

namespace TicTacToe.Views
{
    /// <summary>
    /// Логика взаимодействия для WinView.xaml
    /// </summary>
    public partial class WinView : Window
    {
        MainViewModel mainViewModel;
        private string pathPicture;
        private string pathCross = "Resources/Cross.png";
        private string pathZero = "Resources/Zero.png";
        
        public WinView(MainViewModel main, StateCell signWinner)
        {
            mainViewModel = main;
            InitializeComponent();
            if (signWinner == StateCell.X)
            {
                image.Source = new BitmapImage(new Uri(pathCross, UriKind.Relative)); ;
            }
            if (signWinner == StateCell.O)
            {
                image.Source = new BitmapImage(new Uri(pathZero, UriKind.Relative)); ;
            }
        }
    
        public WinView()
        {
            PathPicture = pathZero;
            InitializeComponent();
        }

        private void NewGame(object sender, RoutedEventArgs e)
        {
            mainViewModel.NewGame();
            Close();
        }
        public string PathPicture
        {
            get { return pathPicture; }
            set
            {
                if (value == pathPicture) return;
                pathPicture = value;
            }
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
