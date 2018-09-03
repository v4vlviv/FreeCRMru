using FreeCrmRuFramework.Pages;
using FreeCrmRuFramework.Pages.NonLoginPages;
using FreeCrmRuFramework.Tools;
using NUnit.Framework;

namespace FreeCrmRuFramework.Tests
{
    [TestFixture]
    class LoginPageTest:TestBase
    {
        LoginPage loginPage;
        HomePage homePage;

        [SetUp]
        protected override void SetUp()
        {
            base.SetUp();
            loginPage = new LoginPage();            
        }

        [Test]
        public void LoginTest()
        {
            string expected = "Rami Malek";
            homePage = loginPage.Login();
            string actual = homePage.VerifyUserName();
            Assert.That(expected, Is.EqualTo(actual), "Name should be Rami Malek");
        }
    }
}
