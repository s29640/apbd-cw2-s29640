namespace EquipmentRental.Models
{
    public class Employee : User
    {
        public string Department { get; }

        public override int MaxActiveRentals => 5;

        public Employee(
            int id,
            string firstName,
            string lastName,
            string department)
            : base(id, firstName, lastName)
        {
            if (string.IsNullOrWhiteSpace(department))
                throw new ArgumentException("Department cannot be empty.", nameof(department));

            Department = department;
        }

    }
}