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

        var productName = "Sauce Labs Bike Light";
        var productsPage = new ProductsPage(pageInstance, productName);
        await productsPage.AddProductToCart();

        var specificProductPage = new SpecificProductPage(pageInstance);
        await specificProductPage.AddToCart();
        await specificProductPage.GoToCart();

        var cartPage = new CartPage(pageInstance);
        await cartPage.MakeOrder();

        var orderPage = new OrderPage(pageInstance);
        var firstName = "John";
        var lastName = "Denver";
        var postalCode = "123";
        await orderPage.FillAllData(firstName, lastName, postalCode);
        await orderPage.FinishEnteringData();

        var detailOrderPage = new DetailOrderPage(pageInstance);
        await detailOrderPage.ConfirmOrder();

        var completedOrderPage = new CompletedOrderPage(pageInstance);

        Assert.IsTrue(await completedOrderPage.isThereSuccessfulOrderMessage());

        await completedOrderPage.GoBackToProductsPage();
    }
}
