using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace Kalkulator_Izvrsitelj
{
    class Dinar
    {
        MainWindow y;
        public Dinar(MainWindow form)
        {
            y = form;
        }

        public void OsnovniSud()
        {
            // osnovni sud
            double os;
            var dug = Convert.ToInt64(y.Dug.Text);
            if (dug > 0 && dug <= 10000)
            {
                os = 1900 / 3D;
                var rrr = Convert.ToString(System.Math.Round(os, 2));
                y.sudskataksa.Text = rrr;
            }
            if (dug > 10000 && dug <= 100000)
            {

                os = (1900D + dug / 100D * 4D) / 3D;
                var rrr = Convert.ToString(System.Math.Round(os, 2));
                y.sudskataksa.Text = rrr;
            }
            if (dug > 100000 && dug <= 500000)
            {

                os = (9800D + dug / 100D * 2D) / 3D;
                var rrr = Convert.ToString(System.Math.Round(os, 2));
                y.sudskataksa.Text = rrr;
            }
            if (dug > 500000 && dug <= 1000000)
            {

                os = (29300D + dug / 100D * 1D) / 3D;
                var rrr = Convert.ToString(System.Math.Round(os, 2));
                y.sudskataksa.Text = rrr;
            }
            if (dug > 1000000)
            {
                os = (48800D + dug / 100D * 0.5D) / 3D;
                if (os >= 97500)
                {
                    os = 32500;
                    var rrr = Convert.ToString(System.Math.Round(os, 2));
                    y.sudskataksa.Text = rrr;
                }
                else
                {
                    var rrr = Convert.ToString(System.Math.Round(os, 2));
                    y.sudskataksa.Text = rrr;
                }
            }
            if (dug <= 0)
            {
                string message = "Uneli ste neodgovarajucu vrednost";
                string title = "Greska";
                MessageBox.Show(message, title);
            }
        }

        public void PrivredniSud()
        {

            double os;
            var dug = Convert.ToInt64(y.Dug.Text);
            if (dug > 0 && dug <= 10000)
            {
                os = 1300 / 3D;
                var rrr = Convert.ToString(System.Math.Round(os, 2));
                y.sudskataksa.Text = rrr;
            }
            if (dug > 10000 && dug <= 100000)
            {

                os = (3900D + dug / 100D * 6D) / 3D / 3D;
                var rrr = Convert.ToString(System.Math.Round(os, 2));
                y.sudskataksa.Text = rrr;
            }
            if (dug > 100000 && dug <= 1000000)
            {

                os = (15600D + dug / 100D * 2D) / 3D / 3D;
                var rrr = Convert.ToString(System.Math.Round(os, 2));
                y.sudskataksa.Text = rrr;
            }
            if (dug > 1000000 && dug <= 10000000)
            {

                os = (54600D + dug / 100D * 1D) / 3D / 3D;
                var rrr = Convert.ToString(System.Math.Round(os, 2));
                y.sudskataksa.Text = rrr;
            }
            if (dug > 1000000)
            {
                os = (249600D + dug / 100D * 0.5D) / 3D / 3;
                if (os >= 390000)
                {
                    os = 43333;
                    var rrr = Convert.ToString(System.Math.Round(os, 2));
                    y.sudskataksa.Text = rrr;
                }
                else
                {
                    var rrr = Convert.ToString(System.Math.Round(os, 2));
                    y.sudskataksa.Text = rrr;
                }
            }
            if (dug <= 0)
            {
                string message = "Uneli ste neodgovarajucu vrednost";
                string title = "Greska";
                MessageBox.Show(message, title);
            }
        }

        public void Math()
        {
            if (y.Dug.Text != "")
            {
                if (y.Osnovni.IsSelected == true)
                {

                    OsnovniSud();
                }
                else
                {

                    PrivredniSud();
                }
            }
            else { }
        }


    }
}
