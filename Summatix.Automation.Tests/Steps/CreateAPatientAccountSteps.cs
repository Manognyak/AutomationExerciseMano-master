using OpenQA.Selenium;
using Summatix.Automation.Core;
using TechTalk.SpecFlow;

namespace Summatix.Automation.Tests.Steps
{
	[Binding]
	public class CreateAPatientAccountSteps : BaseSteps
	{
		public CreateAPatientAccountSteps(IWebDriver webDriver, Options options) : base(webDriver, options)
		{
		}

	}
}
