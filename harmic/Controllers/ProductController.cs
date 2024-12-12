using harmic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace harmic.Controllers
{
    public class ProductController : Controller
    {
        private readonly HarmicContext _context;
        public ProductController(HarmicContext context)
        { 
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Route("/product/{alias}-{id}.html")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TbProducts == null)
            {
                return NotFound();
            }

            var product = await _context.TbProducts.Include(i => i.CategoryProduct).FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            ViewBag.productReview = _context.TbProductReviews.Where(i => i.ProductId == id && i.IsActive == true).ToList();
            ViewBag.productRelated = _context.TbProducts.Where(i => i.ProductId != id && i.CategoryProductId == product.CategoryProductId).Take(5).OrderByDescending(i => i.ProductId).ToList();
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> Create(string name, string phone, string email, string message)
        {
            try
            {
                TbProductReview contact = new TbProductReview();
                contact.Name = name;
                contact.Phone = phone;
                contact.Email = email;
                contact.Detail = message;
                contact.CreatedDate = DateTime.Now;
                _context.Add(contact);
                await _context.SaveChangesAsync(); // Đảm bảo đợi hoàn tất việc lưu

                return Json(new { status = true });
            }
            catch
            {
                return Json(new { status = false });
            }
        }

    }
}
