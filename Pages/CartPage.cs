

using Microsoft.Playwright;

namespace Pages;
public class CartPage
{
    readonly ILocator checkoutButton;
    public CartPage(IPage page) => 
        checkoutButton = page.GetByRole(AriaRole.Button, new() {Name = "Checkout"});

    public async Task MakeOrder() => await checkoutButton.ClickAsync();
}
