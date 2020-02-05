using System;
using System.ComponentModel;
using Bertuzzi.Xamarin.Forms.Mocks.ViewModels;
using Xamarin.Forms;

namespace Bertuzzi.Xamarin.Forms.Mocks.Views
{
    public class BaseView : ContentPage
    {
        private BaseViewModel ViewModel => BindingContext as BaseViewModel;

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (ViewModel == null) return;
            Title = ViewModel.Titulo;
            ViewModel.PropertyChanged += TitlePropertyChanged;
            await ViewModel.LoadAsync();
        }

        private void TitlePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != nameof(ViewModel.Titulo)) return;

            Title = ViewModel.Titulo;
        }
    }
}
