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
using Entry = Microcharts.Entry;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microcharts;
using SkiaSharp;

namespace CTOApp.View.Cartera
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cartera : ContentPage
    {
        VMCartera vm = new VMCartera();

        public Cartera()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            CargaPicker();
        }

        private async void CargaPicker()
        {
            pkOficina.ItemsSource = null;

            try
            {
                UserDialogs.Instance.ShowLoading("Cargando Oficinas");
                string JsonUrl = "http://convengamos.homedns.org/ctoservice/api/Cartera/Cartera";
                var client = new HttpClient();
                var responseString = await client.GetStringAsync(JsonUrl);
                string resp = Convert.ToString(responseString);
                var obj = JsonConvert.DeserializeObject<object>(resp);
                string data = Convert.ToString(obj);
                vm.listaGOficina = JsonConvert.DeserializeObject<List<CarteraModel>>(data);
                pkOficina.ItemsSource = vm.listaOficina();
                UserDialogs.Instance.HideLoading();
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await DisplayAlert("MENSAJE", "ERROR. AVISE AL ADMINISTRADOR", "OK");
            }
        }

        private void pkOficina_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                UserDialogs.Instance.ShowLoading("Cargando información");
                var seleccionado = pkOficina.SelectedItem as pickerOficina;

                lblSaldoAtrasado.Text = "";
                lblSaldoVigente.Text = "";
                lblSaldoVencida.Text = "";

                decimal vigente = 0;
                decimal atrasada = 0;
                decimal vencida = 0;
                string saldo = "";

                if (seleccionado.value.Equals("TODAS"))
                {
                    saldo = vm.listaGOficina.Sum(x => x.Capital + x.Interes + x.Moratorios).ToString("C");
                    vigente = vm.listaGOficina.Where(x => x.Estado.Equals("VIGENTE")).Sum(x => x.Capital + x.Interes + x.Moratorios);
                    atrasada = vm.listaGOficina.Where(x => x.Estado.Equals("ATRASADO")).Sum(x => x.Capital + x.Interes + x.Moratorios);
                    vencida = vm.listaGOficina.Where(x => x.Estado.Equals("VENCIDO")).Sum(x => x.Capital + x.Interes + x.Moratorios);
                    lblFcorte.Text = vm.listaGOficina.First().FCorte.ToString("dd/MM/yyyy");

                }
                else
                {
                    lblFcorte.Text = vm.listaGOficina.First().FCorte.ToString("dd/MM/yyyy");
                    saldo = vm.listaGOficina.Where(x => x.geograficoestructuraNombre.Equals(seleccionado.value)).Sum(x => x.Capital + x.Interes + x.Moratorios).ToString("C");
                    vigente = vm.listaGOficina.Where(x => x.Estado.Equals("VIGENTE") && x.geograficoestructuraNombre.Equals(seleccionado.value)).Sum(x => x.Capital + x.Interes + x.Moratorios);
                    atrasada = vm.listaGOficina.Where(x => x.Estado.Equals("ATRASADO") && x.geograficoestructuraNombre.Equals(seleccionado.value)).Sum(x => x.Capital + x.Interes + x.Moratorios);
                    vencida = vm.listaGOficina.Where(x => x.Estado.Equals("VENCIDO") && x.geograficoestructuraNombre.Equals(seleccionado.value)).Sum(x => x.Capital + x.Interes + x.Moratorios);

                }

                lblSaldoCartera.Text = saldo;
                lblSaldoVigente.Text = vigente.ToString("C");
                lblSaldoAtrasado.Text = atrasada.ToString("C");
                lblSaldoVencida.Text = vencida.ToString("C");

                cargaGrafico(Convert.ToDecimal(vigente), Convert.ToDecimal(atrasada), Convert.ToDecimal(vencida));

                UserDialogs.Instance.HideLoading();
            }
            catch (Exception ex)
            {
                //DisplayAlert("MENSAJE", "ERROR. AVISE AL ADMINISTRADOR", "OK");
                UserDialogs.Instance.HideLoading();
            }


        }

        private void cargaGrafico(decimal vigente, decimal atrasada, decimal vencida)
        {
            decimal saldo = vigente + atrasada + vencida;

            List<Entry> data = new List<Entry> {
                new Entry(Convert.ToInt32(vigente)){ Label = "Vigente", ValueLabel = vigente.ToString("C"),Color = SKColor.Parse("#1e88e5")},
                new Entry(Convert.ToInt32(atrasada)){ Label = "Atrasada", ValueLabel = atrasada.ToString("C"), Color = SKColor.Parse("#ffc107")},
                new Entry(Convert.ToInt32(vencida)){ Label = "Vencida", ValueLabel = vencida.ToString("C"), Color = SKColor.Parse("#d50000")}
            };

            List<Entry> donut = new List<Entry> {
                new Entry(Convert.ToInt32(vigente)){ Label = "Vigente", ValueLabel = Math.Round(((vigente/saldo)*100),2).ToString() + "%", Color = SKColor.Parse("#1e88e5")},
                new Entry(Convert.ToInt32(atrasada)){ Label = "Atrasada", ValueLabel = Math.Round(((atrasada/saldo)*100),2).ToString() + "%", Color = SKColor.Parse("#ffc107")},
                new Entry(Convert.ToInt32(vencida)){ Label = "Vencida", ValueLabel = Math.Round(((vencida/saldo)*100),2).ToString() + "%", Color = SKColor.Parse("#d50000")}
            };

            graphCartera.Chart = new BarChart() { Entries = data };
            graphCartera2.Chart = new DonutChart() { Entries = donut };
        }
    }
}