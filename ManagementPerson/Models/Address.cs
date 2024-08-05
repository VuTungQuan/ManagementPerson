namespace ManagementPerson.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }


}
