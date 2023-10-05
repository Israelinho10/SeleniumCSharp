namespace SeleniumPOM.Pages
{
	public class LoginPage
	{
		private IWebDriver driver;
		private Int32 timeout = 10000;

		public LoginPage(IWebDriver driver)
		{
			this.driver = driver;
			PageFactory.InitElements(driver, this);
		}

        [FindsBy(How = How.XPath, Using = "//*[@id='app']/div/div/div/div/form/div[1]/input")]
        private IWebElement elem_lt_login_user_name;

        [FindsBy(How = How.XPath, Using = "//*[@id='userpassword']")]
        private IWebElement elem_lt_login_password;

        [FindsBy(How = How.XPath, Using = "//*[@id='app']/div/div/div/div/form/div[3]/button")]
        private IWebElement elem_lt_login_button;

		//Returns the page title
		public String GetPageTitle()
		{
			return driver.Title;
		}

        async void async_delay(int delay) => await Task.Delay(delay);

        public void WaitPageCompletion(int timeout)
		{
			var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));
			wait.Until(d => (IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete");
		}

		public void SendUserPassword(String userName, String password)
		{
			//As the page load is already complete, we can directly enter the username and password
			elem_lt_login_user_name.SendKeys(userName);
			async_delay(50);
			elem_lt_login_password.SendKeys(password);
			async_delay(50);
		}

		public FinalPage SubmitUidPwd()
		{
			elem_lt_login_button.Click();
			//Wait for the new page to load. This is the LambdaTest dashboard
			WaitPageCompletion(timeout);

			return new FinalPage(driver);
		}
    }
}

