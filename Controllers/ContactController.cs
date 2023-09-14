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
        string message = string.Empty;

        if (modelContact.Email.Equals("rafael.valerio@outlook.com.br"))
        {
            message = "Contato do usuário" + modelContact + "não registrado";
        } else
            message = "Contato registrado com sucesso";

        ViewBag.Message = message;

        return View("Sucess");
    }

    [HttpGet]
    public IActionResult Help()
    {
        return View();
    }
}
