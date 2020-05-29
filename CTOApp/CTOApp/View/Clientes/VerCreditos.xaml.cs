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
    public partial class VerCreditos : ContentPage
    {
        VMCreditos vm = new VMCreditos();

        public VerCreditos(string socioid)
        {
            InitializeComponent();
            CargaDataCredits(Convert.ToInt32(socioid));
        }

        private async void CargaDataCredits(int id = 0)
        {
            try
            {
                UserDialogs.Instance.ShowLoading("Buscando");
                string JsonUrl = "http://convengamos.homedns.org/ctoservice/api/Pagare/GetPagares?id=";
                var client = new HttpClient();
                var responseString = await client.GetStringAsync(JsonUrl + id);
                string resp = Convert.ToString(responseString);
                var obj = JsonConvert.DeserializeObject<object>(resp);
                string data = Convert.ToString(obj);
                vm.listaCreditos = JsonConvert.DeserializeObject<List<CreditosModel>>(data);

                if (vm.listaCreditos.Count() > 0) {
                    cvCreditos.ItemsSource = vm.listaCreditos;
                } else {
                    lblMensaje.IsVisible = true;
                }
                                
                UserDialogs.Instance.HideLoading();
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await DisplayAlert("MENSAJE", "ERROR. AVISE AL ADMINISTRADOR", "OK");
            }

        }

        private void cvCreditos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var credito = e.CurrentSelection.FirstOrDefault() as CreditosModel;
            Navigation.PushAsync(new Credito(credito));
        }
    }
}