using CTOApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CTOApp.View.Clientes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientePM : ContentPage
    {
        public ClientePM(ClientesModel client)
        {
            InitializeComponent();
            BindingContext = client;
        }

        private void btnLlamar_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(lblTelefono.Text))
                {
                    PhoneDialer.Open(lblTelefono.Text);
                }
                else
                {
                    DisplayAlert("MENSAJE", "NO EXISTE TELÉFONO A MARCAR", "OK");
                }

            }
            catch (Exception)
            {
                DisplayAlert("ERROR", "NO SE PUEDO REALIZAR EL MARCADO TELÉFONICO", "OK");
            }
        }

        private void btnCreditos_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new VerCreditos(lblId.Text));
        }
    }
}