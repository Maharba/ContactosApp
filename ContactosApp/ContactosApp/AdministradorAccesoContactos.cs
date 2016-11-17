using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net;
using Xamarin.Forms;

namespace ContactosApp
{
    public class AdministradorAccesoContactos
    {
        private SQLiteConnection _conexionContactos;

        public AdministradorAccesoContactos()
        {
            _conexionContactos = DependencyService.Get<ISQLite>().ObtenerConexion();
            _conexionContactos.CreateTable<Contacto>();
        }

        public void AgregarContacto(Contacto contacto)
        {
            _conexionContactos.Insert(contacto);
        }

        public void EliminarContacto(Contacto contacto)
        {
            _conexionContactos.Delete(contacto);
        }

        public void ModificarContacto(Contacto contacto)
        {
            _conexionContactos.Update(contacto);
        }

        public ObservableCollection<Contacto> ObtenerContactos()
        {
            var listaContactos = _conexionContactos.Table<Contacto>().ToList();
            ObservableCollection<Contacto> contactos = new ObservableCollection<Contacto>(listaContactos);
            return contactos;
        }

        public Contacto ObtenerContacto(int id)
        {
            var listaContactos = _conexionContactos.Table<Contacto>().ToList();
            return listaContactos.SingleOrDefault(c => c.ID == id);
        }
    }
}
