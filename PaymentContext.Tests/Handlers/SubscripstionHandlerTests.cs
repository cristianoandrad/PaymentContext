using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests.Handler
{
    [TestClass]
    public class SubscriptionHandlerTests
    {
        // Red, Green, Refactor
        [TestMethod]
        public void SholdReturnErrorWhenDocumentExists() // deve retornar erro quando nome Invalido
        {
            var handler = new  SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
            var command = new CreateBoletoSubscriptionCommand();
            command.FirstName = "Bruce";
            command.LastName = "Wayne";
            command.Document = "99999999999";
            command.Email = "hello@balta.io2";
            command.BarCode = "1212315465";
            command.BoletoNumber = "45456466";
            command.PaymentNumber = "454546";
            command.PaidDate = DateTime.Now;
            command.ExpireDate = DateTime.Now.AddMonths(1);
            command.Total = 60;
            command.TotalPaid = 60;
            command.Payer = "Wayne Corp";
            command.PayerDocument = "454546464";
            command.PayerDocumentType = EDocumentType.CPF;
            command.PayerEmail = "batman@dc.com";
            command.Street = "asdasd";
            command.Number = "asdasa";
            command.Neighborhood = "asda";
            command.City = "asda";
            command.State = "asda";
            command.Country = "asd";
            command.ZipCode = "58000";

            handler.Handler(command);

            Assert.AreEqual(false, handler.Valid);

            
        }

    }
}
