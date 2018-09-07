using FreeCrmRuFramework.Tools;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCrmRuFramework.Pages.NonLoginPages
{
    class RegistrationPage : DriverInit
    {
        [FindsBy (How = How.CssSelector, Using = ".icon-object.border-slate-300.text-slate-300")]
        IWebElement logopage;

        public RegistrationPage()
        {
            PageFactory.InitElements(driver, this);
        }

        public bool LogoIsDisplayed()
        {
            bool flag = logopage.Displayed;
            return flag;
        }
    }
}
