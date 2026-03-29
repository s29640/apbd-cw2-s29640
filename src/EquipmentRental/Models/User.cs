namespace EquipmentRental.Models
{
    public abstract class User
    {
        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }

        public string FullName => $"{FirstName} {LastName}";
        public abstract int MaxActiveRentals { get; }

        protected User(
            int id,
            string firstName,
            string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}