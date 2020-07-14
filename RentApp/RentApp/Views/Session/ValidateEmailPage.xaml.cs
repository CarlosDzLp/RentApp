using RentApp.ViewModels.Session;
using Xamarin.Forms;

namespace RentApp.Views.Session
{
    public partial class ValidateEmailPage : ContentPage
    {
        private ValidateEmailPageViewModel validateEmailPage = null;
        public ValidateEmailPage()
        {
            InitializeComponent();
            
            this.BindingContext = validateEmailPage = new ValidateEmailPageViewModel();
            if(Device.RuntimePlatform==Device.iOS)
                entryemail.Keyboard = Keyboard.Create(KeyboardFlags.CapitalizeNone);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            entryemail.Focus();
        }

        void ValidateEmailCommand(System.Object sender, System.EventArgs e)
        {
            validateEmailPage.ValidateEmailCommandExecuted();
        }
    }
}
