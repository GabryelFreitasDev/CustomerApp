using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CustomerApp.Entities;
using CustomerApp.Messages;
using CustomerApp.Models;
using CustomerApp.Services;

namespace CustomerApp.ViewModels
{
    public partial class ClienteRegistrationViewModel : BaseViewModel
    {
        [ObservableProperty]
        private ClienteModel clienteModel;

        [ObservableProperty]
        private string nameError;

        [ObservableProperty]
        private string lastNameError;

        [ObservableProperty]
        private string ageError;

        public ClienteRegistrationViewModel(long? id)
        {
            ClienteModel = new();
            Id = id;
            OnAppearing();
        }

        public override async void OnAppearing()
        {
            base.OnAppearing();

            if (Id.HasValue)
            {
                var cliente = await new ClienteService().GetByIdAsync(Id);
                ClienteModel = ClienteModel.ToModel(cliente);
            }
        }

        private bool ValidateCliente()
        {
            NameError = string.IsNullOrWhiteSpace(ClienteModel.Name) ? "Nome é obrigatório" : string.Empty;
            LastNameError = string.IsNullOrWhiteSpace(ClienteModel.LastName) ? "Sobrenome é obrigatório" : string.Empty;
            AgeError = (ClienteModel.Age <= 0) ? "Idade deve ser maior que zero" : string.Empty;

            return string.IsNullOrEmpty(NameError) &&
                   string.IsNullOrEmpty(LastNameError) &&
                   string.IsNullOrEmpty(AgeError);
        }

        [RelayCommand]
        private async Task SaveCliente()
        {
            if (ValidateCliente())
            {
                var cliente = ClienteModel.ToEntity(ClienteModel);
                await new ClienteService().SaveAsync(cliente);

                WeakReferenceMessenger.Default.Send(new ClienteSavedMessage(true));
                Application.Current!.CloseWindow(Application.Current.Windows.Last());
            }
        }

        [RelayCommand]
        private void Cancel()
        {
            Application.Current!.CloseWindow(Application.Current.Windows.Last());
        }
    }
}
