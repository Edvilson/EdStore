using Edstore.domain.Store_Context.Services;
using EdStore.Domain.StoreContext.Entites;

namespace Edstore.Tests
{
    public class FakeEmailService : IEmailService
    {
        public void Send(string to, string from, string subject, string body)
        {
            
        }
    }
}