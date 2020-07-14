using System;
using System.Collections.Generic;
using RentApp.ViewModels.Principal;
using Xamarin.Forms;

namespace RentApp.Views.Principal
{
    public partial class MasterPage : ContentPage
    {
        public MasterPage()
        {
            InitializeComponent();
            this.BindingContext = new MasterPageViewModel();
        }
    }
}
