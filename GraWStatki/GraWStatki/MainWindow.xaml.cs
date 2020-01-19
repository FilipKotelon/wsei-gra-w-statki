using GraWStatkiFront;
using GraWStatkiFront.KontrolaGry;
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
            List<Button> poziomyTrudnosci = new List<Button> { PoziomLatwy, PoziomZaawansowany, PoziomTrudny };

            G_KontrolaGry kontroler = new G_KontrolaGry(PlanszaGracza, PlanszaKomputera, NowaGra, Komunikat, PopupTrudnosci, poziomyTrudnosci);
        }
    }
}
