using System;
using System.Collections.Generic;
using System.IO;
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
using Path = System.IO.Path;

namespace Bingo
{
    /// <summary>
    /// Interaction logic for Leaderboard.xaml
    /// </summary>
    public partial class Leaderboard : Window
    {
        public Leaderboard()
        {
            InitializeComponent();
            Display();
        }

        private void Display() { 

            string fileName = @"leaderboard.txt";
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            string strdata = File.ReadAllText(path);

            string[] rowdata = strdata.Split("\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            List<User> users = new List<User>();


            foreach (string row in rowdata)
            {
                string[] split = row.Split(" ");
                int[] luckyNumbers = { int.Parse(split[2]), int.Parse(split[3]), int.Parse(split[4]), int.Parse(split[5]), int.Parse(split[6]), int.Parse(split[7]) };
                User user = new User(split[0], int.Parse(split[1]), luckyNumbers);
                users.Add(user);
            }

            var sorted = users.OrderByDescending(s => s.score);



            myDataGrid.ItemsSource = sorted;
            
            /*string sortedUsers="";

            foreach(User u in sorted)
            {
                sortedUsers +="Username: " + u.name + "     Points: " + u.score + "    Lucky Numbers: " + u.numbers[0] + " " + u.numbers[1] + " " + u.numbers[2] + " " + u.numbers[3] + " " + u.numbers[4] + " " + u.numbers[5] + " " + "\n";
            }
            usersTextBlock.Text = sortedUsers;*/
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

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow= new MainWindow();
            this.Hide();
            mainWindow.Show();
        }
    }
}
