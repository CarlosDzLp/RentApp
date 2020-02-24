﻿using System.Collections.ObjectModel;
using System.Windows.Input;
using RentApp.Models.Presentations;
using RentApp.ViewModels.Base;
using Xamarin.Forms;

namespace RentApp.ViewModels.Presentation
{
    public class CarouselPageViewModel : BindableViewBase
    {
        #region Properties
        private ObservableCollection<CarouselModel> _listCarousel;
        public ObservableCollection<CarouselModel> ListCarousel
        {
            get { return _listCarousel; }
            set { SetProperty(ref _listCarousel, value); }
        }
        #endregion

        #region Constructor
        public CarouselPageViewModel()
        {
            LoadCarousel();
            GetStarted = new Command<object>(GetStartedExecuted);
        }
        #endregion

        #region Methods
        private void LoadCarousel()
        {
            ListCarousel = new ObservableCollection<CarouselModel>();
            ListCarousel.Clear();
            ListCarousel.Add(new CarouselModel { Title = "Hola mexico", Image = "rooms", ColorHex = "#FFFFFF", IsVisible = false }); ;
            ListCarousel.Add(new CarouselModel { Title = "Hola mexico", Image = "maps", ColorHex = "#FFFFFF", IsVisible = false });
            ListCarousel.Add(new CarouselModel { Title = "Hola mexico", Image = "search", ColorHex = "#FFFFFF", IsVisible = false });
            ListCarousel.Add(new CarouselModel { Title = "Hola mexico", Image = "notifications", ColorHex = "#FFFFFF", IsVisible = false });
            ListCarousel.Add(new CarouselModel { Title ="Estara en contacto y mandar mesajes al propietario antes de agendar una visita", Image = "message", ColorHex = "#FFFFFF", IsVisible = true });
        }
        #endregion


        #region Command
        public ICommand GetStarted { get; set; }
        #endregion


        #region CommandExecuted
        private void GetStartedExecuted(object obj)
        {
            var nav = App.Navigation(new Views.Session.LoginPage());
            App.Current.MainPage = nav;
        }
        #endregion
    }
}
