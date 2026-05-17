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
        int semanasPasadas = 0;
        Random random = new Random();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = App.sim;
            ventana.Show();
        }

        private void btnAvanzarCiclo_Click(object sender, RoutedEventArgs e)
        {
            App.sim.NuevosSeguidores = 0;
            if (semanasPasadas == App.intervaloSemana - 1 || App.sim.semanaActual == 0)
            {
                semanasPasadas = 0;
                App.sim.Lanzamiento = true;
                if (random.NextDouble() < 0.05 && App.sim.Calidad > 0.7)
                    App.sim.Viral = true;
            }
            else
            {
                App.sim.Lanzamiento = false;
                semanasPasadas++;
                App.sim.fatiga = App.sim.fatiga - 0.03;
                if (random.NextDouble() < 0.05)
                {
                    App.sim.engagement = App.sim.engagement * 0.9;
                    App.sim.seguidores = (int)(App.sim.seguidores * 0.95);
                }
                else
                    App.sim.NuevosSeguidores = App.sim.seguidores * (App.sim.engagement * 0.1);
            }
            if (App.sim.Lanzamiento)
            {
                App.sim.Calidad = 0.7;
                if (App.intervaloSemana == 1)
                    App.sim.Calidad = 0.6 + ((random.NextDouble() * 0.2) - 0.1);
                else if (App.intervaloSemana == 2)
                    App.sim.Calidad = 0.7 + ((random.NextDouble() * 0.2) - 0.1);
                else 
                    App.sim.Calidad = App.sim.Calidad + ((random.NextDouble() * 0.4) - 0.2);
                App.sim.fatiga = App.sim.fatiga + 0.05;
                App.sim.engagement = App.sim.engagement + (0.1 * App.sim.Calidad) - (0.1 * App.sim.fatiga);
                App.sim.NuevosSeguidores = App.sim.seguidores * App.sim.engagement * App.sim.Calidad * App.estrategiaMarketing;
                if (App.sim.Viral)
                    App.sim.NuevosSeguidores = App.sim.NuevosSeguidores * 2;
            }
            App.sim.seguidores = (int)(App.sim.seguidores + Math.Round(App.sim.NuevosSeguidores));
            App.sim.semanaActual++;
            App.sim.Viral = false;
            if (App.sim.semanaActual >= App.semanasSimulacion)
            {
                MessageBox.Show($"Simulación finalizada. Total de seguidores: {App.sim.seguidores}");
                btnAvanzarCiclo.IsEnabled = false;
            }
            lbLogEventos.Items.Add($"Semana: {App.sim.semanaActual}\n Seguidores: {App.sim.seguidores}\n Engagement: {App.sim.engagement:F2}\n Fatiga: {App.sim.fatiga:F2}\n Calidad: {App.sim.Calidad:F2}\n Lanzamiento: {(App.sim.Lanzamiento ? "Sí" : "No")}\n Viral: {(App.sim.Viral ? "Sí" : "No")}\n");
        }

        public class Simulacion : INotifyPropertyChanged
        {
            private string _nombreArtista;
            private int _seguidores;
            private double _engagement;
            private double _fatiga;
            private bool _iniciar;
            private int _semanaActual;
            private double _calidad;
            private bool _lanzamiento;
            private bool _viral;
            private double _nuevosSeguidores;

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
            public bool iniciar
            {
                get => _iniciar;
                set
                {
                    _iniciar = value;
                    OnPropertyChanged(nameof(iniciar));
                }
            }
            public int semanaActual
            {
                get => _semanaActual;
                set
                {
                    if (value < 0)
                    {
                        _semanaActual = 0;
                        return;
                    }
                    else
                    {
                        _semanaActual = value;
                        OnPropertyChanged(nameof(semanaActual));
                    }
                }
            }
            public double Calidad
            {
                get => _calidad;
                set
                {
                    if (value > 1)
                    {
                        _calidad = 1;
                        return;
                    }
                    _calidad = value;
                    OnPropertyChanged(nameof(Calidad));
                }
            }
            public bool Lanzamiento
            {
                get => _lanzamiento;
                set
                {
                    _lanzamiento = value;
                    OnPropertyChanged(nameof(Lanzamiento));
                }
            }
            public bool Viral
            {
                get => _viral;
                set
                {
                    _viral = value;
                    OnPropertyChanged(nameof(Viral));
                }
            }
            public double NuevosSeguidores
            {
                get => _nuevosSeguidores;
                set
                {
                    _nuevosSeguidores = value;
                    OnPropertyChanged(nameof(NuevosSeguidores));
                }
            }


            public event PropertyChangedEventHandler PropertyChanged;

            protected void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            public Simulacion()
            {
                nombreArtista = " ";
                seguidores = 300;
                engagement = 0.08;
                fatiga = 0.1;
                iniciar = false;
                semanaActual = 0;
                Calidad = 0.7;
                Lanzamiento = false;
                Viral = false;
                NuevosSeguidores = 0;
            }
        }
    }
}