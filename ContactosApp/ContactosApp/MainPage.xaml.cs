using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Messaging;
using Xamarin.Forms;

namespace ContactosApp
{
    public partial class MainPage : ContentPage
    {
        private AdministradorAccesoContactos _adminContactos;

        public MainPage()
        {
            InitializeComponent();
            _adminContactos = new AdministradorAccesoContactos();

            tbiAgregar.Clicked += TbiAgregarOnClicked;
            lstContactos.ItemSelected += LstContactosOnItemSelected;
            lstContactos.ItemTapped += LstContactosOnItemTapped;
        }

        private void LstContactosOnItemTapped(object sender, ItemTappedEventArgs itemTappedEventArgs)
        {
            if (MessagingPlugin.PhoneDialer.CanMakePhoneCall)
            {
                var contacto = itemTappedEventArgs.Item as Contacto;
                if (contacto != null)
                {
                    MessagingPlugin.PhoneDialer.MakePhoneCall(contacto.Telefono, contacto.Nombre);
                }
            }
        }

        private void LstContactosOnItemSelected(object sender, SelectedItemChangedEventArgs selectedItemChangedEventArgs)
        {
            ListView lista = (ListView) sender;
            lista.SelectedItem = null;
        }

        private void TbiAgregarOnClicked(object sender, EventArgs eventArgs)
        {
            Navigation.PushAsync(new ContactoPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            lstContactos.ItemsSource = _adminContactos.ObtenerContactos();
        }

        private void MenuItemModificar_OnClicked(object sender, EventArgs e)
        {
            Contacto contacto = lstContactos.SelectedItem as Contacto;
            if (contacto != null)
            {
                Navigation.PushAsync(new ContactoPage(contacto));
            }
        }

        private void MenuItemEliminar_OnClicked(object sender, EventArgs e)
        {
            Contacto contacto = lstContactos.SelectedItem as Contacto;
            _adminContactos.EliminarContacto(contacto);
            lstContactos.ItemsSource = _adminContactos.ObtenerContactos();
        }
    }
}
