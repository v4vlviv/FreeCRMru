using FreeCrmRuFramework.Tools;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace FreeCrmRuFramework.Pages.NonLoginPages
{
    class LoginPage : DriverInit
    {
        [FindsBy(How = How.CssSelector, Using = "div.icon-object.border-slate-300.text-slate-300")]
        IWebElement logo;

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div/div/form/div/div[2]/input")]
        IWebElement login;

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div/div/form/div/div[3]/input")]
        IWebElement password;

        [FindsBy(How = How.Id, Using = "authButton")]
        IWebElement buttonLogin;

        public LoginPage()
        {
            PageFactory.InitElements(driver, this);
        }

        public HomePage Login()
        {
            login.SendKeys("ramimalek@crm.com");
            password.SendKeys("777");
            buttonLogin.Click();
            return new HomePage();
        }



    }
}
