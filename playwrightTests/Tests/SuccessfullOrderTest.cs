using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;
using System.Threading.Tasks;
using Pages;

namespace PlaywrightTests;



[TestClass]
public class SuccessfullOrder: PageTest
{

    [TestMethod]
    public async Task SuccessfullOrderTest() 
    {
        var pageInstance = Page;

        var page = new LoginPage(pageInstance);
        await page.GotoAsync("https://www.saucedemo.com/");
        
        var correctName = "standard_user";
        var correctPassword = "secret_sauce";
        await page.LoginAsync(correctName, correctPassword);

        // await Page.GotoAsync("https://www.saucedemo.com/");

        // await Expect(Page).ToHaveTitleAsync(new Regex("Swag Labs"));

        // await Page.GetByPlaceholder("Username").FillAsync("standard_user");
        // await Page.GetByPlaceholder("Password").FillAsync("secret_sauce");
        
        // await Page.GetByRole(AriaRole.Button, new() { Name = "Login" }).ClickAsync();
        var productName = "Sauce Labs Bike Light";
        var productsPage = new ProductsPage(pageInstance, productName);

        // await Page.GetByText("Sauce Labs Bike Light").ClickAsync();
        // await Page.GetByRole(AriaRole.Button, new() {Name = "Add To Cart"}).ClickAsync();

        // await Page.GetByTestId("shopping_cart_link").ClickAsync();

        // await Page.GetByTestId("shopping_cart_link").ClickAsync();
        //   await Page.GetByRole(AriaRole.Link, new() {Name = "shopping_cart_link"}).ClickAsync();
        
        // await Page.Locator("a.shopping_cart_link").ClickAsync();
        
        await productsPage.AddProductToCart();
        await productsPage.GoToCart();
        var firstName = "John";
        var lastName = "Denver";
        var postalCode = "123";

        await productsPage.MakeOrder(firstName, lastName, postalCode);

         // shopping_cart_link
        // await Page.GetByRole(AriaRole.Button, new() {Name = "Checkout"}).ClickAsync();

        // await Page.GetByPlaceholder("First Name").FillAsync("John");
        // await Page.GetByPlaceholder("Last Name").FillAsync("Denver");
        // await Page.GetByPlaceholder("Zip/Postal Code").FillAsync("123");
        // await Page.GetByRole(AriaRole.Button, new() {Name = "Continue"}).ClickAsync();


        // await Page.GetByRole(AriaRole.Button, new() {Name = "Finish"}).ClickAsync();
        
        var checkouts = new ExpectCheckouts(productsPage);
        await checkouts.Expect_ToBeVisibleAsync("Checkout: Complete!");
        await checkouts.Expect_ToBeVisibleAsync("Thank you for your order!");

        // await Expect(Page.GetByText("Checkout: Complete!")).ToBeVisibleAsync(); // last page
        // await Expect(Page.GetByText("Thank you for your order!")).ToBeVisibleAsync();        
        
        // await Page.GetByRole(AriaRole.Button, new() {Name = "Back Home"}).ClickAsync();
        //
        await productsPage.GoHomeAfterOrder();

    }
}


