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
        Simulacion sim = new Simulacion();
        DatosIniciales ventana = new DatosIniciales();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = sim;
            ventana.Show();
            this.Close();
        }
        
    }

    class Simulacion : INotifyPropertyChanged
    {
        private int _seguidores;
        private double _engagement;
        private double _fatiga;

        public int seguidores
        {
            get => _seguidores;
            set
            {
                if (_seguidores != value)
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
                if (_engagement != value)
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
                if (_fatiga != value)
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