using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pc_02.Data;

namespace pc_02.Controllers
{
    public class ViewAccountsController : Controller
    {
        private readonly ILogger<ViewAccountsController> _logger;
        private readonly ApplicationDbContext _ctx;

        public ViewAccountsController(ILogger<ViewAccountsController> logger, ApplicationDbContext ctx)
        {
            _logger = logger;
            _ctx = ctx;
        }

        public async Task<IActionResult> Index()
        {
            var accounts = await _ctx.DataAccounts.ToListAsync();
            return View(accounts);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}