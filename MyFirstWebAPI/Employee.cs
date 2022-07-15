namespace MyFirstWebAPI
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public int age { get; set; }

        internal static void Add(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
