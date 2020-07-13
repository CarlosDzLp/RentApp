using System;
using System.Collections.Generic;
using RentApp.ViewModels.Session;
using Xamarin.Forms;

namespace RentApp.Views.Session
{
    public partial class RegisterUserPage : ContentPage
    {
        public RegisterUserPage(string email)
        {
            InitializeComponent();
            this.BindingContext = new RegisterUserPageViewModel(email);
        }
    }
}
