using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Shared.ValuesObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Email  : ValueObject
    {
        public Email(string adress)
        {
            Adress = adress;

            AddNotifications(new Contract().Requires().IsEmail(Adress, "Email.Adress", "Email inválido"));
        }

        public string Adress { get; private set; }
    }
}