using GraWStatkiFront;
using GraWStatkiFront.kontrola_gry;
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

            KontrolaGry kontroler = new KontrolaGry(PlanszaGracza, PlanszaKomputera);
        }
    }
}
