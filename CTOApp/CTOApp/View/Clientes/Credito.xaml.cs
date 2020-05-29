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
    public partial class Credito : ContentPage
    {
        VMPagos vmp = new VMPagos();

        public Credito(CreditosModel credito)
        {
            InitializeComponent();
            CargaCredito(credito);
            CargaPagos(credito.PAGARE);
        }

        private async void CargaPagos(string pagare)
        {
            UserDialogs.Instance.ShowLoading("Cargando Pagos");
            string JsonUrl = "http://convengamos.homedns.org/ctoservice/api/Pagare/GetPagoBy?id=";
            var client = new HttpClient();
            var responseString = await client.GetStringAsync(JsonUrl + pagare);
            string resp = Convert.ToString(responseString);
            var obj = JsonConvert.DeserializeObject<object>(resp);
            string data = Convert.ToString(obj);
            vmp.listaPagos = JsonConvert.DeserializeObject<List<PagosModel>>(data);
            lvPagos.ItemsSource = vmp.listaPagos;
            UserDialogs.Instance.HideLoading();
            if(vmp.listaPagos.Count()> 0) {
                lblLetrero.IsVisible = true;
            }
        }

        private void CargaCredito(CreditosModel credit)
        {
            UserDialogs.Instance.ShowLoading("Cargando Información");
            lblProducto.Text = credit.ProductoNombre;
            lblPagare.Text = credit.PAGARE;
            lblFDesembolso.Text = credit.FDESEMBOLSO;
            lblFVenc.Text = credit.FVENCIMIENTO;
            lblFCorte.Text = credit.FCORTE;
            lblMonto.Text = Decimal.Parse(credit.MONTO.ToString()).ToString("C");
            lblTInteres.Text = credit.TASAINTERES;
            lblTMoratoria.Text = credit.TASAMORATORIA;
            lblEstado.Text = credit.ESTATUS;
            lblDiasMora.Text = Convert.ToString(credit.DIASMORA);
            lblCapital.Text = Decimal.Parse(credit.CAPITAL.ToString()).ToString("C");
            lblInteres.Text = Decimal.Parse(credit.INTERES.ToString()).ToString("C"); ;
            lblMoratorios.Text = Decimal.Parse(credit.MORATORIOS.ToString()).ToString("C");
            decimal total = credit.CAPITAL + credit.INTERES + credit.MORATORIOS;
            lblSaldo.Text = Decimal.Parse(total.ToString()).ToString("C");
            lblRenegociado.Text = credit.RENEGOCIADO;
            UserDialogs.Instance.HideLoading();

        }
    }
}