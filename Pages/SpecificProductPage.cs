using Microsoft.Playwright;

namespace Pages;
public class SpecificProductPage
{
    readonly ILocator _addToCartButton, _cart; 
    public SpecificProductPage(IPage page)
    {
        _addToCartButton = page.GetByRole(AriaRole.Button, new() { Name = "Add To Cart"});
        _cart = page.Locator("a.shopping_cart_link");
    }

    public async Task AddToCart()
    {
        await _addToCartButton.ClickAsync();
    }

    public async Task GoToCart()
    {
        await _cart.ClickAsync();
    }
}
