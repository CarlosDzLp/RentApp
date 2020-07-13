using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

[assembly: ExportFont("FontAwesome5Brands.otf", Alias = "Brands")]
[assembly: ExportFont("FontAwesome5Regular.otf", Alias = "Regular")]
[assembly: ExportFont("FontAwesome5Solid.otf", Alias = "Solid")]
namespace RentApp
{
    public partial class App : Xamarin.Forms.Application
    {
        public static int ScreenHeight { get; set; }
        public static int ScreenWidth { get; set; }

        public App()
        {
            InitializeComponent();
            Device.SetFlags(new[] {
                "CarouselView_Experimental",
                "IndicatorView_Experimental"
            });
            MainPage = Navigation(new Views.Session.LoginPage());
        }

        public static Xamarin.Forms.NavigationPage NavigationPage { get; set; }
        public static Xamarin.Forms.NavigationPage Navigation(Xamarin.Forms.Page page)
        {
            var nav = new Xamarin.Forms.NavigationPage(page);
            nav.On<iOS>().SetHideNavigationBarSeparator(true);
            nav.BackgroundColor = Color.White;
            nav.BarBackgroundColor = Color.FromHex("#F4364C");
            nav.BarTextColor = Color.White;
            NavigationPage = nav;
            return nav;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
