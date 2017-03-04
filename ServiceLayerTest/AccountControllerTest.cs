using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RepositoryAbstract;
using ServiceLayer.Controllers;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Hosting;
using Model.Authentication;

namespace ServiceLayerTest
{
    [TestClass]
    public class AccountControllerTest
    {
        Mock<IAuthenticationRepository> mock;
        BusinessAbstract.ISession session;
        HttpRequestMessage request; 

        public AccountControllerTest()
        {
            mock = new Mock<IAuthenticationRepository>();
            var config = new HttpConfiguration();
            request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/api/account");
            var route = config.Routes.MapHttpRoute("Default", "api/{controller}/{id}");
            request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
        }

        [TestMethod]
        public void Account_UserLogsInWithCorrectCredentials_ReturnsIsSuccess()
        {
            //Arrange
            var credentials = new UserCredentials { Username = "arin", Password = "anything" };
            mock.Setup(repo => repo.Login(credentials)).Returns(new Model.Authentication.ActiveSession { DateTimeInitiated = DateTime.UtcNow, Token = Guid.NewGuid() });
            session = new BusinessConcrete.Session(mock.Object);
            AccountController accountController = new AccountController(mock.Object, session);
            accountController.Request = request;
                

            //Act
            var res= accountController.Login(credentials);

            //Assert
            Assert.IsTrue(res.IsSuccessStatusCode);
        }

        [TestMethod]
        public void Account_UserLogsInWithWrongCredentials_ReturnsUnauthorizedError()
        {
            //Arrange
            var credentials = new UserCredentials { Username = "arin", Password = "anything" };

            mock.Setup(repo => repo.Login(credentials)).Returns(new Model.Authentication.ActiveSession { DateTimeInitiated = DateTime.UtcNow, Token = new Guid() });
            session = new BusinessConcrete.Session(mock.Object);
            AccountController accountController = new AccountController(mock.Object, session);
            accountController.Request = request;

            //Act
            var res = accountController.Login(credentials);

            //Assert
            Assert.IsTrue(res.StatusCode == System.Net.HttpStatusCode.Unauthorized);
        }

    }
}
