using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Threading.Tasks;
using Summatix.Automation.Core;
using Summatix.Automation.Pages.Common;
using Summatix.Automation.Configuration;


namespace Summatix.Automation.Pages
{
    public class LoginPage : BasePage
    {
        private IWebDriver webDriver;
        By emailtxtbox = By.CssSelector("input[formcontrolname='email']");
        By pwdbox = By.CssSelector("input[formcontrolname='password']");
        By login = By.Id("login-button");


        public LoginPage(IWebDriver driver) :base(driver)
        {
            webDriver = driver;
        }

        public void Login(string email, string pwd)
        {
            webDriver.Url = SummatixConfigurationManager.GetSetting<string>("Web.Url");
            webDriver.Manage().Cookies.DeleteAllCookies();
            webDriver.Manage().Window.Maximize();
            waitUtil.PageLoadComplete();
            
            seleniumactions.TypeText(emailtxtbox, email);
            seleniumactions.TypeText(pwdbox, pwd);
            seleniumactions.Click(login);

        }

    }
}
