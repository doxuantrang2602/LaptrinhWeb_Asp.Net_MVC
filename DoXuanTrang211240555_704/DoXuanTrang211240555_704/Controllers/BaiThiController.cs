using DoXuanTrang211240555_704.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DoXuanTrang211240555_704.Controllers
{
	public class BaiThiController : Controller
	{
		private readonly OnlineShopContext _db;
		public BaiThiController(OnlineShopContext db)
		{
			_db = db;
		}
		public IActionResult Index()
		{
			var prd = _db.Products.OrderByDescending(x=>x.UnitPrice).Take(3).ToList();
			return View(prd);
		}
        public IActionResult Create()
        {
            ViewBag.Category = new SelectList(_db.Categories, "Id", "NameVn");
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Id,Name,UnitPrice,Image,Available,CategoryId,Description")] Product product)
        {
            if (ModelState.IsValid)
            {
                _db.Add(product);
                _db.SaveChangesAsync();
                return Redirect(nameof(Index));
            }
            ViewBag.Category = new SelectList(_db.Categories, "Id", "NameVn");
            return View();
        }
        public IActionResult SearchByKeyword(string keyword)
		{
			var prd = _db.Products.Where(x=>x.Id.Contains(keyword) || 
										x.Name.Contains(keyword)).ToList();
			ViewBag.keyword = keyword;
			return PartialView("ProductTable", prd);
		}

    }
}
