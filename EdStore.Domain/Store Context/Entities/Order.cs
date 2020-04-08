using System;
using System.Collections.Generic;
using Edstore.domain.Store_Context.Entities.Enums;

namespace EdStore.Domain.StoreContext.Entites
{
    public class Order
    {
        public Order(Customer customer)
        {
            Customer = customer;
            Number = Guid.NewGuid().ToString().Replace("-","").Substring(0,8).ToUpper();
            CreateDate = DateTime.Now;
            Status = EOrderStatus.Created;
            Items = new List<OrderItem>();
            Deliverys = new List<Delivery>();

        }

        public Customer Customer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreateDate { get; private set; }
        public EOrderStatus Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Items { get; private set; }
        public IReadOnlyCollection<Delivery> Deliverys { get; private set; }

        public void AddItem(OrderItem item)
        {

        }

        public void Place() //Método para fechar o pedido
        {

        }
    }
}