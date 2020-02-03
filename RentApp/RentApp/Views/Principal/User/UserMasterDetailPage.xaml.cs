using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RentApp.Views.Principal.User
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserMasterDetailPage : MasterDetailPage
    {
        public UserMasterDetailPage()
        {
            InitializeComponent();
            App.MasterDetail = this;
            App.NavigationViewPage.BarBackgroundColor = Color.White;
            App.NavigationViewPage.BarTextColor = Color.Black;
        }
    }
}
