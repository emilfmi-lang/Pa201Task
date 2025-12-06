
using Microsoft.AspNetCore.Mvc;

namespace Task_12._03._2025_.Controllers;
public class HomeController : Controller
{
    public JsonResult Index()
    {
        return Json(new { message = "Hello from HomeController!" });
    }
}
