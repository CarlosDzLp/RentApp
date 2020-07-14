using FormsToolkit;
using RentApp.Helpers;
using RentApp.ViewModels.Session;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace RentApp.Views.Session
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginPageViewModel();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(false);
            Xamarin.Forms.NavigationPage.SetHasNavigationBar(this, true);
            if (Device.RuntimePlatform == Device.iOS)
                entryemail.Keyboard = Keyboard.Create(KeyboardFlags.CapitalizeNone);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingService.Current.SendMessage<MessageKeys>("StatusBar", new MessageKeys { StatusBarTransparent = false, ColorHex = "#F4364C" });
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingService.Current.Unsubscribe("StatusBar");
        }
    }
}
