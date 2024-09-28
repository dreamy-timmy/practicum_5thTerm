using Microsoft.Playwright;

namespace Pages;

public class ProductsPage
{
    private ILocator _product;
    internal IPage _page;
    public ProductsPage(IPage page, string productName)
    {
        _page = page;
        _product =  page.GetByText(productName);
    }

    public async Task AddProductToCart()
    {
        await _product.ClickAsync();   
        await _page.GetByRole(AriaRole.Button, new() {Name = "Add To Cart"}).ClickAsync();
    }

    public async Task GoToCart()
    {
        await _page.Locator("a.shopping_cart_link").ClickAsync();
    }

    public async Task MakeOrder(string firstName, string lastName, string postalCode)
    {
        await _page.GetByRole(AriaRole.Button, new() {Name = "Checkout"}).ClickAsync();

        await _page.GetByPlaceholder("First Name").FillAsync(firstName);
        await _page.GetByPlaceholder("Last Name").FillAsync(lastName);
        await _page.GetByPlaceholder("Zip/Postal Code").FillAsync(postalCode);

        await _page.GetByRole(AriaRole.Button, new() {Name = "Continue"}).ClickAsync();
        await _page.GetByRole(AriaRole.Button, new() {Name = "Finish"}).ClickAsync();
    }

    public async Task GoHomeAfterOrder()
    {
        await _page.GetByRole(AriaRole.Button, new() {Name = "Back Home"}).ClickAsync();
    }
}
