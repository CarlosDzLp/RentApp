using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace RentApp.Controls
{
    public partial class NavigationView : ContentView
    {
        public NavigationView()
        {
            InitializeComponent();
        }

        void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            var page = App.Current.MainPage.Navigation.NavigationStack;
            var count = App.Current.MainPage.Navigation.NavigationStack.Count;
            App.Current.MainPage.Navigation.RemovePage(page[count - 1]);
        }
    }
}
