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
            Department = department;
        }

    }
}