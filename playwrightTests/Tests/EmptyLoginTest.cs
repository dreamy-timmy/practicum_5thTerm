using Microsoft.Playwright.MSTest;
using Pages;

namespace PlaywrightTests;


[TestClass]
public class EmptyLoginOrPasswordTests: PageTest
{

    [TestMethod]
    public async Task EmptyLoginOrPasswordTest() 
    {
        var loginPage = new LoginPage(Page);
        await loginPage.GotoAsync("https://www.saucedemo.com/"); 
        
        var emptyString = "";

        await loginPage.LoginAsync(emptyString, emptyString); 
 
        Assert.IsTrue(await loginPage.isThereNameField());
        Assert.IsTrue(await loginPage.isTherePasswordField());

        Assert.IsTrue(await loginPage.isTheErrorMessageAppeared());

    }
}
