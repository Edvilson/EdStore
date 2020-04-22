using EdStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EdStore.Tests
{
    [TestClass]
    public class DocumentTests
    {
        [TestMethod]
        public void NotificationIsNotValid()
        {
            var document = new Document("12345678910");
            Assert.AreEqual(false, document.Invalid);        
//            Assert.AreEqual(1, document.Notifications.Count); 
        }

        [TestMethod]
        public void NotificationIsValid()
        {
            var document = new Document("01381485030");
            Assert.AreEqual(true, document.Valid);        
//            Assert.AreEqual(1, document.Notifications.Count);         
        }
    }
}
