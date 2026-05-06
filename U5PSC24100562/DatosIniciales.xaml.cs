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
        }

        private void btnIniciarSimulacion_Click(object sender, RoutedEventArgs e)
        {
            App.sim.seguidores = int.Parse(txtSegudores.Text);
            App.semanasSimulacion = int.Parse(txtTiempoSimulacion.Text);
            App.intervaloSemana = int.Parse(cbIntervaloLanzamiento.Text);
            App.sim.nombreArtista = txtNombreArtista.Text;
            App.estrategiaMarketing = double.Parse(cbMarketing.Text);
            //App.sim.fatiga = App.sim.fatiga + 0.05;
            //App.sim.engagement = App.sim.engagement + (0.1 * App.calidad) - (0.1 * App.sim.fatiga);
            App.sim.iniciar = true;
            this.Close();
        }
    }
}