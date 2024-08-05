namespace ManagementPerson.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public Address Address { get; set; }
    }


    public class Student : Person
    {
        public string StudentNumber { get; set; }
        public double AverageMark { get; set; }
    }

    public class Professor : Person
    {
        public decimal Salary { get; set; }
    }

}
