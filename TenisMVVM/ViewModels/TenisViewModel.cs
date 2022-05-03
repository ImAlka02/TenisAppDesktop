using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TenisMVVM.Models;

namespace TenisMVVM.ViewModels
{
    public class TenisViewModel : INotifyPropertyChanged
    {
        //Lista=Coleccion
        public ObservableCollection<Tenis> Coleccion { get; set; } = new ObservableCollection<Tenis>();

        private Tenis? tenis;


        void ProperyChanged(string? p = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(p));
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        public Tenis? Tenis
        {
            get { return tenis; }
            set
            {
                tenis = value;
                ProperyChanged("Pelicula");
            }
        }

        public string Vista { get; set; } = "VistaPrincipal";
        public string Error { get; set; } = "";

        int tenisSeleccionadoEditar;

        //Comandos
        public ICommand CancelarCommand { get; set; }
        public ICommand AgregarCommand { get; set; }
        public ICommand GuardarCommand { get; set; }
        public ICommand EliminarCommand { get; set; }
        public ICommand CambiarVistaCommand { get; set; }

        public TenisViewModel()
        {
            CancelarCommand = new RelayCommand(Cancelar);
            AgregarCommand = new RelayCommand(Agregar);
            EliminarCommand = new RelayCommand(Eliminar);
            CambiarVistaCommand = new RelayCommand<string>(CambiarVista);
            GuardarCommand = new RelayCommand(GuardarComando);
            Cargar();
        }

        //Serializado y deserializado
        private void Guardar()
        {
            var json = JsonConvert.SerializeObject(Coleccion);
            File.WriteAllText("tenis.json", json);
        }

        private void Cargar()
        {
            if (File.Exists("tenis.json"))
            {
                var json = File.ReadAllText("tenis.json");
                var datos = JsonConvert.DeserializeObject<ObservableCollection<Tenis>>(json);

                if (datos != null)
                {
                    Coleccion = datos;
                }
                else
                {
                    Coleccion = new ObservableCollection<Tenis>();
                }
            }
        }

        //Metodos

        private void GuardarComando()
        {
            if(Coleccion != null)
            {
                Coleccion[tenisSeleccionadoEditar] = Tenis;
                Guardar();
                ProperyChanged();
            }
        }
        private void Cancelar()
        {
            CambiarVista("VistaPrincipal");
            Tenis = null;
        }

        private void Agregar()
        {
            Coleccion.Add(Tenis);

            CambiarVista("VistaPrincipal");
            Guardar();
        }

        private void Eliminar()
        {
            if (Tenis != null)
            {
                Coleccion.Remove(Tenis);
                Guardar();
                ProperyChanged();

            }
        }

        private void CambiarVista(string x)
        {
            Vista = x;


            if (Vista == "Agregar")
            {
                Tenis = new Tenis();
            }

            if (Vista == "Editar")
            {
                if (tenis != null)
                {
                    Tenis clon = new Tenis()
                    {
                        Nombre = tenis.Nombre,
                        Valuado = tenis.Valuado,
                        Foto = tenis.Foto,
                        Historia = tenis.Historia,
                    };

                    tenisSeleccionadoEditar = Coleccion.IndexOf(tenis); 

                    Tenis = clon;
                }
            }

            ProperyChanged();

        }
    }
}
