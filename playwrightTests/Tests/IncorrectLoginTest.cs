using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;
using System.Threading.Tasks;
using Pages;

namespace PlaywrightTests;



[TestClass]
public class IncorrectLoginTests: PageTest
{

    [TestMethod]
    public async Task IncorrectLoginOrPasswordTest() 
    {
        var page = new LoginPage(Page);
        await page.GotoAsync("https://www.saucedemo.com/");
        
        var name = "Some Incorrect name";
        var password = "Some Incorrect password";
        await page.LoginAsync(name, password);

        // await Page.GetByRole(AriaRole.Button, new() { Name = "Login" }).ClickAsync();

        var checkouts = new ExpectCheckouts(page);

         var dependName = "LoginButton";
        await checkouts.Expect_ToBeVisibleAsync(dependName);
        await checkouts.Expect_GetByPlaceholderAsync("Username");  // means page hasn't been changed
        await checkouts.Expect_GetByPlaceholderAsync("Password");

    }
}
