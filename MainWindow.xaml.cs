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

namespace CalculatorSolution
{
    /// <summary>
    /// doubleeraction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public double EersteGetal { get; set; }
        public double TweedeGetal { get; set; }
        public double Antwoord { get; set; }
        public string VrijeInvoer { get; set; }

        List<string> Berekeningen = new List<string>();

        public MainWindow()
        {
            InitializeComponent();

            
        }


        private void btnBereken_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(tbxVrijeInvoer.Text))
            {
                this.doggo_parse(tbxVrijeInvoer.Text);
                Antwoord = Bereken(EersteGetal, TweedeGetal);
                this.ToonUitkomst();
                this.RefreshUI();
                this.tbxVrijeInvoer.Text = ""; 
            }
            else if (string.IsNullOrWhiteSpace(tbxEersteGetal.Text) | string.IsNullOrWhiteSpace(tbxTweedeGetal.Text))
                MessageBox.Show("Vul een waarde in!");
            else
            {
                EersteGetal = double.Parse(tbxEersteGetal.Text);

                TweedeGetal = double.Parse(tbxTweedeGetal.Text);

                Antwoord = Bereken(EersteGetal, TweedeGetal);
                this.ToonUitkomst();
                this.RefreshUI();
            }

        }

        public double Bereken(double EersteGetal, double TweedeGetal)
        {
          
            if (btnOptellen.IsChecked == true)
            {
                return EersteGetal + TweedeGetal;
            }
            else if (btnAftrekken.IsChecked == true)
            {
                return EersteGetal - TweedeGetal;
            }
            else if (btnVermenigvuldigen.IsChecked == true)
            {
                return EersteGetal * TweedeGetal;
            }
            else if (btnDelen.IsChecked == true)
            {
                return EersteGetal / TweedeGetal;
            }
            return 0;

        }

        private void ToonUitkomst()
        {
            if (btnOptellen.IsChecked == true)
            {
                lblAntwoord.Content = EersteGetal.ToString() + "+" + TweedeGetal.ToString() + "=" + Antwoord.ToString();
                Berekeningen.Add(lblAntwoord.Content.ToString());

            }
            else if (btnAftrekken.IsChecked == true)
            {
                lblAntwoord.Content = EersteGetal.ToString() + "-" + TweedeGetal.ToString() + "=" + Antwoord.ToString();
                Berekeningen.Add(lblAntwoord.Content.ToString());

            }
            else if (btnVermenigvuldigen.IsChecked == true)
            {
                lblAntwoord.Content = EersteGetal.ToString() + "x" + TweedeGetal.ToString() + "=" + Antwoord.ToString();
                Berekeningen.Add(lblAntwoord.Content.ToString());

            }
            else if (btnDelen.IsChecked == true)
            {
                lblAntwoord.Content = EersteGetal.ToString() + "/" + TweedeGetal.ToString() + "=" + Antwoord.ToString();
                Berekeningen.Add(lblAntwoord.Content.ToString());
            }

          
        }
        private void RefreshUI()
        {
            lbxBerekeningen.ItemsSource = null;
            lbxBerekeningen.ItemsSource = Berekeningen;
        }

        private void btnHistorieWissen_Click(object sender, RoutedEventArgs e)
        {
            Berekeningen.Clear();
            RefreshUI();
        }

        private void doggo_parse(string input)
        {
            string[] tweeGetallen = new string [0];
            
            // check what operator the string contains
            if(input.Contains("*"))
            {
                btnVermenigvuldigen.IsChecked = true;
                tweeGetallen = tbxVrijeInvoer.Text.Split('*');
            }
            else if (input.Contains("+"))
            {
                btnOptellen.IsChecked = true;
                tweeGetallen = tbxVrijeInvoer.Text.Split('+');
            }
            else if (input.Contains("-"))
            {
                btnAftrekken.IsChecked = true;
                tweeGetallen = tbxVrijeInvoer.Text.Split('-');
            }
            else if (input.Contains("/"))
            {
                btnDelen.IsChecked = true;
                tweeGetallen = tbxVrijeInvoer.Text.Split('/');
            }

            EersteGetal = double.Parse(tweeGetallen[0]);
            TweedeGetal = double.Parse(tweeGetallen[1]);
        }

    }
}
