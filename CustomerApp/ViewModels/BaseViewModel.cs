using CommunityToolkit.Mvvm.ComponentModel;

namespace CustomerApp.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        public long? Id { get; set; }
        public virtual void OnAppearing() { }
        public BaseViewModel() { }
    }
}
