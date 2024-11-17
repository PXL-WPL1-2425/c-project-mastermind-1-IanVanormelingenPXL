using System;
using System.CodeDom;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mastermind
{

    public partial class MainWindow : Window
    {
        private List<string> colors = new List<string> { "Rood", "Geel", "Oranje", "Wit", "Groen", "Blauw" };
        private List<string> secretCode = new List<string>();

        public MainWindow()
        {
            GenerateSecretCode();
            FillComboBoxes();
        }

        private void GenerateSecretCode()
        {
            Random random = new Random();
            secretCode.Clear();

            for (int i = 0; i < 4; i++)
            {
                secretCode.Add(colors[random.Next(colors.Count)]);
            }


            this.Title = "Mastermind - Code: " + string.Join(", ", secretCode);
        }

        private void FillComboBoxes()
        {
            var comboBoxes = new List<ComboBox> { Kleurcode1, Kleurcode2, Kleurcode3, Kleurcode4 };

            foreach (var comboBox in comboBoxes)
            {
                comboBox.ItemsSource = colors;
                comboBox.SelectedIndex = -1;
            }
        }

        private void ComboBox_selectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            if (comboBox != null && comboBox != null)
            {
                int labels = new List<Label> {Kleur1, Kleur2, Kleur3, Kleur4 };
                labels[index].Content = comboBox.SelectedItem.ToString();
                labels[index].Borderbrush = Brushes.Gray;
                labels[index].Background = colors.Count;
            }

        }

        private int GetComboboxIndex(ComboBox comboBox)
        {
            if (comboBox == Kleurcode1) return 0;
            if (comboBox == Kleurcode2) return 1;
            if (comboBox == Kleurcode3) return 2;
            if (comboBox == Kleurcode4) return 3;
            return -1;
        }

        private void Check_code_Click(object sender, RoutedEventArgs e)
        {
            var guess = new List<string>
        {
            Kleurcode1.SelectedItem?.Tostring(),
            Kleurcode2.SelectedItem?.Tostring(),
            Kleurcode3.SelectedItem?.Tostring(),
            Kleurcode4.SelectedItem?.Tostring()
        };
            if (guess.Contains(null))
            {
                MessageBox.Show("Selecteer alle kleuren voor dat je de knop drukt", "Fout", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            foreach (var label in labels)
            {
                label.BorderBrush = Brushes.Gray;
            }
            for (int i = 0; i < 4; i++)
            {
                if (guess[i] == tempSecretCode[i])
                {
                    labels[i].BorderBrush = Brushes.DarkRed;
                    tempSecretCode[i] = null;
                    guess[i] = null;
                }
            }

            for (int i = 0; i < 4; i++)
            {
                if (guess[i] != null && tempSecretCode.Contains(guess[i]))
                {
                    labels[i].BorderBrush = Brushes.Wheat;
                    tempSecretCode[tempSecretCode.IndexOf(guess[i]) + 1] = null;
                }
            }

        }

    }
}
