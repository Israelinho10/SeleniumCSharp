namespace SeleniumPOM.Pages
{
    public class HomePage
    {

        private String testUrl = "https://www.lambdatest.com/";

        private IWebDriver driver;
        private WebDriverWait wait;
        Int32 timeout = 10000;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/header/div[3]/nav/a/img")]
        private IWebElement elem_lt_logo;

        [FindsBy(How = How.XPath, Using = "//*[@id='navbarSupportedContent']/ul/li[7]/a]")]
        private IWebElement elem_lt_signup;

        [FindsBy(How = How.LinkText, Using = "Log in")]
        private IWebElement elem_lt_login;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Automation')]")]
        private IWebElement elem_lt_automation;

        async void AsyncDelay() => await Task.Delay(50);

        public void WaitPageCompletition(int timeout)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));
            //Wait for the page to load
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }

        //Go to the designated page
        public void GoToPage()
        {
            driver.Navigate().GoToUrl(testUrl);
        }

        //Return the Page Title
        public String GetPageTitle()
        {
            return driver.Title;
        }

        //Checks wheter the Logo is displayed properly or not
        public bool GetHomePageLog()
        {
            return elem_lt_logo.Displayed;
        }

        public String GetHomePageAttribute(String input_attribute)
        {
            return elem_lt_logo.GetAttribute(input_attribute);
        }

        public LoginPage GoToLoginPage()
        {
            elem_lt_login.Click();

            // Delay added to ensure that the page load is complete
            // We can also use non-blocking delay of the same time
            // but using the DOM state is more advantageous

            //async_delay();
            WaitPageCompletition(timeout);
            return new LoginPage(driver);
        }
    }
}

