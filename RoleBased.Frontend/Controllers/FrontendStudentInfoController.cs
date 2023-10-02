using Microsoft.AspNetCore.Mvc;

namespace RoleBased.Frontend.Controllers;

public class FrontendStudentInfoController : Controller
{
    public IActionResult SignUp()
    {
        return View();
    }
}
