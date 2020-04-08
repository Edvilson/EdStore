using System;
using System.Collections.Generic;
using EdStore.Domain.StoreContext.ValueObjects;

namespace EdStore.Domain.StoreContext.Entites
{
   
    public class Customer
    {   
        public Customer(Name name, Document document, Email email, string phone)
        {
            Name = name;
            Document = document;
            Email = email;
            Phone = phone;
            Addresses = new List<Address>(); 
        }
        public Name Name {get; private set;}
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public string Phone { get; private set; }
        public IReadOnlyCollection<Address>  Addresses { get; private set; }

    }    
} 