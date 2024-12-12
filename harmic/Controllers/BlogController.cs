using harmic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace harmic.Controllers
{
    public class BlogController : Controller
    {
        private readonly HarmicContext _context;

        public BlogController(HarmicContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("/blog/{alias}-{id}.html")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TbBlogs == null)
            {
                return NotFound();
            }

            var blog = await _context.TbBlogs.FirstOrDefaultAsync(m => m.BlogId == id);
            if (blog == null)
            {
                return NotFound();
            }

            ViewBag.blogComment = _context.TbBlogComments.Where(i => i.BlogId == id).ToList();
            return View(blog);
        }
        [HttpPost]
        public async Task<IActionResult> Create(string name, string phone, string email, string message)
        {
            try
            {
                TbBlogComment contact = new TbBlogComment();
                contact.Name = name;
                contact.Phone = phone;
                contact.Email = email;
                contact.Detail = message;
                contact.CreatedDate = DateTime.Now;
                _context.Add(contact);
                await _context.SaveChangesAsync(); 

                return Json(new { status = true });
            }
            catch
            {
                return Json(new { status = false });
            }
        }


    }
}
