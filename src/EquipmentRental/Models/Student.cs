namespace EquipmentRental.Models
{
    public class Student : User
    {
        public string StudentNumber { get; }

        public override int MaxActiveRentals => 2;

        public Student(
            int id,
            string firstName,
            string lastName,
            string studentNumber)
            : base(id, firstName, lastName, UserType.Student)
        {
            StudentNumber = studentNumber;
        }
    }
}