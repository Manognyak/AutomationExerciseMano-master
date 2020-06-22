using OpenQA.Selenium;
using System;
using System.Data;
using System.IO;

namespace Summatix.Automation.Core
{
	public abstract class BaseSteps : TechTalk.SpecFlow.Steps
	{
		protected BaseSteps(IWebDriver webDriver, Options options)
		{
			WebDriver = webDriver;
			Options = options;
		}

		protected IWebDriver WebDriver { get; }

		protected Options Options { get; }

		protected string TrimStepArgument(string argument)
		{
			return argument.Replace("'", string.Empty);
		}

		public DataSet GetDataSheet(string filename)
		{
			try
			{
				ExcelUtil excelUtil = new ExcelUtil();
				var path = Path.GetFullPath(@"..\Summatix.Automation.Tests\TestData\"+filename);
				var dataset = excelUtil.ImportDataintoDataset(path);
				return dataset;
			}
			catch (Exception e)
			{
				Console.WriteLine(e.StackTrace);
				return null;
			}
		}
	}
}
