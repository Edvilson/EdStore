using EdStore.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;

namespace Edstore.domain.Store_Context.CustomerCommands.Inputs
{
    public class CreateCustomerCommand : Notifiable, ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public bool Valid()
        {
            AddNotifications(new ValidationContract()
                .Requires()
                .HasMinLen(FirstName, 3, "FirstName", "O Nome deve conter pelo menos 3 caracteres")
                .HasMinLen(LastName, 3, "LastName", "O sobrenome deve contar pelo menos 3 caracteres")
                .HasMaxLen(FirstName, 50, "FirstName", "O nome deve conter no máximo 50 caracteres")
                .HasMaxLen(LastName, 50, "LasttName", "O sobrenome deve conter no máximo 50 caracteres")
                .IsEmail(Email, "Email", "O E-mail é inválido.")
                .HasLen(Document, 11, "Document", "CPF Inválido.")
            );

            return Valid();
        }
    }
}