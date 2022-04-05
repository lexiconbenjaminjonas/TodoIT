namespace TodoIT.Model
{
    public class Person
    {
        private readonly int personId;
        private string firstName { get; set; }
        private string lastName { get; set; }
        public string FirstName { get => firstName; }
        public string LastName { get => lastName; }
        public int PersonId { get => personId; }

        private readonly string defaultFirstName = "Steve";
        private readonly string defaultLastName = "Jobs";

        public Person(int personId, string firstName, string lastName)
        {
            this.personId = personId;
        
            this.firstName = firstName;
            this.lastName = lastName;

            if (string.IsNullOrEmpty(firstName))
            {
                this.firstName = this.defaultFirstName;
            }

            if (string.IsNullOrEmpty(lastName))
            {
                this.lastName = this.defaultLastName;
            }
        }
    }
}