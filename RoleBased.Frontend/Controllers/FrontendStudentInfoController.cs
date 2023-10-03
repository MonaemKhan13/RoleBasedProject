using Microsoft.AspNetCore.Mvc;
using RoleBased.Frontend.Models;
using System.Xml.Linq;

namespace RoleBased.Frontend.Controllers;

public class FrontendStudentInfoController : Controller
{
    private readonly HttpClient _httpClient;
    private readonly string _role;

    public FrontendStudentInfoController(IHttpClientFactory httpClient)
    {
        _httpClient = httpClient.CreateClient("Address");
        _role = Environment.GetEnvironmentVariable("Role");
    }

    public IActionResult StudentSignUp()
    {
        if(_role == "Student")
        {
            return View(new SignUp());
        }
        else
        {
            return BadRequest("Access Denied");
        }        
    }

    [HttpPost]
    public async Task<IActionResult> StudentSignUp(SignUp data)
    {
        if(data.Password != data.ConfirmPassword)
        {
            ModelState.AddModelError("","Password Mismatch");
            return View(data);
        }
        if(!ModelState.IsValid)
        {
            ModelState.AddModelError("", "Model State Is Not Valid");
            return View(data);
        }
        List<SignUp> studenInfo = new List<SignUp>()
        {
            new SignUp
            {
                RegNo = "STU-"+data.RegNo,
                Name = data.Name,
                DoB = data.DoB,
                phone = data.phone,
                Email = data.Email
            }
        };
        List<LoginDb_FM> roleInfo = new List<LoginDb_FM>
        {
            new LoginDb_FM
            {
                RegNo = data.RegNo,
                PassWord = data.Password,
                Role = "Student"
            }
        };

        var responceToInsertStudentInfo = await _httpClient.PostAsJsonAsync("StudentInfo_B", studenInfo[0]);
        var responceToInsertRole = await _httpClient.PostAsJsonAsync("LoginDb_B", roleInfo[0]);
        if(responceToInsertStudentInfo.IsSuccessStatusCode && responceToInsertRole.IsSuccessStatusCode)
        {
            return Ok("Sign Up Succesfull");
        }
        return Ok("Sign Up Succesfull");
    }
}
