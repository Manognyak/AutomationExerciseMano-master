using TechTalk.SpecFlow;

namespace Summatix.Automation.Core.Hooks
{
	[Binding]
	public class BeforeAfterTestRun
	{
		[BeforeTestRun(Order = 0)]
		public static void BeforeTestRun()
		{

		}

		[AfterTestRun(Order = 0)]
		public static void AfterTestRun()
		{

		}
	}
}