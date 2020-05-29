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

namespace CTOApp.View.Anuncios
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Anuncios : ContentPage
    {
        VMNoticias vm = new VMNoticias();
        public Anuncios()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            CargaNoticias();
        }

        private async void CargaNoticias()
        {
            try
            {
                UserDialogs.Instance.ShowLoading("Buscando");
                string JsonUrl = "http://convengamos.homedns.org/ctoservice/api/Noticias/Noticia";
                var client = new HttpClient();
                var responseString = await client.GetStringAsync(JsonUrl);
                string resp = Convert.ToString(responseString);
                var obj = JsonConvert.DeserializeObject<object>(resp);
                string data = Convert.ToString(obj);
                vm.listNews = JsonConvert.DeserializeObject<List<NoticiasModel>>(data);
                cvNoticias.ItemsSource = vm.listNews;
                UserDialogs.Instance.HideLoading();
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await DisplayAlert("MENSAJE", "ERROR. AVISE AL ADMINISTRADOR", "OK");
            }
        }

    }
}