using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace ContactosApp
{
    public class Contacto : INotifyPropertyChanged
    {
        private int _id;
        private string _nombre;
        private string _telefono;
        private string _direccion;
        private bool _favorito;
        private string _foto;

        [AutoIncrement, PrimaryKey]
        public int ID
        {
            get { return _id; }
            set
            {
                _id = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(ID)));
            }
        }

        [NotNull]
        public string Nombre
        {
            get { return _nombre; }
            set
            {
                _nombre = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Nombre)));
            }
        }

        [NotNull]
        public string Telefono
        {
            get { return _telefono; }
            set
            {
                _telefono = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Telefono)));
            }
        }

        public string Direccion
        {
            get { return _direccion; }
            set
            {
                _direccion = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Direccion)));
            }
        }

        public bool Favorito
        {
            get { return _favorito; }
            set
            {
                _favorito = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Favorito)));
            }
        }

        public string Foto
        {
            get { return _foto; }
            set
            {
                _foto = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Foto)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
