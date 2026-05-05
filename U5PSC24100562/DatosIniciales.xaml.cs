using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace U5PSC24100562
{
    /// <summary>
    /// Lógica de interacción para DatosIniciales.xaml
    /// </summary>
    public partial class DatosIniciales : Window
    {
        public DatosIniciales()
        {
            InitializeComponent();
            DataContext = App.sim;
            App.sim.seguidores = 1000;
            App.sim.nombreArtista = "Yukari";
        }
    }
}