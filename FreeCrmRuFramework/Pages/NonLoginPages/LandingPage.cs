﻿using FreeCrmRuFramework.Tools;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace FreeCrmRuFramework.Pages.NonLoginPages
{
    class LandingPage:DriverInit
    {
        [FindsBy(How = How.CssSelector, Using = "div.autentical")]
        IWebElement btnAuthorize; //авторизоваться

        public LoginPage ClickAuthorizeButton()
        {
            btnAuthorize.Click();
            return new LoginPage();
        }
    }
}
