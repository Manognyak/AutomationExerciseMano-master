using OpenQA.Selenium;
using Summatix.Automation.Configuration;
using System;
using System.Diagnostics;
using System.IO;
using TechTalk.SpecFlow;

namespace Summatix.Automation.Core.Hooks
{
	[Binding]
	public class BeforeAfterStep
	{
		private readonly IWebDriver _webDriver;
		private readonly Stopwatch _stopwatch;

		public BeforeAfterStep(IWebDriver webDriver)
		{
			_webDriver = webDriver;
			_stopwatch = Stopwatch.StartNew();
		}

		[BeforeStep(Order = 0)]
		public void BeforeStep()
		{
			try
			{
				_stopwatch.Reset();
				_stopwatch.Start();
			}
			catch (Exception) { }
		}

		[AfterStep(Order = 0)]
		public void AfterStep()
		{
			try
			{
				_stopwatch.Stop();
				Trace.WriteLine($"== Step execution took {_stopwatch.ElapsedMilliseconds} ms ==");
			}
			catch (Exception) { }
			SaveScreenshot();
		}

		private void SaveScreenshot()
		{
			var directory = Directory.GetCurrentDirectory();
			var screenShotFileName = Path.GetFileNameWithoutExtension(Path.GetTempFileName()) + Constants.PngFileExt;
			var screenShotFilePath = Path.Combine(directory, Constants.ReportFolderName, screenShotFileName);
			try
			{
				SaveImage(screenShotFilePath);
				Console.WriteLine($"SCREENSHOT[ {screenShotFileName} ]SCREENSHOT");
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}

		public void SaveImage(string filename)
		{
			var path = string.Empty;
			var parent = new DirectoryInfo(filename).Parent;
			if (parent != null)
				path = parent.FullName;
			if (path != null && !Directory.Exists(path))
				Directory.CreateDirectory(path);
			((ITakesScreenshot)_webDriver).GetScreenshot().SaveAsFile(filename);
		}
	}
}