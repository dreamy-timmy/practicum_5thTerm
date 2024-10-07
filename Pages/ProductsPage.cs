using Microsoft.Playwright;

namespace Pages;

public class ProductsPage
{
    private ILocator _product;
    public ProductsPage(IPage page, string productName)
    {
        _product =  page.GetByText(productName);
    }

    public async Task AddProductToCart()
    {
        await _product.ClickAsync();   
    }

}
