using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CustomerApp.Messages;
using CustomerApp.Models;
using CustomerApp.Services;
using CustomerApp.Views;
using System.Collections.ObjectModel;

namespace CustomerApp.ViewModels
{
    public partial class MainViewModel : BaseViewModel
    {
        [ObservableProperty]
        private ObservableCollection<ClienteModel> listCliente;

        public MainViewModel()
        {
           ListCliente = new();

            WeakReferenceMessenger.Default.Register<ClienteSavedMessage>(this, async (r, m) => { await LoadListCliente(); });
        }

        public override async void OnAppearing()
        {
            base.OnAppearing();

            await LoadListCliente();
        }

        [RelayCommand]
        private async Task LoadListCliente()
        {
            var listCliente = await new ClienteService().GetAllAsync();
            ListCliente = listCliente.Select(ClienteModel.ToModel).ToObservableCollection();
        }

        [RelayCommand]
        public async Task AddCliente()
        {
            var window = new Window(new ClienteRegistrationPage());
            Application.Current!.OpenWindow(window);
        }

        [RelayCommand]
        public async Task EditCliente(ClienteModel cliente)
        {
            var window = new Window(new ClienteRegistrationPage(cliente.Id));
            Application.Current!.OpenWindow(window);
        }

        [RelayCommand]
        public async Task RemoveCliente(ClienteModel cliente)
        {
            bool confirm = await App.Current.MainPage.DisplayAlert(
                                    "Confirmação",
                                    $"Deseja realmente excluir o cliente \"{cliente.FullName}\"?",
                                    "Sim",
                                    "Cancelar");

            if (confirm)
            {
                await new ClienteService().DeleteByIdAsync(cliente.Id);
                await LoadListCliente();
            }
        }
    }
}
