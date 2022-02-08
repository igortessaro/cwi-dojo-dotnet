
namespace Customer.Application
{
    public interface ICustomerDataBase
    {
        Entities.Customer Add(Entities.Customer customer);
        void Delete(string uid);
        IList<Entities.Customer> GetAll();
        Entities.Customer GetById(string uid);
        Entities.Customer Update(Entities.Customer customer);
    }
}