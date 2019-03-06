using CursoXamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CursoXamarin
{
    public partial class MainPage : ContentPage
    {
        public MainPageViewModel ViewModel { get; set; }
        public MainPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel = new MainPageViewModel();
            await ViewModel.LoadCharacters();
            BindingContext = ViewModel;
        }

        private async void ViewCell_Appearing(object sender, EventArgs e)
        {
            var cell = sender as ViewCell;
            var view = cell.View;


            view.TranslationX = -100;
            view.Opacity = 0;
            await Task.WhenAny<bool>
            (
                view.TranslateTo(0, 0, 250, Easing.SinIn),
                view.FadeTo(1, 500, Easing.BounceIn)
            );
        }
    }
}
