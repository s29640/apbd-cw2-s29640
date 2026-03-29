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
            : base(id, firstName, lastName)
        {
            if (string.IsNullOrWhiteSpace(studentNumber))
                throw new ArgumentException("Student number cannot be empty.", nameof(studentNumber));

            StudentNumber = studentNumber;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Student No: {StudentNumber}, Limit: {MaxActiveRentals}";
        }
    }
}