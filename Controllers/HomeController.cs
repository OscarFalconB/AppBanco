using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pc_02.Data;
using pc_02.Models;

namespace pc_02.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _ctx;


    public HomeController(ILogger<HomeController> logger, ApplicationDbContext ctx)
    {
        _logger = logger;
        _ctx = ctx;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateAccount(Account account)
    {
        if (!ModelState.IsValid)
        {
            ViewData["ErrorMessage"] = "Error en el formulario";
            return View("Index");
        }

        _ctx.Add(account);
        await _ctx.SaveChangesAsync();

        ViewData["SuccessMessage"] = "Cuenta creada correctamente";

        return View("Index", account);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
