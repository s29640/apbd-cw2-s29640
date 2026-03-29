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
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than 0.");

            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("First name cannot be empty.", nameof(firstName));

            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Last name cannot be empty.", nameof(lastName));

            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}