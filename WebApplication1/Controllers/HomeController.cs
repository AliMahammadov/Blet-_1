using Microsoft.AspNetCore.Mvc;
using WebApplication1.DAL;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        AppDbContext _context { get; }
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM
            {
                Post=_context.Post.ToList()

            };

            return View(homeVM);
        }
    }
}