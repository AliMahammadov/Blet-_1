using Microsoft.AspNetCore.Mvc;
using WebApplication1.DAL;
using WebApplication1.Models;
using WebApplication1.View_Models;

namespace WebApplication1.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class PostController : Controller
    {
        AppDbContext _context { get; }
        public PostController(AppDbContext context)
        {
            _context = context;
        }

   
        public IActionResult Index()
        {
            return View(_context.Post.ToList());
        }
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreatePostVM vM)
        {
            if (vM==null)
            {
                return BadRequest();
            }
            Post post = new Post()
            {
                About = vM.About,
                ImgUrl = vM.ImgUrl,
                Title = vM.Title,
                Time = vM.Time
            };
            _context.Post.Add(post);
            _context.SaveChanges();
            return RedirectToAction (nameof(Index));
        }
        public IActionResult Delete(int? id) 
        {
            if (id==null)
            {
                return BadRequest();
            }
            Post postpost = _context.Post.Find(id);
            if (postpost==null)
            {
                return BadRequest();
            }
            _context.Post.Remove(postpost);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update()
        {

            return RedirectToAction(nameof(Update));
        }
    }
}
