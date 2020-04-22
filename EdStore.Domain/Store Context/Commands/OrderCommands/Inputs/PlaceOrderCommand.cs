using System;
using System.Collections.Generic;
using EdStore.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;

namespace Edstore.domain.Store_Context.OrderCommands.Inputs
{
    public class PlaceOrderCommand : Notifiable, ICommand
    {
        public Guid Customer {get; set;}
        public IList<OrderItemCommand> OrderItems {get; set;}

        public PlaceOrderCommand()
        {
            OrderItems = new List<OrderItemCommand>();
        }
        public bool Valid()
        {
            AddNotifications(new ValidationContract()
                .Requires()
                .HasLen(Customer.ToString(), 36, "Customer", "Identificador do cliente invalico.")
                .IsGreaterThan(OrderItems.Count, 0, "Items", "Nenhum item do pedido foi encontrado.")
            );

            return Valid();
        }

       
    }

    public class OrderItemCommand{
        public Guid Product {get; set;}
        public decimal Quantity {get; set;}
    }
}