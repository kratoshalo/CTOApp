using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CTOApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            if (CrossConnectivity.Current.IsConnected) {
                btnIngresar.IsVisible = true;
            } else {
                lblMensaje.IsVisible = true;
            }
        }

        private void btnIngresar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new AppMasterDetailPage());
        }
    }
}
