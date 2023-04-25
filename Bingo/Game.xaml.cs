using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        List<Label> labelList = new List<Label>();
        int[] numbers = new int[48];
        public static int score;
        public Game()
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
        private void LoadedWindow(object sender, RoutedEventArgs e)
        {
            firstNumber.Content= Numbers.list[0].ToString();
            secondNumber.Content= Numbers.list[1].ToString();
            thirdNumber.Content= Numbers.list[2].ToString();
            fourthNumber.Content= Numbers.list[3].ToString();
            fifthNumber.Content= Numbers.list[4].ToString();
            sixthNumber.Content= Numbers.list[5].ToString();

            for (int i = 0; i<numbers.Length; i++)
            {
                Label l = new Label();
                l.Height = 90;
                l.Width = 87;
                l.FontSize = 35;
                l.Foreground = Brushes.White;
                numbers[i] = i+1;
                l.Content = numbers[i];
                matrix.Children.Add(l);
                labelList.Add(l);
            }
        }
        private void StartButtonClick(object sender, RoutedEventArgs e)
        {
            DrawNumber();
            buttonStart.IsEnabled=false;
        }

        private async void DrawNumber()
        {
            int[] arrDrawnNumbers = new int[35];
            int tmp = 0, numOfDrawnNumbers=0, i, factor=0;
            bool won4=true, won5=true;

            while (arrDrawnNumbers[34].Equals(0))
            {
                int n = new Random().Next(1, 49);
                bool b = false;

                for(int j = 0; j < arrDrawnNumbers.Length; j++)
                {
                    if (arrDrawnNumbers[j].Equals(n))
                        b = true;
                }
                
                if (b == false)
                {                    
                    arrDrawnNumbers[tmp] = n;
                    tmp++;
                }
            }
 
            for(i = 0;i< arrDrawnNumbers.Length; i++) 
            {
                currentNumber.Content = arrDrawnNumbers[i];
               
                foreach (Label l in labelList)
                {
                    if (l.Content.Equals(arrDrawnNumbers[i]))
                    {
                        l.Foreground = Brushes.DeepSkyBlue;

                        for(int j =0;j<Numbers.list.Length;j++)
                        {
                            if (Numbers.list[j] == arrDrawnNumbers[i])
                            {
                                if(j== 0)
                                {
                                    firstNumber.Foreground= Brushes.Green;
                                    numOfDrawnNumbers++;
                                }
                                else if (j == 1)
                                {
                                    secondNumber.Foreground = Brushes.Green;
                                    numOfDrawnNumbers++;
                                }
                                else if (j == 2)
                                {
                                    thirdNumber.Foreground = Brushes.Green;
                                    numOfDrawnNumbers++;
                                }
                                else if (j == 3)
                                {
                                    fourthNumber.Foreground = Brushes.Green;
                                    numOfDrawnNumbers++;
                                }
                                else if (j == 4)
                                {
                                    fifthNumber.Foreground = Brushes.Green;
                                    numOfDrawnNumbers++;
                                }
                                else if (j == 5)
                                {
                                    sixthNumber.Foreground = Brushes.Green;
                                    numOfDrawnNumbers++;
                                }

                            }
                        }
                    }
                }

                if(numOfDrawnNumbers == 6)
                {
                    factor = arrDrawnNumbers.Length - i;
                    break;
                }
                else if(numOfDrawnNumbers == 5 && won5 == true) 
                {
                    factor = arrDrawnNumbers.Length - i;
                    won5 = false;
                }
                else if(numOfDrawnNumbers == 4 && won4 == true)
                {
                    factor = arrDrawnNumbers.Length - i;
                    won4= false;
                }

                await Task.Delay(1000);
            }

            if (numOfDrawnNumbers>3)
            {
                int points=0;
                if (numOfDrawnNumbers == 6)
                {
                    points = factor;
                    points *= 3;
                }
                else if(numOfDrawnNumbers == 5)
                {
                    points = factor;
                }
                else if(numOfDrawnNumbers == 4)
                {
                    points = factor;
                    points /= 2;
                }

                string file = MainWindow.user + " " + points + " " + Numbers.list[0] + " " + Numbers.list[1] + " " + Numbers.list[2] + " " + Numbers.list[3] + " " + Numbers.list[4] + " " + Numbers.list[5] + " " + Environment.NewLine;
                string fileName = @"leaderboard.txt";
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

                File.AppendAllText(path, file);

                score = points;

                Decision d = new Decision();

                this.Hide();

                d.Show();
            }
            else
            {
                int points = 0;

                score = points;

                Decision d = new Decision();

                this.Hide();

                d.Show();
            
            }
        }
    }
}
