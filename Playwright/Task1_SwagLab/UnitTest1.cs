using Microsoft.Playwright;

namespace test01
{
    public class Tests
    {
        //[SetUp]
        //public void Setup()
        //{
        //}
        IPlaywright playwright;
        IPage page;

        [Test]
        public async Task Test1()
        {
            string actualText = "Products";
            playwright = await Playwright.CreateAsync();
            {
                var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                {
                    Headless = false
                });
                //Browser instance
                page = await browser.NewPageAsync();
                //Go to the Url
                await page.GotoAsync("https://www.saucedemo.com");
                //Enter Username
                await page.FillAsync("#user-name", "standard_user");
                await page.FillAsync("#password", "secret_sauce");
                await page.ClickAsync("#login-button");
                Assert.That(actualText, Is.EqualTo(await page.InnerTextAsync("//span[@class='title']")));

                // ========== Order Placement Steps Start ==========
                // Add product to cart
                await page.ClickAsync("text=Add to cart");

                // Go to cart
                await page.ClickAsync(".shopping_cart_link");

                // Click Checkout
                await page.ClickAsync("#checkout");

                // Fill checkout information
                await page.FillAsync("#first-name", "John");
                await page.FillAsync("#last-name", "Doe");
                await page.FillAsync("#postal-code", "12345");

                // Continue
                await page.ClickAsync("#continue");

                // Finish order
                await page.ClickAsync("#finish");

                // Verify order success
                string thankYouMessage = await page.InnerTextAsync(".complete-header");
                Assert.That(thankYouMessage, Is.EqualTo("Thank you for your order!"));
                // ========== Order Placement Steps End ==========
            }
        }
    }
}