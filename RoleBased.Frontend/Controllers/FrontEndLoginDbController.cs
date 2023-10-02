using Microsoft.AspNetCore.Mvc;

namespace RoleBased.Frontend.Controllers;

public class FrontEndLoginDbController : Controller
{
    public IActionResult Login()
    {
        return View();
    }
}
