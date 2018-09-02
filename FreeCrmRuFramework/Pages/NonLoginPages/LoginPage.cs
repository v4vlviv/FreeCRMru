
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace FreeCrmRuFramework.Pages.NonLoginPages
{
    class LoginPage
    {
        [FindsBy(How = How.CssSelector, Using = "div.icon-object.border-slate-300.text-slate-300")]
        IWebElement logo;
    }
}
