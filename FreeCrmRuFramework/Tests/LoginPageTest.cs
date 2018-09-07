using FreeCrmRuFramework.Pages;
using FreeCrmRuFramework.Pages.NonLoginPages;
using FreeCrmRuFramework.Tools;
using NUnit.Framework;
using System;

namespace FreeCrmRuFramework.Tests
{
    [TestFixture]
    class LoginPageTest : TestBase
    {
        LoginPage loginPage;
        HomePage homePage;
        RegistrationPage registrationPage;

        [SetUp]
        protected override void SetUp()
        {
            base.SetUp();
            loginPage = new LoginPage();
        }

        [Test]
        public void LoginTest()
        {
            try
            {
                string expected = "Rami Malek";
                homePage = loginPage.Login();
                string actual = homePage.VerifyUserName();
                Assert.That(expected, Is.EqualTo(actual), "Name should be Rami Malek");
            }
            catch (Exception ex)
            {
                test.Fail(ex.StackTrace);
                test.Fail(ex.Message);
                isTestSuccess = false;
            }
        }

        [Test]
        public void LogoIsDisplayedTest()
        {
            try
            {
                bool actual = loginPage.LogoIsDisplayed();
                Assert.That(actual, Is.EqualTo(true), "Logo should be displayed ");

            }
            catch (Exception ex)
            {
                test.Fail(ex.StackTrace);
                test.Fail(ex.Message);
                isTestSuccess = false;
            }
        }

        [Test]
        public void ClickToRegistrationTextTest()
        {
            //
            try
            {
                registrationPage = loginPage.ClickToRegistrationText();
                registrationPage.LogoIsDisplayed();
            }
            catch (Exception ex)
            {
                test.Fail(ex.StackTrace);
                test.Fail(ex.Message);
                isTestSuccess = false;
            }
        }
    }
}
