namespace Summatix.Automation.Configuration
{
	public class Settings
	{
		public static string Target => SummatixConfigurationManager.GetSetting<string>("Target");
		public static string SiteUrl => SummatixConfigurationManager.GetSetting<string>("Web.Url");
	}
}