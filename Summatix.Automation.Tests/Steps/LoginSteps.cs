using OpenQA.Selenium;
using Summatix.Automation.Core;
using TechTalk.SpecFlow;
using Summatix.Automation.Pages;

namespace Summatix.Automation.Tests.Steps
{
    [Binding]
    class LoginSteps : BaseSteps
    {

        private LoginPage _loginPage;
        public LoginSteps(IWebDriver webDriver, Options options) : base(webDriver, options)
        {
            _loginPage = new LoginPage(webDriver);
        }


        [StepDefinition(@"I login to application using '(.*)' and '(.*)'")]
        public void GivenILoginToApplicationUsingAnd(string email, string password)
        {
            _loginPage.Login(email, password);
        }
    }
}
