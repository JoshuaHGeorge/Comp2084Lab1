using LowballersV2.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LowballersTest
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void IndexViewLoads()
        {
            //arrange
            var homeController = new HomeController();

            // act
            var result = (ViewResult)homeController.Index();

            // assert
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void PrivacyViewLoads()
        {
            //arrange
            var homeController = new HomeController();

            // act
            var result = (ViewResult)homeController.Privacy();

            // assert
            Assert.AreEqual("Privacy", result.ViewName);
        }


    }
}
