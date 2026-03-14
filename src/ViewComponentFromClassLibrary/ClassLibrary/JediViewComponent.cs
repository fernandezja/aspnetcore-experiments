using Microsoft.AspNetCore.Mvc;

namespace ClassLibrary;

public class JediViewComponent : ViewComponent
{
    public JediViewComponent()
    {
    }

    public async Task<IViewComponentResult> InvokeAsync(string jediName)
    {
        var view = "JediCustomView";
        return View(view, jediName);
    }
}
