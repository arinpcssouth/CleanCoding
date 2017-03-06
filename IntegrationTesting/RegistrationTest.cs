using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.PeopleClasses;
using RepositoryAbstract;
using RepositoryConcreteInMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTesting
{

    [TestClass]
    public class RegistrationTest
    {
        IRegistrationRepository<Staff> repo;
        BusinessAbstract.IRegistration registration;

        public RegistrationTest()
        {
            repo= new RegistrationRepository<Staff>();
            registration = new BusinessConcrete.Registration(repo);
        }

        [TestMethod]
        public void StaffRegistration_AddATeacher_ShouldReturnTrue()
        {
            //Arrange
            Teacher teacher = new Teacher
            {
                AcceptsEmails = true,
                FirstName = "Ashley",
                FormalName = "Mrs. Williams",
                GovernmentEmployeeId = "123456",
                Id = Guid.NewGuid(),
                LastName = "Williams",
                TeachesIn = new Classroom { Grade = 1, Name = "Class A", RoomNumber = 102 }
            };
 

            //Act
            var res = registration.RegisterTeacher(teacher);

            //Assert
            Assert.IsTrue(res);
        }


    }
}
