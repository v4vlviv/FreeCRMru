using FreeCrmRuFramework.Tools;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCrmRuFramework.Pages
{
    class HomePage :DriverInit
    {
        [FindsBy(How = How.CssSelector, Using = "span.media-heading.text-semibold.ng-binding")]
        IWebElement titleNameUser;

        public HomePage()
        {
            PageFactory.InitElements(driver, this);
        }

        public string VerifyUserName()
        {
            string nameOfUser = titleNameUser.Text;
            return nameOfUser;
        }
    }
}
