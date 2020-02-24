using RentApp.Controls;
using Xamarin.Forms;

namespace RentApp
{
    public partial class App : Application
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
            MainPage = new Views.Presentation.CarouselPage();
        }
        public static NavigationViewPage NavigationPage { get; set; }
        public static MasterDetailPage MasterDetail { get; internal set; }

        public static NavigationViewPage Navigation(Page page)
        {
            var nav = new NavigationViewPage(page);
            nav.BackgroundColor = Color.White;
            nav.BarBackgroundColor = Color.White;
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
