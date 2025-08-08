using CustomerApp.Views;

namespace CustomerApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
        }
        private void RegisterRoutes()
        {
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(ClienteRegistrationPage), typeof(ClienteRegistrationPage));
        }
    }
}
