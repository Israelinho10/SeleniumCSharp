namespace SeleniumPOM.Pages
{
	public class FinalPage
	{
		private IWebDriver driver;
        Int32 timeout = 10000;

		public FinalPage(IWebDriver driver)
		{
			this.driver = driver;
			PageFactory.InitElements(driver, this);
		}

        [FindsBy(How = How.XPath, Using = "//*[@id='app']/header/div/div/div[1]/a/svg/g/path[2]")]
        private IWebElement elem_lt_logo;

        [FindsBy(How = How.XPath, Using = "//*[@id='app']/header/aside/ul/li[4]/a")]
        private IWebElement elem_lt_automation;

		public String GetPageTitle()
		{
			return driver.Title;
		}

		//Checks wheter the LambdaTest Logo is displayed properly or not
		public bool GetLTPageLogo()
		{
			return elem_lt_logo.Displayed;
		}

		public void LoadComplete(int timeout)
		{
			var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));
			wait.Until(d => (IJavaScriptExecutor)d).ExecuteScript("return document.ReadyState").Equals("complete");
		}

		public void AutomationTabClick()
		{
			elem_lt_automation.Click();
			LoadComplete(timeout);
		}
    }
}

