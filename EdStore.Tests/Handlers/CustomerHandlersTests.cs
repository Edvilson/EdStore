using Edstore.domain.Store_Context.CustomerCommands.Inputs;
using Edstore.domain.Store_Context.Handlers;
using Edstore.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EdStore.Tests
{
    [TestClass]
    public class CustomerHandlerTests
    {
        [TestMethod]
        public void ShouldRegisterCustomerWhenCommandIsValid()
        {
           var command = new CreateCustomerCommand();
           command.FirstName = "Edvilson";
           command.LastName = "Almeida";
           command.Document = "12345678910";
           command.Email = "edvilson.ads@gmail.com";
           command.Phone = "519999999997";
           var handler = new CustomerHandler(new FakeCustomerRepository(), new FakeEmailService());
           var result = handler.Handle(command);

           Assert.AreEqual(null, result);
           Assert.AreEqual(0, handler.Invalid);

        }

    }
}
