using CustomerApp.ViewModels;

namespace CustomerApp.Views
{
    public class BasePages : ContentPage
    {
        protected override async void OnAppearing()
        {
            (BindingContext as BaseViewModel)?.OnAppearing();
            base.OnAppearing();
        }
    }
}
