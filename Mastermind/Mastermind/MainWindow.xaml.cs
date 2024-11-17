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

namespace Mastermind
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> colors = new List<string> { "Rood", "Geel", "Oranje", "Wit", "Groen", "Blauw" };
        private List<string> Geheimecode = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
            GenereerGeheimeCode();
            FillComboBoxes();
        }
        
        private void GenereerGeheimeCode()
        {
            Random random = new Random();
            Geheimecode.Clear();

            for (int i = 0; i < 4; i++)
            {
                Geheimecode.Add(colors[random.Next(colors.Count)]);
            }

            this.Title = "Mastermind - Code: " + string.Join(", ", Geheimecode);
        }
        
        private void FillComboBoxes()
        {
            var Comboboxes = new List<ComboBox> { Kleurcode1, Kleurcode2, Kleurcode3, Kleurcode4 };
             
            foreach (var combobox in Comboboxes)
            {
                combobox.ItemsSource = colors;
                combobox.SelectedIndex = -1;
            }

        }
    }
}