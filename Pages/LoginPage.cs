using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Pages;

public class LoginPage
{
  private readonly IPage _page;
  private readonly ILocator _username, _password; 
  private readonly ILocator _loginButton;
  public LoginPage(IPage page) 
  {
    _page = page;
    _username = page.GetByPlaceholder("Username");
    _password = page.GetByPlaceholder("Password");
    _loginButton = page.GetByRole(AriaRole.Button, new() { Name = "Login" });
  }

  public async Task<bool> isThereNameField() => await _username.IsVisibleAsync(); 
  public async Task<bool> isTherePasswordField() => await _password.IsVisibleAsync(); 
  public async Task<bool> isTheErrorMessageAppeared() => await _page.Locator("div.error").IsVisibleAsync();

  public async Task GotoAsync(string link)
  {
    await _page.GotoAsync(link);
  }

  public async Task LoginAsync(string name, string p)
  {
    await _username.FillAsync(name);
    await _password.FillAsync(p);
    await _loginButton.ClickAsync();
  }
  
}
