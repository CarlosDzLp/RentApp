using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
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
            //App.NavigationViewPage = navigationPage;
            App.NavigationViewPage.BarBackgroundColor = Color.White;
            App.NavigationViewPage.BarTextColor = Color.Black;
            App.NavigationViewPage.IsShadow = true;
            App.NavigationViewPage.On<iOS>().SetHideNavigationBarSeparator(false);
        }
    }
}
