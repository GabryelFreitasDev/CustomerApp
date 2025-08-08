using CommunityToolkit.Mvvm.ComponentModel;
using CustomerApp.Entities;
using System.ComponentModel;


namespace CustomerApp.Models
{
    public partial class ClienteModel : ObservableValidator
    {
        [ObservableProperty]
        public long id;

        [ObservableProperty]
        public string name;

        [ObservableProperty]
        public string lastName;

        [ObservableProperty]
        public int age;

        [ObservableProperty]
        public string address;

        public string FullName => $"{Name} {LastName}";

        public ClienteModel() { }

        public static ClienteModel ToModel(Cliente entity)
        => new ClienteModel
        {
            Id = entity.Id,
            Name = entity.Name,
            LastName = entity.LastName,
            Age = entity.Age,
            Address = entity.Address
        };

        public static Cliente ToEntity(ClienteModel model)
            => new Cliente
            {
                Id = model.Id,
                Name = model.Name,
                LastName = model.LastName,
                Age = model.Age,
                Address = model.Address
            };
    }
}
