using System;
using System.Collections.Generic;
using RentApp.Models.Users;
using RentApp.ViewModels.Session;
using Xamarin.Forms;

namespace RentApp.Views.Session
{
    public partial class SelectMunicipalityPage : ContentPage
    {
        public SelectMunicipalityPage(UserModel user)
        {
            InitializeComponent();
            this.BindingContext = new SelectMunicipalityPageViewModel(user);
        }
    }
}
