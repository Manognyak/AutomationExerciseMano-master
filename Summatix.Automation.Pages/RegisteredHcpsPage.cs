using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Summatix.Automation.Core;
using Summatix.Automation.Pages.Common;
using Summatix.Automation.Configuration;
using OpenQA.Selenium;

namespace Summatix.Automation.Pages
{
    public class HcpHomePage : BasePage
    {
        private IWebDriver webDriver;
        By AddnewhcpBtn = By.CssSelector("button[smxdataauto='AddHcpButton']");
        



        public HcpHomePage(IWebDriver driver) : base(driver)
        {
            webDriver = driver;
            
        }

        public void ClickAddhcp()
        {
            waitUtil.PageLoadComplete();
            seleniumactions.Click(AddnewhcpBtn);
        }
    }
}
