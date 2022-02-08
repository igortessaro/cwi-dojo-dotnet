namespace Customer.Application
{
    public sealed class CustomerDataBase : ICustomerDataBase
    {
        private readonly IList<Entities.Customer> _customers;

        public CustomerDataBase()
        {
            this._customers = new List<Entities.Customer>();
        }

        public Entities.Customer Add(Entities.Customer customer)
        {
            customer.Uid = Guid.NewGuid().ToString();
            this._customers.Add(customer);

            return customer;
        }

        public IList<Entities.Customer> GetAll()
        {
            return this._customers;
        }

        public Entities.Customer GetById(string uid)
        {
            return this._customers.FirstOrDefault(x => x.Uid == uid);
        }

        public Entities.Customer Update(Entities.Customer customer)
        {
            var customerToDelete = this._customers.FirstOrDefault(x => x.Uid == customer.Uid);

            if (customerToDelete is not null)
            {
                this._customers.Remove(customerToDelete);
            }

            this._customers.Add(customer);

            return customer;
        }

        public void Delete(string uid)
        {
            var customerToDelete = this._customers.FirstOrDefault(x => x.Uid == uid);

            if (customerToDelete is not null)
            {
                this._customers.Remove(customerToDelete);
            }
        }
    }
}
