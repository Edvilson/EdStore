using FluentValidator;
using FluentValidator.Validation;

namespace EdStore.Domain.StoreContext.ValueObjects
{
    public class Name : Notifiable
    {
        public Name(string firstName, string lastName)
        {
            FirstName =  firstName;
            LastName = lastName;

            AddNotifications(new ValidationContract()
                .Requires()
                .HasMinLen(firstName, 3, "FirstName", "O Nome deve conter pelo menos 3 caracteres")
                .HasMinLen(lastName, 3, "LastName", "O sobrenome deve contar pelo menos 3 caracteres")
                .HasMaxLen(firstName, 50, "FirstName", "O nome deve conter no máximo 50 caracteres")
                .HasMaxLen(lastName, 50, "LasttName", "O sobrenome deve conter no máximo 50 caracteres")
            );

        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}