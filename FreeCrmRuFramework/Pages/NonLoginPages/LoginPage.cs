using FreeCrmRuFramework.Tools;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace FreeCrmRuFramework.Pages.NonLoginPages
{
    class LoginPage : DriverInit
    {
        [FindsBy(How = How.CssSelector, Using = "div.icon-object.border-slate-300.text-slate-300")]
        IWebElement logo;

        [FindsBy(How = How.CssSelector, Using = "input.form-control[type='text']")]
        IWebElement login;

        [FindsBy(How = How.CssSelector, Using = "input.form-control[type='password']")]
        IWebElement password;

        [FindsBy(How = How.Id, Using = "authButton")]
        IWebElement buttonLogin;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Создать')]")]
        IWebElement signUpLink;

        public LoginPage()
        {
            PageFactory.InitElements(driver, this);
        }

        public HomePage Login(string email, string passw)
        {
            login.SendKeys(email);
            password.SendKeys(passw);
            buttonLogin.Click();
            return new HomePage();
        }

        public bool LogoIsDisplayed()
        {
            bool flag = logo.Displayed;
            return flag;
        }

        public RegistrationPage ClickToRegistrationText()
        {
            signUpLink.Click();
            return new RegistrationPage();
        }


    }
}
