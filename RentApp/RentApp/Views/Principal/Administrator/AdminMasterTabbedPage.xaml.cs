using System;
using System.Collections.Generic;
using FormsToolkit;
using RentApp.Helpers;
using Xamarin.Forms;

namespace RentApp.Views.Principal.Administrator
{
    public partial class AdminMasterTabbedPage : TabbedPage
    {
        public AdminMasterTabbedPage()
        {
            InitializeComponent();
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
