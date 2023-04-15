namespace Task2.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Sex { get; set; } = string.Empty;
        public string Place { get; set; } = string.Empty;

        public DateTime DateRegistration {get; set; }

    }
}
