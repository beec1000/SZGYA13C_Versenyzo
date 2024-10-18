using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Linq;
using SZGYA13C_Versenyzo;
using System.IO;

namespace VersenyzoGUI
{
    public partial class MainWindow : Window
    {
        List<Versenyzo> versenyzo = new List<Versenyzo>();
        public MainWindow()
        {
            InitializeComponent();
            versenyzoPontjai.TextChanged += VersenyzoPontjai_TextChanged;

        }
        private string[] GetPontArray(string input)
        {
            return input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }
        private void VersenyzoPontjai_TextChanged(object sender, TextChangedEventArgs e)
        {
            var pontArray = GetPontArray(versenyzoPontjai.Text);

            pontDB.Content = $"{pontArray.Length}db";

            foreach (var p in pontArray)
            {
                if (int.Parse(p) < 0 || int.Parse(p) > 10)
                {
                    MessageBox.Show("Az egyik pontszám nem 0-10 van!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }

            kiesoLegmagasabbPont.Content = pontArray.Max();
            kiesoLegalacsonyabbPont.Content = pontArray.Min();
            int ossz = 0;
            foreach (var p in pontArray)
            {
                ossz += int.Parse(p);
            }
            
            if (ossz < 3)
            {
                osszPont.Content = 0;
            }
            else
            {
                osszPont.Content = ossz;
            }

        }
        private void versenyzoHozzaadas_Click(object sender, RoutedEventArgs e)
        {
            var pontArray = GetPontArray(versenyzoPontjai.Text);

            if (string.IsNullOrWhiteSpace(versenyzoNev.Text))
            {
                MessageBox.Show("Kérjük, adja meg a versenyző nevét!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (versenyzo.Any(v => v.Nev == versenyzoNev.Text))
            {
                MessageBox.Show("Van már ilyen nevű versenyző!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Warning);
                versenyzoNev.Text = string.Empty;
            }
            else if (pontArray.Length != 6)
            {
                MessageBox.Show("A pontszámok száma nem megfelelő! Pontszámok száma: " + pontArray.Length, "Hiba", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                string ujVersenyzo = $"{versenyzoNev.Text};{string.Join(" ", pontArray)}";

                File.AppendAllLines(@"..\..\..\..\SZGYA13C_Versenyzo\src\selejtezo.txt", new[] { ujVersenyzo });

                MessageBox.Show("Az állomány bővítése sikeres volt!", "Siker", MessageBoxButton.OK, MessageBoxImage.Information);
                versenyzoNev.Text = string.Empty;
                versenyzoPontjai.Text = string.Empty;
            }

            
        }

    }
}