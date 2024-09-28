using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;
using System.Threading.Tasks;
using Pages;

namespace PlaywrightTests;



[TestClass]
public class EmptyLoginOrPasswordTests: PageTest
{

    [TestMethod]
    public async Task EmptyLoginOrPasswordTest() 
    {
        var page = new LoginPage(Page);
        await page.GotoAsync("https://www.saucedemo.com/"); 
        
        var emptyString = "";

        await page.LoginAsync(emptyString, emptyString); 
 
        var checkouts = new ExpectCheckouts(page);
        
        var dependName = "LoginButton";
        await checkouts.Expect_ToBeVisibleAsync(dependName);
        await checkouts.Expect_GetByPlaceholderAsync("Username");  // means page hasn't been changed
        await checkouts.Expect_GetByPlaceholderAsync("Password");
        
        
    }
}
