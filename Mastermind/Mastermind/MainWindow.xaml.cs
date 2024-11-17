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

        // Toon de geheime code in de titel voor testdoeleinden
        this.Title = "Mastermind - Code: " + string.Join(", ", secretCode);
    }

    private void FillComboBoxes()
    {
        var comboBoxes = new List<ComboBox> { ComboBox1, ComboBox2, ComboBox3, ComboBox4 };

        foreach (var comboBox in comboBoxes)
        {
            comboBox.ItemsSource = colors;
            comboBox.SelectedIndex = -1; // Leeg laten in het begin
        }
    }
}
