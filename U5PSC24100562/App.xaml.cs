using System.Configuration;
using System.Data;
using System.Windows;
using static U5PSC24100562.MainWindow;

namespace U5PSC24100562
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Simulacion sim = new Simulacion();
        public static int intervaloSemana;
        public static double estrategiaMarketing;
        public static int semanasSimulacion;
        public static double calidad = 0.7;
    }

}
