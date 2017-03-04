using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using RepositoryAbstract;
using Model.Authentication;

namespace UnitTest
{
    [TestClass]
    public class AuthenticationUnitTest
    {
        Mock<IAuthenticationRepository> mock;
        BusinessAbstract.ISession session;


        public AuthenticationUnitTest()
        {
            mock = new Mock<IAuthenticationRepository>();
        }


        [TestMethod]
        public void Authentication_UserLogsInWithCorrectCredentials_ServerReturnsValidGuid()
        {

            //Arrange
            var credentials = new UserCredentials { Username = "arin", Password = "anything" };
            mock.Setup(repo => repo.Login(credentials)).Returns(new Model.Authentication.ActiveSession { DateTimeInitiated = DateTime.UtcNow, Token = Guid.NewGuid() });
            session = new BusinessConcrete.Session(mock.Object);

            //Act
            var underTest= session.Create(credentials);

            //Assert
            Assert.IsTrue(underTest != null);
            Assert.AreNotEqual(underTest.Token, new Guid());
        }

        [TestMethod]
        public void Authentication_UserLogsInWithWrongCredentials_ServerReturnsUnAuthorizedException()
        {

            //Arrange
            var credentials = new UserCredentials { Username = "arin", Password = "anything" };

            mock.Setup(repo => repo.Login(credentials)).Returns(new Model.Authentication.ActiveSession { DateTimeInitiated = DateTime.UtcNow, Token = new Guid() });
            session = new BusinessConcrete.Session(mock.Object);

            //Act
            var underTest = session.Create(credentials);

            //Assert
            Assert.IsTrue(underTest != null);
            Assert.AreEqual(underTest.Token, new Guid());
        }


        [TestMethod]
        public void Authentication_GetSessionByCorrectToken_ReturnsSession()
        {

            //Arrange
            var token = Guid.NewGuid();
            mock.Setup(repo => repo.GetSessionByToken(token)).Returns(new Model.Authentication.ActiveSession { DateTimeInitiated = DateTime.UtcNow, Token = Guid.NewGuid() });
            session = new BusinessConcrete.Session(mock.Object);

            //Act
            var underTest = session.GetSessionByToken(token.ToString());

            //Assert
            Assert.IsTrue(underTest != null);
            Assert.AreNotEqual(underTest.Token, new Guid());
        }

        [TestMethod]
        public void Authentication_GetSessionByWrongToken_ReturnsEmptySession()
        {

            //Arrange
            var token = Guid.NewGuid();
            mock.Setup(repo => repo.GetSessionByToken(token)).Returns(new Model.Authentication.ActiveSession { DateTimeInitiated = DateTime.UtcNow, Token = new Guid()});
            session = new BusinessConcrete.Session(mock.Object);

            //Act
            var underTest = session.GetSessionByToken(token.ToString());

            //Assert
            Assert.IsTrue(underTest != null);
            Assert.AreEqual(underTest.Token, new Guid());
        }



    }
}
