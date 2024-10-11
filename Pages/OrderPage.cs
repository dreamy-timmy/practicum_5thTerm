
using Microsoft.Playwright;

namespace Pages;
 public class OrderPage
 {
    readonly ILocator continueButton, firstNamePlaceholder, lastNamePlaceholder, postalCodePlaceholder; 
    public OrderPage(IPage page)
    {
        firstNamePlaceholder = page.GetByPlaceholder("First Name");
        lastNamePlaceholder = page.GetByPlaceholder("Last Name");
        postalCodePlaceholder = page.GetByPlaceholder("Zip/Postal Code");

        continueButton = page.GetByRole(AriaRole.Button, new() {Name = "Continue"});
    }

    public async Task FinishEnteringData() => await continueButton.ClickAsync();

    public async Task FillAllData(string firstName, string lastName, string postalCode) 
    {
        await firstNamePlaceholder.FillAsync(firstName);
        await lastNamePlaceholder.FillAsync(lastName);
        await postalCodePlaceholder.FillAsync(postalCode);
    }
 }
 