﻿using BoDi;
using OpenQA.Selenium;
using Summatix.Automation.Configuration;
using Summatix.Automation.WebDriver;
using System;
using TechTalk.SpecFlow;

namespace Summatix.Automation.Core.Hooks
{
	[Binding]
	public class BeforeAfterScenario
	{
		private readonly IObjectContainer _objectContainer;
		private readonly WebDriverFactory _webDriverFactory = new WebDriverFactory();
		private IWebDriver _webDriver;

		public BeforeAfterScenario(IObjectContainer objectContainer)
		{
			switch (Settings.Target)
			{
				case "Chrome":
					_objectContainer = objectContainer;
					break;
				default:
					throw new PlatformNotSupportedException(
						$"Your target '{Settings.Target}' is not supported");
			}
		}

		[BeforeScenario(Order = 0)]
		public void BeforeScenario()
		{
			RegisterOptions();
			RegisterWebDriver();
		}

		[BeforeScenario("@Pending", Order = 1)]
		public void PendingScenario() => throw new PendingStepException();

		[AfterScenario(Order = 1)]
		public void AfterScenarioCloseWebDriver()
		{
			_webDriver.Manage().Cookies.DeleteAllCookies();
			DisposeWebDriver();
		}


		private void RegisterOptions()
		{
			var options = new Options
			{
				SiteUri = new Uri(Settings.SiteUrl),
			};
			_objectContainer.RegisterInstanceAs(options);
		}

		private void RegisterWebDriver()
		{
			_webDriver = _webDriverFactory.Create(Settings.Target);
			_objectContainer.RegisterInstanceAs(_webDriver);
		}

		private void DisposeWebDriver()
		{
			_webDriver.Quit();
			_webDriver.Dispose();
		}
	}
}