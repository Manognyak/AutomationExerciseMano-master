using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Summatix.Automation.Core;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Summatix.Automation.Pages;

namespace Summatix.Automation.Tests.Steps
{
    [Binding]
    class AddHcpSteps : BaseSteps
    {
        private HcpHomePage _HcpHomePage;
        private AddNewHcpPage _AddNewHcpPage;
        private ScenarioContext _scenarioContext;
        public AddHcpSteps(IWebDriver webDriver, Options options, ScenarioContext scenarioContext) : base(webDriver, options)
        {
            _HcpHomePage = new HcpHomePage(webDriver);
            _AddNewHcpPage = new AddNewHcpPage(webDriver);
            _scenarioContext = scenarioContext;
        }
        [Then(@"I add new hcp using '(.*)'")]
        public void ThenIAddNewHcpUsing(string template)
        {
            _HcpHomePage.ClickAddhcp();
            //_scenarioContext.Set(GetDataSheet(template), "hcptestdata");
            _AddNewHcpPage.FillHcpdetails(GetDataSheet(template));
        }

    }
}
