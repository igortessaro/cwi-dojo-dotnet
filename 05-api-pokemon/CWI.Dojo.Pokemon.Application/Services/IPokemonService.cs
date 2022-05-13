
namespace CWI.Dojo.Pokemon.Application.Services
{
    public interface IPokemonService
    {
        Task<IList<Models.Pokemon>> GetAll();
    }
}