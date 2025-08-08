using CustomerApp.ViewModels;

namespace CustomerApp.Views;

public partial class ClienteRegistrationPage : BasePages
{
	public ClienteRegistrationPage(long? id = null)
	{
		InitializeComponent();
        BindingContext = new ClienteRegistrationViewModel(id);
    }
}