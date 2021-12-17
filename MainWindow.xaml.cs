using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            foreach (UIElement el in uGrid.Children)
            {
                if (el is Button)
                {
                    ((Button)el).Click += ButtonClick;
                }
            }
        }
        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            string str = (string)((Button)e.OriginalSource).Content;
            if (str == "%")
            {
                double number = Convert.ToDouble(textLabel.Text) / 100;
                textLabel.Text = number.ToString();
            }
            else if (str == "C")
                textLabel.Text = "";
            else if (str == "CE")
                textLabel.Text = "0";
            else if (str == "←")
            {
                textLabel.Text = textLabel.Text.Substring(0, textLabel.Text.Length - 1);
            }
            else if (str == "1/x")
            {
                double number = 1 / Convert.ToDouble(textLabel.Text);
                textLabel.Text = number.ToString();
            }
            else if (str == "х²")
            {
                double number = Math.Pow(Convert.ToDouble(textLabel.Text), 2);
                textLabel.Text = number.ToString();
            }
            else if (str == "√х")
            {
                double number = Math.Sqrt(Convert.ToDouble(textLabel.Text));
                textLabel.Text = number.ToString();
            }
            else if (str == "+/-")
            {
                textLabel.Text = (Convert.ToDouble(textLabel.Text) < 0) ? textLabel.Text.Replace("-", "") : ("-" + textLabel.Text);
            }
            
            else if (str == "=")
            {
                textLabel.Text = textLabel.Text.Replace(",", ".");
                textLabel.Text = textLabel.Text.Replace("÷", "/");
                textLabel.Text = textLabel.Text.Replace("х", "*");
                string value = new DataTable().Compute(textLabel.Text, null).ToString();
                textLabel.Text = value.Replace(".", ",");
            }
            else
                textLabel.Text += str;
        }
    }
}
