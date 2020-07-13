using RentApp.ViewModels.Session;
using Xamarin.Forms;

namespace RentApp.Views.Session
{
    public partial class ValidateEmailPage : ContentPage
    {
        public ValidateEmailPage()
        {
            InitializeComponent();
            
            this.BindingContext = new ValidateEmailPageViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            entryemail.Focus();
        }
    }
}
