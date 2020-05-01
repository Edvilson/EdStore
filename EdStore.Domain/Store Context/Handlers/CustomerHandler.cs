using System;
using Edstore.domain.Store_Context.CustomerCommands.Inputs;
using Edstore.domain.Store_Context.CustomerCommands.Outputs;
using Edstore.domain.Store_Context.Services;
using EdStore.Domain.Store_Context.Repositories;
using EdStore.Domain.StoreContext.Entites;
using EdStore.Domain.StoreContext.ValueObjects;
using EdStore.Shared.Commands;
using FluentValidator;

namespace Edstore.domain.Store_Context.Handlers
{
    public class CustomerHandler :
            Notifiable,
            ICommandHandler<CreateCustomerCommand>,
            ICommandHandler<AddAddressCommand>
    {
        
        private readonly ICustomerRepository _repository;
        private readonly IEmailService _emailService;
        public CustomerHandler(ICustomerRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CreateCustomerCommand Command)
        {
            // Verificar se CPF ja existe
            if (_repository.CheckDocument(Command.Document))
            {
                AddNotification("Documente", "Este CPF já está em uso");
            }

            // Verificar se Email ja existe
            if (_repository.CheckEmail(Command.Email))
            {
                AddNotification("Email", "Este Email já está em uso");
            }
            
            //Criar VOs
            var name = new Name(Command.FirstName, Command.LastName);
            var document = new Document(Command.Document);
            var email = new Email(Command.Email);

            // Criar entidade
            var customer = new Customer(name, document, email, Command.Phone);

            // Validar entidade e VOs
            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);

            if(Invalid)
                return null;

            // Persistir o cliente
            _repository.Save(customer);

            // Enviar um E-mail de boas vindas
            _emailService.Send(email.Address, "edvilson.ads@gmail.com", "Bem Vindo", "Seja bem vindo ao EdStore");

            // Retornar resultado para a tela
            return new CreateCustomerCommandResult(Guid.NewGuid(), name.ToString(), email.Address);
        }

        public ICommandResult Handle(AddAddressCommand Command)
        {
            throw new System.NotImplementedException();
        }
    }
}
