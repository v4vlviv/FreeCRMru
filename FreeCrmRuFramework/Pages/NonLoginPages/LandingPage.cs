using FreeCrmRuFramework.Tools;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace FreeCrmRuFramework.Pages.NonLoginPages
{
    class LandingPage : DriverInit
    {
        [FindsBy(How = How.CssSelector, Using = "div.autentical")]
        IWebElement btnAuthorize;

        public LandingPage()
        {
            PageFactory.InitElements(driver, this);
        }

        public LoginPage ClickAuthorizeButton()
        {
            btnAuthorize.Click();
            return new LoginPage();
        }
    }
}
