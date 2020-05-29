using CTOApp.View.Anuncios;
using CTOApp.View.Cartera;
using CTOApp.View.Clientes;
using CTOApp.View.Solicitud;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CTOApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppMasterDetailPageMaster : ContentPage
    {
        public ListView ListView;

        public AppMasterDetailPageMaster()
        {
            InitializeComponent();

            BindingContext = new AppMasterDetailPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class AppMasterDetailPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<AppMasterDetailPageMasterMenuItem> MenuItems { get; set; }

            public AppMasterDetailPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<AppMasterDetailPageMasterMenuItem>(new[]
                {
                    new AppMasterDetailPageMasterMenuItem { Id = 0, Title = "Inicio",TargetType=typeof(AppMasterDetailPageDetail)},
                    new AppMasterDetailPageMasterMenuItem { Id = 1, Title = "Clientes",TargetType=typeof(BuscarCliente)},
                    new AppMasterDetailPageMasterMenuItem { Id = 2, Title = "Cartera",TargetType=typeof(Cartera)},
                    new AppMasterDetailPageMasterMenuItem { Id = 3, Title = "Solicitud",TargetType=typeof(Solicitud) },
                    new AppMasterDetailPageMasterMenuItem { Id = 4, Title = "Anuncios",TargetType=typeof(Anuncios) },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}