using Customer.Application.Commands;
using Customer.Application.Queries;

namespace Customer.Application.Entities
{
    public sealed class Customer
    {
        public string Uid { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }

        public static implicit operator Customer(CreateCustomer customer)
        {
            if (customer is null)
            {
                return null;
            }

            var result = new Customer();
            result.Name = customer.name;
            result.LastName = customer.lastName;
            result.Email = customer.email;
            result.UserName = customer.userName;
            return result;
        }

        public static implicit operator Customer(UpdateCustomer customer)
        {
            if (customer is null)
            {
                return null;
            }

            var result = new Customer();
            result.Uid = customer.uid;
            result.Name = customer.name;
            result.LastName = customer.lastName;
            result.Email = customer.email;
            result.UserName = customer.userName;
            return result;
        }

        public static implicit operator Customer(CustomerFullInformation customer)
        {
            if (customer is null)
            {
                return null;
            }

            var result = new Entities.Customer();
            result.Uid = customer.Uid;
            result.Name = customer.Name;
            result.LastName = customer.LastName;
            result.Email = customer.Email;
            result.UserName = customer.UserName;
            return result;
        }
    }
}
