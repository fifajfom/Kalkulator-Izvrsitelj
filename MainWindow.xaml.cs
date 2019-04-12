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

namespace Kalkulator_Izvrsitelj
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {string Tst { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Kurs x = new Kurs(this);
            x.KursMain();
        }

    private void Dug_TextChanged(object sender, TextChangedEventArgs e)
    {  
            Kurs x = new Kurs(this);
            x.Dug();
        }

   public void Izracunaj_Click(object sender, RoutedEventArgs e)
        {
            if (Tst=="Dinar")
            {
                Dinar x = new Dinar(this);
                x.Math();
            }
            if (Tst == "Euro")
            {
                Euro x = new Euro(this);
                x.Math();
            }
        }


        // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // //        
        public void Cvaluta_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {   
            if (Cvaluta.SelectedIndex == 0)
            {

                Tst = "Dinar";
            }
            if (Cvaluta.SelectedIndex == 1)
            {

                Tst = "Euro";
            }
            else { }

        }



    }
}
