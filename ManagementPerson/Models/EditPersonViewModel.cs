namespace ManagementPerson.Models
{
    public class EditPersonViewModel
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string AddressName { get; set; }
        public string AddressNumber { get; set; }
        public string Role { get; set; }
        public string StudentNumber { get; set; }
        public double AverageMark { get; set; }
        public decimal Salary { get; set; }
    }
}
