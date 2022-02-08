namespace Customer.Application.Queries
{
    public sealed class CustomerFullInformation
    {
        public string Uid { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }

        public static implicit operator CustomerFullInformation(Entities.Customer customer)
        {
            if (customer is null)
            {
                return null;
            }

            var result = new CustomerFullInformation();
            result.Uid = customer.Uid;
            result.Name = customer.Name;
            result.LastName = customer.LastName;
            result.Email = customer.Email;
            result.UserName = customer.UserName;
            return result;
        }
    }
}
