

using Microsoft.Playwright;

namespace Pages;

public class DetailOrderPage
{
    readonly ILocator finishButton;
    public DetailOrderPage(IPage page) => finishButton = page.GetByRole(AriaRole.Button, new() {Name = "Finish"});

    public async Task ConfirmOrder() => await finishButton.ClickAsync();

}
