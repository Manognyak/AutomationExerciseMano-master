using OpenQA.Selenium;
using Summatix.Automation.Core;

namespace Summatix.Automation.Pages.Common
{
	public abstract class BasePage
	{
		public Seleniumactions seleniumactions;
		public WaitUtil waitUtil;
		protected BasePage(IWebDriver webDriver)
		{
			WebDriver = webDriver;
			seleniumactions = new Seleniumactions(webDriver);
			waitUtil = new WaitUtil(WebDriver);

		}

		protected IWebDriver WebDriver { get; }
		
	}
}