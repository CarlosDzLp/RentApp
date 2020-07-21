using System;
using System.Collections.Generic;
using RentApp.ViewModels.Principal;
using Xamarin.Forms;

namespace RentApp.Views.Principal
{
    public partial class CategoryPage : ContentPage
    {
        public CategoryPage(Guid idCategory)
        {
            InitializeComponent();
            this.BindingContext = new CategoryPageViewModel(idCategory);
        }
    }
}
