using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Bingo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string user;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e) 
        {
            Application.Current.Shutdown();
        }

        private void newGameButtonClick(object sender, RoutedEventArgs e)
        {
            user = username.Text;
            Numbers n = new Numbers();               
            this.Hide();
            n.Show();
        }

        private void leaderboardButton_Click(object sender, RoutedEventArgs e)
        {

            Leaderboard leaderboard= new Leaderboard();
            this.Hide();
            leaderboard.Show();
            

        }
    }
}
