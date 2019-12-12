using GraWStatkiFront;
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

namespace GraWStatki
{
    /// <summary>
    /// Interakcja dla MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GeneratorPol generatorPol = new GeneratorPol(PierwszyGrid);
            generatorPol.TworzSiatke();

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    TextBlock textblock = new TextBlock();
                    textblock.Background = new SolidColorBrush(Colors.White);
                    textblock.Text = $"{i}_{j}";

                    Grid.SetRow(textblock, i);
                    Grid.SetColumn(textblock, j);
                    PierwszyGrid.Children.Add(textblock);
                }
            }
        }
    }
}
