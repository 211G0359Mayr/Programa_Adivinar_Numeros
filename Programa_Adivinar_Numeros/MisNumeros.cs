using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Programa_Adivinar_Numeros
{
    public class MisNumeros : INotifyPropertyChanged
    {

        private int NumeroGenerado;
        public int UsuarioNumero { get; set; }

        public string? GanoPerdio { get; set; }

        private byte Oportunidades;

        public event PropertyChangedEventHandler? PropertyChanged;

        public byte oportunidad
        {
            get { return Oportunidades; }
            set { Oportunidades = value; }
        }

        public string Pista { get; set; } = "";

        public bool Juego { get; set; } = false;

        public void Generar()
        {
            Random r = new Random();
            NumeroGenerado = r.Next(1, 5000);
            Oportunidades = 10;
            Juego = true;
            Pista= string.Empty;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }

        public void Resultado()
        {
            if (NumeroGenerado == UsuarioNumero)
            {
                GanoPerdio = "ganaste!!";
                Juego = false;
            }
            if (UsuarioNumero < NumeroGenerado)
            {
                Pista = "Pista: El numero es mayor";
                oportunidad--;
            }
            if (UsuarioNumero > NumeroGenerado)
            {
                Pista = "Pista: El numero es menor";
                oportunidad--;
            }
            if(oportunidad==0)
            {
                Juego=false;
                Pista= string.Empty;
                GanoPerdio= "Perdiste, Intentalo de nuevo";
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }

        public ICommand Iniciarcom { get; set; }
        public ICommand Vercom { get; set;}

        public MisNumeros()
        {
            Iniciarcom = new RelayCommand(Generar);
            Vercom = new RelayCommand(Resultado);
        }
    }
}
