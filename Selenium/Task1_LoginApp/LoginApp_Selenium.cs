using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace LoginApp_Selenium
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ValidLogin()
        {
            ChromeDriver chromeDriver = new ChromeDriver();
            //Thread.Sleep(5000);
            //Thread.Sleep(5000);
            chromeDriver.Manage().Window.Maximize();
            //Thread.Sleep(5000);
            chromeDriver.Navigate().GoToUrl("https://www.saucedemo.com/");
            chromeDriver.FindElement(By.Id("user-name")).SendKeys("standard_user");
            //Thread.Sleep(5000);
            chromeDriver.FindElement(By.Id("password")).SendKeys("secret_sauce");
            //Thread.Sleep(5000);
            chromeDriver.FindElement(By.Id("login-button")).Click();
            //Thread.Sleep(5000);
            string expectedText = chromeDriver.FindElement(By.XPath("//span[@class='title']")).Text;
            Assert.AreEqual("Products", expectedText);
            chromeDriver.Close();
        }

        [Test]
        public void InvalidLogin()
        {
            ChromeDriver chromeDriver = new ChromeDriver();
            //Thread.Sleep(5000);
            //Thread.Sleep(5000);
            chromeDriver.Manage().Window.Maximize();
            //Thread.Sleep(5000);
            chromeDriver.Navigate().GoToUrl("https://www.saucedemo.com/");
            chromeDriver.FindElement(By.Id("user-name")).SendKeys("standard_user");
            //Thread.Sleep(5000);
            chromeDriver.FindElement(By.Id("password")).SendKeys("1234");
            //Thread.Sleep(5000);
            chromeDriver.FindElement(By.Id("login-button")).Click();
            //Thread.Sleep(5000);
            string expectedText = chromeDriver.FindElement(By.XPath("//h3[@data-test='error']")).Text;
            Assert.AreEqual("Epic sadface: Username and password do not match any user in this service", expectedText);
            chromeDriver.Close();
        }
    }

}
