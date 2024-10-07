using Microsoft.Playwright.MSTest;
using Pages;

namespace PlaywrightTests;


[TestClass]
public class IncorrectLoginTests: PageTest
{

    [TestMethod]
    public async Task IncorrectLoginOrPasswordTest() 
    {
        var loginPage = new LoginPage(Page);
        await loginPage.GotoAsync("https://www.saucedemo.com/");
        
        var name = "Incorrect name";
        var password = "Incorrect password";
        await loginPage.LoginAsync(name, password);

        
        Assert.IsTrue(await loginPage.isThereNameField());
        Assert.IsTrue(await loginPage.isTherePasswordField());

        Assert.IsTrue(await loginPage.isTheErrorMessageAppeared());
    }
}
