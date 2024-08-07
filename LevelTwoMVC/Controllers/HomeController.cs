using Microsoft.AspNetCore.Mvc;

namespace LevelTwoMVC.Controllers;

public class HomeController : Controller
{
    [HttpGet]
    public ViewResult Index() => View();

    [HttpGet]
    public ViewResult About() => View("About");

    [HttpGet]
    public ViewResult Contact() => View();
}