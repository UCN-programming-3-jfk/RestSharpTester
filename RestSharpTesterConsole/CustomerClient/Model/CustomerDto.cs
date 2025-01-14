namespace RestSharpTesterConsole.CustomerClient.Model
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"Customer {Id} : {Name}, email: {Email} ";
        }
    }
}