using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.Donation1.Controllers;

public class ContactController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Record(ModelContact modelContact)
    {
        return View("Sucess");
    }

    [HttpGet]
    public IActionResult Help()
    {
        return View();
    }
}
