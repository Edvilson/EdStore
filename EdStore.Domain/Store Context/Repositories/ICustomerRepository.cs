using EdStore.Domain.StoreContext.Entites;

namespace EdStore.Domain.Store_Context.Repositories
{
    public interface ICustomerRepository
    {
        bool CheckDocument(string document);
        bool CheckEmail(string email);
        void Save(Customer customer);
    } 
}