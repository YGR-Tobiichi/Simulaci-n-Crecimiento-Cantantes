using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace U5PSC24100562
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DatosIniciales ventana = new DatosIniciales();
        double calidad = 0.7;
        double nuevosSeguidores = 0;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = App.sim;
            ventana.Show();
            App.sim.fatiga = App.sim.fatiga + 0.05;
            App.sim.engagement = App.sim.engagement + (0.1 * calidad) - (0.1*App.sim.fatiga);
            nuevosSeguidores = Math.Round(App.sim.seguidores * App.sim.engagement*calidad*1.5);
            App.sim.seguidores = App.sim.seguidores + (int)nuevosSeguidores;
        }
        
    }

    public class Simulacion : INotifyPropertyChanged
    {
        private string _nombreArtista;
        private int _seguidores;
        private double _engagement;
        private double _fatiga;

        public string nombreArtista
        {
            get => _nombreArtista;
            set
            {
                if (value == "")
                {
                    throw new Exception("El nombre del artista no puede estar vacío.");
                }
                _nombreArtista = value;
                OnPropertyChanged(nameof(nombreArtista));
            }
        }
        public int seguidores
        {
            get => _seguidores;
            set
            {
                if (value < 0)
                {
                    _seguidores = 0;
                    return;
                }
                else
                {
                    _seguidores = value;
                    OnPropertyChanged(nameof(seguidores));
                }
            }
        }

        public double engagement
        {
            get => _engagement;
            set
            {
                if (value < 0)
                {
                    engagement = 0;
                    return;
                }
                else if (value > 1)
                {
                    engagement = 1;
                    return;
                }
                else
                {
                    _engagement = value;
                    OnPropertyChanged(nameof(engagement));
                }
            }
        }

        public double fatiga
        {
            get => _fatiga;
            set
            {
                if (value < 0)
                {
                    _fatiga = 0;
                    return;
                }
                else if (value > 1)
                {
                    _fatiga = 1;
                    return;
                }
                else
                {
                    _fatiga = value;
                    OnPropertyChanged(nameof(fatiga));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public Simulacion()
        {
            seguidores = 300;
            engagement = 0.08;
            fatiga = 0.1;
        }
    }
}