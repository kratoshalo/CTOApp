using Acr.UserDialogs;
using CTOApp.Model;
using CTOApp.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CTOApp.View.Clientes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BuscarCliente : ContentPage
    {
        VMClientes vm = new VMClientes();
        public BuscarCliente()
        {
            InitializeComponent();
        }

        private async void btnBuscar_Clicked(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(sbBuscar.Text))
            {
                await DisplayAlert("MENSAJE", "INGRESE EL CLIENTE A BUSCAR", "OK");
                sbBuscar.Focus();
                return;
            }

            try
            {
                UserDialogs.Instance.ShowLoading("Buscando");
                string JsonUrl = "http://convengamos.homedns.org/ctoservice/api/Clientes/GetCliente/?cliente=";
                var client = new HttpClient();
                var responseString = await client.GetStringAsync(JsonUrl + sbBuscar.Text);
                string resp = Convert.ToString(responseString);
                var obj = JsonConvert.DeserializeObject<object>(resp);
                string data = Convert.ToString(obj);
                vm.listClients = JsonConvert.DeserializeObject<List<ClientesModel>>(data);

                lvClientes.ItemsSource = vm.listClients;
                UserDialogs.Instance.HideLoading();
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await DisplayAlert("MENSAJE", "ERROR. AVISE AL ADMINISTRADOR", "OK");
            }

        }

        private void lvClientes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var seleccionado = e.SelectedItem as ClientesModel;
            ClientesModel client = new ClientesModel();
            client = vm.listClients.First(x => x.Cliente.Equals(seleccionado.Cliente.ToString()));

            if (seleccionado.personalidadjuridicaId.Equals(2))
            {
                Navigation.PushAsync(new ClientePM(client));
            }
            else
            {
                Navigation.PushAsync(new ClientePF(client));
            }

        }


    }
}