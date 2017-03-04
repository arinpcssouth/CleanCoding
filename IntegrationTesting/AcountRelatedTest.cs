using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepositoryAbstract;
using RepositoryConcrete;
using BusinessConcrete;
using BusinessAbstract;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Hosting;
using ServiceLayer.Controllers;
using Model.Authentication;

namespace IntegrationTesting
{
    [TestClass]
    public class AcountRelatedTest
    {
        HttpRequestMessage request;
        AccountController accountController;

        public AcountRelatedTest()
        {
            var config = new HttpConfiguration();
            request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/api/account");
            var route = config.Routes.MapHttpRoute("Default", "api/{controller}/{id}");
            request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;

            IAuthenticationRepository repo = new AuthenticationRepository();
            accountController = new AccountController(repo, new Session(repo));
            accountController.Request = request;
        }


        [TestMethod]
        public void Authentication_UserLogsInWithCorrectCredentials_ReturnsIsSuccess()
        {
            //Arrange
            var username = "arin";
            var password = "test";

            //Act
            var res = accountController.Login(new Model.Authentication.UserCredentials { Username = username, Password = password });

            //Assert
            Assert.IsTrue(res.IsSuccessStatusCode);


        }

        [TestMethod]
        public void Authentication_UserLogsInWithWrongCredentials_ReturnsUnauthorized()
        {
            //Arrange
            var username = "arin";
            var password = "pass22";

            //Act
            var res = accountController.Login(new UserCredentials { Username = username, Password = password });

            //Assert
            Assert.IsTrue(res.StatusCode == System.Net.HttpStatusCode.Unauthorized);


        }

    }
}
