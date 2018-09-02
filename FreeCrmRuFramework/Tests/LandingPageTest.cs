using FreeCrmRuFramework.Pages.NonLoginPages;
using FreeCrmRuFramework.Tools;
using NUnit.Framework;

namespace FreeCrmRuFramework
{
    [TestFixture]
    class LandingPageTest : TestBase
    {
        LandingPage landingPage = new LandingPage();


        [Test]
        public void ClickAuthorizeButtonTest()
        {
            landingPage.ClickAuthorizeButton();
        }

    }
}