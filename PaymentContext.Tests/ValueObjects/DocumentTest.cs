using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        // Red, Green, Refactor
        [TestMethod]
        public void SholdReturnErrorWhenCNPJIsInvalid() // deve retornar erro quando CNPJ Invalido
        {
            var doc = new Document("123", EDocumentType.CNPJ);
            Assert.IsTrue(doc.Invalid);
            
        }

        [TestMethod]
        public void SholdReturnSuccessrWhenCNPJIsValid() // deve retornar sucesso quando CNPJ Valido
        {
           var doc = new Document("12345678901234", EDocumentType.CNPJ);
            Assert.IsTrue(doc.Valid);
            
        }

        [TestMethod]
        public void SholdReturnErrorWhenCPFIsInvalid() // deve retornar erro quando CNPJ Invalido
        {
           var doc = new Document("123", EDocumentType.CPF);
            Assert.IsTrue(doc.Invalid);
            
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("12345678901")]
        [DataRow("12345678902")]
        [DataRow("12345678903")]
        public void SholdReturnSuccessrWhenCPFIsValid(string cpf) // deve retornar sucesso quando CNPJ Valido
        {
           var doc = new Document(cpf, EDocumentType.CPF);
            Assert.IsTrue(doc.Valid);
            
        }
    }
}
