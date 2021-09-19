using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Shared.ValuesObjects;

namespace PaymentContext.Domain.ValueObjects{
    public class Name  : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            //if (string.IsNullOrEmpty(FirstName)) AddNotification("Name.FirstName", "Nome inválido");
            //if (string.IsNullOrEmpty(LastName)) AddNotification("Name.LastName", "Sobrenome inválido");

            // if(string.IsNullOrEmpty(FirstName)) AddNotification("Name.FirstName", "Nome Inválido");
            // if(string.IsNullOrEmpty(LastName)) AddNotification("Name.LastName", "Sobrenome Inválido");

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(FirstName, 3, "Name.FirstName", "Nome deve conter pelo menos 3 caracteres")
                .HasMinLen(LastName, 3, "Name.LastName", "Sobrenome deve conter pelo menos 3 caracteres")
                .HasMaxLen(FirstName, 40, "Name.FirstName", "Nome deve conter até 40 caracteres")
                .HasMaxLen(LastName, 40, "Name.LastName", "Sobrenome deve conter até 40 caracteres")
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