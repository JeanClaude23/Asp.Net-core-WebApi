using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Controllers.Tests
{
    [TestClass()]
    public class TestUserControllerTests
    {
        static MS_LearningsContext context = new MS_LearningsContext();
        TestUserController controller = new TestUserController(context);

        [TestMethod()]
        public async Task GetbyIdTestAsync()
        {
            var actionResult = await controller.GetUsers();
            Assert.AreEqual(actionResult.ToString(), controller.Ok().ToString());
        }
    }
}