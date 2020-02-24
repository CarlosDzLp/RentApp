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
            App.NavigationPage = navigation;
            App.NavigationPage.BarBackgroundColor = Color.White;
            App.NavigationPage.BarTextColor = Color.Black;
            App.NavigationPage.IsShadow = true;
            App.NavigationPage.On<iOS>().SetHideNavigationBarSeparator(false);
        }
    }
}
