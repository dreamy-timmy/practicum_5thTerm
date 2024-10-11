

using Microsoft.Playwright;

namespace Pages;

public class CompletedOrderPage
{
    readonly ILocator successfulOrderMessage, backHomeButton;
    public CompletedOrderPage(IPage page) 
    {
        successfulOrderMessage = page.GetByText("Thank you for your order!");
        backHomeButton = page.GetByRole(AriaRole.Button, new() {Name = "Back Home"});
    }

    public async Task<bool> isThereSuccessfulOrderMessage() => await successfulOrderMessage.IsVisibleAsync();
    
    public async Task GoBackToProductsPage() => await backHomeButton.ClickAsync();
}
