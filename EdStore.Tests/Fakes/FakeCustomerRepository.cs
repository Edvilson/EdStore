using EdStore.Domain.Store_Context.Repositories;
using EdStore.Domain.StoreContext.Entites;

namespace Edstore.Tests
{
    public class FakeCustomerRepository : ICustomerRepository
    {
        public bool CheckDocument(string document)
        {
            return false;
        }

        public bool CheckEmail(string email)
        {
            return false;
        }

        public void Save(Customer customer)
        {
            
        }
    }
}