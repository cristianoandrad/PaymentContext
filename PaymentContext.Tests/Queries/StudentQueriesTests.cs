using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Commands
{
    [TestClass]
    public class StudentQueriesTests
    {
        // Red, Green, Refactor

       public StudentQueriesTests ()
       {
           for (int i = 0; i <= 10; i++)
           {
               _students.Add(new Student(
                   new Name("Aluno", i.ToString()),
                   new Document("1111111111" + i.ToString(), EDocumentType.CPF),
                   new Email(i.ToString() + "@balta.io")
               ));
           }  
       }

        private IList<Student> _students;
        [TestMethod]
        public void SholdReturnNullWhenDocumentNotExist() // deve retornar erro quando 
        {
            var exp = StudentsQueries.GetStudentInfo("12345678901");
            var studn = _students.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreNotEqual(null, studn);
        }

        [TestMethod]
        public void SholdReturnStudentWhenDocumentExist() // deve retornar erro quando 
        {
            var exp = StudentsQueries.GetStudentInfo("11111111111");
            var studn = _students.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreNotEqual(null, studn);
        }

    }
}
