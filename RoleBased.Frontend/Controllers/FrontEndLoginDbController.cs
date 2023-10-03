using Microsoft.AspNetCore.Mvc;
using RoleBased.Frontend.Models;

namespace RoleBased.Frontend.Controllers;

public class FrontEndLoginDbController : Controller
{
    private readonly HttpClient _httpClient;

    public FrontEndLoginDbController(IHttpClientFactory httpClient)
    {
        _httpClient = httpClient.CreateClient("Address");
    }
    public IActionResult Login()
    {
        Environment.SetEnvironmentVariable("Role", "");
        Environment.SetEnvironmentVariable("Name", "");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginDb_FM data)
    {
        var resposceToLogin = await _httpClient.GetAsync($"LoginDb_B/Id:string?Id={data.RegNo}");
        if (resposceToLogin.IsSuccessStatusCode)
        {
            var _loginData = await resposceToLogin.Content.ReadFromJsonAsync<LoginDb_FM>();
            if(data.PassWord == _loginData.PassWord)
            {
                Environment.SetEnvironmentVariable("Role", _loginData.Role);
                if (_loginData.Role == "Student")
                {
                    var responceTOStudent = await _httpClient.GetAsync($"StudentInfo_B/Id:string?Id={data.RegNo}");
                    if (responceTOStudent.IsSuccessStatusCode)
                    {
                        var studentData = await responceTOStudent.Content.ReadFromJsonAsync<StudentInfo_FM>();
                        Environment.SetEnvironmentVariable("Name", studentData.Name);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else if (_loginData.Role == "Teacher")
                {
                    Environment.SetEnvironmentVariable("Name", "Teacher");
                    return RedirectToAction("Index", "Home");
                }
                else
                {

                }
            }
            else
            {
                ModelState.AddModelError("","Password Mis Match");
                return View(data);
            }
        }
        ModelState.AddModelError("","Data Does Not Exits");
        return View();
    }
}
