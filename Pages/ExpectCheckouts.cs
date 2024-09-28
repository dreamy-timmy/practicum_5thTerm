using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;

namespace Pages;
public class ExpectCheckouts: PageTest
{
    LoginPage? _loginPage;
    IPage? _productsPage;

    public ExpectCheckouts(LoginPage loginPage)
    {
        _loginPage = loginPage;
    }

    public ExpectCheckouts(ProductsPage productsPage)
    {
        _productsPage = productsPage._page;
    }
    public async Task Expect_ToBeVisibleAsync(string depenName)  // hardcoded, but I don't quite see other option
    {
        switch (depenName)
        {
            case "Login Button": 
                await Expect(_loginPage!.loginButton).ToBeVisibleAsync();
                break;    
            case "Checkout: Complete!":
                await Expect(_productsPage!.GetByText("Checkout: Complete!")).ToBeVisibleAsync();
                break;
            case "Thank you for your order!":
                await Expect(_productsPage!.GetByText("Thank you for your order!")).ToBeVisibleAsync();
                break;   
        }
    }


    public async Task Expect_GetByPlaceholderAsync(string placeHolder)
    {
        if (_loginPage != null)
            await Expect(_loginPage!.GetPage.GetByPlaceholder(placeHolder)).ToBeVisibleAsync();  // means page hasn't been changed
        else throw new Exception();
    }

    
}
