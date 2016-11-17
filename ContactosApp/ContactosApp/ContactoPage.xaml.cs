using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ContactosApp
{
    public partial class ContactoPage : ContentPage

    {
        private AdministradorAccesoContactos _adminContactos;
        private Contacto _contacto;

        public ContactoPage(Contacto contact = null)
        {
            InitializeComponent();
            _adminContactos = new AdministradorAccesoContactos();
            tbiGuardar.Clicked += TbiGuardarOnClicked;

            if (contact != null)
            {
                _contacto = contact;
            }
        }

        private void TbiGuardarOnClicked(object sender, EventArgs eventArgs)
        {
            Contacto contacto;
            if (_contacto == null)
            {
                contacto = new Contacto();
                contacto.Direccion = txtDireccion.Text;
                contacto.Favorito = swFavorito.IsToggled;
                contacto.Foto = imgFoto.Source.ToString();
                contacto.Nombre = txtNombre.Text;
                contacto.Telefono = txtTelefono.Text;

                _adminContactos.AgregarContacto(contacto);
            }
            else
            {
                contacto = _contacto;
                contacto.Direccion = txtDireccion.Text;
                contacto.Favorito = swFavorito.IsToggled;
                contacto.Foto = imgFoto.Source.ToString();
                contacto.Nombre = txtNombre.Text;
                contacto.Telefono = txtTelefono.Text;
                
                _adminContactos.ModificarContacto(contacto);
            }
            
            
            Navigation.PopAsync();
        }
    }
}
