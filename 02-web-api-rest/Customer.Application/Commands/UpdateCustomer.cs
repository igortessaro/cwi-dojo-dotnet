namespace Customer.Application.Commands
{
    public record UpdateCustomer(string? uid, string name, string lastName, string email, string userName);
}
