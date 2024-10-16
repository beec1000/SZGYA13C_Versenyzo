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

namespace VersenyzoGUI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            versenyzoPontjai.TextChanged += VersenyzoPontjai_TextChanged;

            

        }
        private void VersenyzoPontjai_TextChanged(object sender, TextChangedEventArgs e)
        {
            var pontok = versenyzoPontjai.Text;
            var pontArray = pontok.Split(new[] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries);

            pontDB.Content = $"{pontArray.Length}db";

            foreach (var p in pontArray)
            {
                if (int.Parse(p) < 0 || int.Parse(p) > 10)
                {
                    MessageBox.Show("Az egyik pontszám nem 0-10 van!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }

            kiesoLegmagasabbPont.Content = pontArray.MaxBy().First();

        }
    }
}