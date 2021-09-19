using System;
using System.Collections.Generic;
using System.Linq;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public class Student : Entity
    {
        // private IList<string> Notifications;
        private IList<Subscription> _subscriptions;
        public Student(Name name, Document document, Email email)
        {
            Name = name;
            Document = document;
            Email = email;
            _subscriptions = new List<Subscription>();

            // if (firstName.Length == 0) throw new Exception("Nome Inv�lido");

            // if(string.IsNullOrEmpty(name.FirstName)) Notifications.Add("Nome inválido");

            AddNotifications(name, document, email);
        }

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Adress { get; private set; }
        public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscriptions.ToArray(); } }

        public void AddSubscription(Subscription subscription)
        {
            // Se j� tiver uma assinatura ativa, cancela

            // Cancela todas as outras assinaturas, e coloca esta como principal

            /*
            foreach (var sub in Subscriptions)
                sub.Inactivate();

            _subscriptions.Add(subscription);*/

            var hasSubscriptionActive = false;
            foreach (var sub in _subscriptions)
            {
                if(sub.Active) hasSubscriptionActive = true;

                AddNotifications(new Contract()
                    .Requires()
                    .IsFalse(hasSubscriptionActive, "Student.Subscription", "Você já tem uma assinatura ativa")
                    .AreEquals(0, subscription.Payments.Count, "Student.Subscrípton.Payment", "Esta assinatura não possui pagamento")
                );

                // Alternativa
                // if(hasSubscriptionActive) AddNotification("Student.Subscription", "Você já tem uma assinatura ativa");
            }
        }
    }
}