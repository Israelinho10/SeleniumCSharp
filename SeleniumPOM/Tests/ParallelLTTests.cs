namespace SeleniumPOM.Tests
{
	[TestFixture("chrome")]
	[TestFixture("MicrosoftEdge")]
	[Parallelizable(ParallelScope.All)]
	public class ParallelLTTests
	{
		private String browser;
		private String version;
		private String os;
		String searchString = "LambdaTest";
		String webPageTitle = "Google";
		ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();


		public ParallelLTTests(String browser, String version, String os)
		{
			this.browser = browser;
			this.version = version;
			this.os = os;
		}

		[SetUp]
		public void Init()
		{
			String username = "user-name";
			String accesskey = "access-key";
			String gridURL = "@hub.lambdatest.com/wd/hub";
		}
	}
}

