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

namespace Bingo
{
    /// <summary>
    /// Interaction logic for Decision.xaml
    /// </summary>
    public partial class Decision : Window
    {
        public Decision()
        {
            
            InitializeComponent();
            CheckScore();
        }

        public void CheckScore()
        { 
            if(Game.score==0)
            {
                finalLabel.Content = "Better luck next time.";
            }
            else
            {
                finalLabel.Content = "Congratulations you've won " + Game.score + " points!";
            }
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

        private void menuButtonClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Hide();
            mainWindow.Show();
            
        }

        private void tryAgainButtonClick(object sender, RoutedEventArgs e)
        {
            Numbers numbers = new Numbers();
            this.Hide();
            numbers.Show();
        }

        private void leaderboardButtonClick(object sender, RoutedEventArgs e)
        {
            Leaderboard leaderboard = new Leaderboard();
            this.Hide();
            leaderboard.Show();
        }

    }
}
