using BLL.Common;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers;

[Authorize(Roles = AppRoles.Admin)]
public class AdminController : Controller
{
    public IActionResult Dashboard()
    {
        return View();
    }
}
