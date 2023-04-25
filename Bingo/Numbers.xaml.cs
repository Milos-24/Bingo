using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for Numbers.xaml
    /// </summary>
    public partial class Numbers : Window
    {
        public static int[] list = new int[6];
        public Numbers()
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
            bool legit = true;

            if(int.TryParse(first.Text, out int value1))
            {
                list[0] = value1;

                if (list[0] > 48 || list[0] <1)
                {
                    legit = false;
                }

            }
            else
            {
                legit = false;
            }

            if (int.TryParse(second.Text, out int value2))
            {
                list[1] = value2;

                if (list[1] > 48 || list[1] < 1)
                {
                    legit = false;
                }

            }
            else
            {
                legit = false;
            }



            if (int.TryParse(third.Text, out int value3))
            {
                list[2] = value3;

                if (list[2] > 48 || list[2] < 1)
                {
                    legit = false;
                }

            }
            else
            {
                legit = false;
            }

            if (int.TryParse(fourth.Text, out int value4))
            {
                list[3] = value4;

                if (list[3] > 48 || list[3] < 1)
                {
                    legit = false;
                }

            }
            else
            {
                legit = false;
            }

            if (int.TryParse(fifth.Text, out int value5))
            {
                list[4] = value5;

                if (list[4] > 48 || list[4] < 1)
                {
                    legit = false;
                }

            }
            else
            {
                legit = false;
            }

            if (int.TryParse(sixth.Text, out int value6))
            {
                list[5] = value6;

                if (list[5] > 48 || list[5] < 1)
                {
                    legit = false;
                }

            }
            else
            {
                legit = false;
            }

            bool isUnique = list.Distinct().Count() == list.Count();


            if (legit && isUnique)
            {
                Game n = new Game();
                this.Hide();
                n.Show();
            }
        }
    }
}
