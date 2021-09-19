using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
    public class CreditCardPayment : Payment
    {
        public CreditCardPayment(
            string cardHolderName, 
            string cardName, 
            string lastTransactionName, 
            DateTime paidDate,
            DateTime expireDate,
            decimal total,
            decimal totalPaid,
            string payer,
            Document document,
            Address adress,
            Email email) : base(
                paidDate,
                expireDate,
                total,
                totalPaid,
                payer,
                document,
                adress,
                email)
        {
            CardHolderName = cardHolderName;
            CardName = cardName;
            LastTransactionName = lastTransactionName;
        }

        public string CardHolderName { get; private set; }
        public string CardName { get; private set; }
        public string LastTransactionName { get; private set; }
    }
}
