using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Pages;

public class LoginPage
{
  internal readonly IPage _page;
  internal readonly ILocator username, password; 
  internal readonly ILocator loginButton, title;
  public LoginPage(IPage page) 
  {
    _page = page;
    username = page.GetByPlaceholder("Username");
    password = page.GetByPlaceholder("Password");
    loginButton = page.GetByRole(AriaRole.Button, new() { Name = "Login" });

    title = page.Locator("[data-test='title']");

  }
  public ILocator Username
  {
    get {return username;}
  }

  public ILocator Password
  {
    get {return password;}
  }

  public IPage GetPage // for test purposes only
  {
    get => _page;
  }

  public async Task GotoAsync(string link)
  {
    await _page.GotoAsync(link);
  }

  public async Task LoginAsync(string name, string p)
  {
    await username.FillAsync(name);
    await password.FillAsync(p);
    await loginButton.ClickAsync();
  }

  public async Task<string> GetTitleAsync()
  {
    return await _page.TitleAsync(); // Метод для получения заголовка страницы
  }

  
}
