using OpenQA.Selenium;

namespace Summatix.Automation.Pages.Common
{
	public abstract class BasePage
	{
		protected BasePage(IWebDriver webDriver)
		{
			WebDriver = webDriver;
		}

		protected IWebDriver WebDriver { get; }
	}
}