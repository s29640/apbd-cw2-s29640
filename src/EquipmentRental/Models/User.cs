namespace EquipmentRental.Models
{
    public abstract class User
    {
        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public UserType UserType { get; }

        public string FullName => $"{FirstName} {LastName}";
        public abstract int MaxActiveRentals { get; }

        protected User(
            int id,
            string firstName,
            string lastName,
            UserType userType)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            UserType = userType;
        }
    }
}