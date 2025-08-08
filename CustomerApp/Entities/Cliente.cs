using SQLite;

namespace CustomerApp.Entities
{
    [Table("Cliente")]
    public class Cliente
    {
        [PrimaryKey, AutoIncrement]
        public long Id { get; set; }

        [MaxLength(100), NotNull]
        public string Name { get; set; } = string.Empty;

        [MaxLength(100), NotNull]
        public string LastName { get; set; } = string.Empty;

        [NotNull]
        public int Age { get; set; }

        [MaxLength(200)]
        public string Address { get; set; } = string.Empty;

        [Ignore]
        public string FullName => $"{Name} {LastName}";
    }
}
