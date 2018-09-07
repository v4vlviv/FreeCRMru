using FreeCrmRuFramework.Pages.NonLoginPages;
using FreeCrmRuFramework.Tools;
using NUnit.Framework;
using System;

namespace FreeCrmRuFramework
{
    [TestFixture]
    class LandingPageTest : TestBase
    {
        LandingPage landingPage;

        [SetUp]
        protected override void SetUp()
        {
            base.SetUp();
            landingPage = new LandingPage();
        }

        [Test]
        public void ClickAuthorizeButtonTest()
        {
            try
            {
                Assert.IsTrue(false);
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