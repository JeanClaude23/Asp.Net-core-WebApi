using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Xml;
using WebApi.Controllers;

namespace WebApiTest
{
    [TestClass]
    public class UsersControllerTests
    {
        UsersController controller = new UsersController();
        [TestMethod]
        public void Should_Return_The_Right_Email()
        {
            
            var email = controller.GetEmail("Roger");
            Assert.AreEqual("rogermuhire", email);
        }

        [TestMethod]
        public void Should_Update_The_Token()
        {
            var actionResult = controller.UpdateToken("Roger");
            Assert.AreEqual(actionResult.ToString(), controller.Ok().ToString());
        }

    }
}