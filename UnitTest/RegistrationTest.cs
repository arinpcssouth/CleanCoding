using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.PeopleClasses;
using Moq;
using RepositoryAbstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestClass]
    public class RegistrationTest
    {
        Mock<IRegistrationRepository<Staff>> mock;
        BusinessAbstract.IRegistration registration;

        public RegistrationTest()
        {
            mock = new Mock<IRegistrationRepository<Staff>>();

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
            mock.Setup(repo => repo.Register(teacher)).Returns(true);
            registration = new BusinessConcrete.Registration(mock.Object);


            //Act
            var res= registration.RegisterTeacher(teacher);

            //Assert
            Assert.IsTrue(res);
        }


    }
}
