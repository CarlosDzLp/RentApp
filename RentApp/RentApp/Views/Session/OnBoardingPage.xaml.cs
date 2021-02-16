using System;
using System.Collections.Generic;
using RentApp.ViewModels.Session;
using Xamarin.Forms;

namespace RentApp.Views.Session
{
    public partial class OnBoardingPage : ContentPage
    {
        public OnBoardingPage()
        {
            InitializeComponent();
            this.BindingContext = new OnBoardingPageViewModel();
        }
    }
}
