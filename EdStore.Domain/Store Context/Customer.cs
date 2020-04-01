using System;

namespace EdStore.Domain.StoreContext
{
    public class Customer
    {
        public string Name { get; private set; }
        public DateTime BirthDate { get; private set; }
        public decimal Salary { get; private set; }
    }
}