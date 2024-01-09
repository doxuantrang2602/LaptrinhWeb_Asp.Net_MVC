using DoXuanTrang_21124055_703.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DoXuanTrang_21124055_703.Controllers
{
    public class BaiThiController : Controller
    {
        private readonly OnlineShopContext _db;
        public BaiThiController(OnlineShopContext db)
        {
            _db = db;
        }
		private int pageSize = 3;
		public IActionResult Index(int? mid)
		{
			var products = (IQueryable<Product>)_db.Products.Include(x=>x.Category);
			if (mid != null)
			{
				products = (IQueryable<Product>)_db.Products
					.Include(m => m.Category)
					.Where(m => m.CategoryId == mid);
			}
			int pageNum = (int)Math.Ceiling(products.Count() / (float)pageSize);
			ViewBag.pageNum = pageNum;
			var result = products.Take(pageSize).ToList();
			return View(result);
		}
		public IActionResult ProductPaging(int? pageIndex)
		{
			var products = (IQueryable<Product>)_db.Products;
			int page = (int)(pageIndex == null || pageIndex <= 0 ? 1 : pageIndex);
			int pageNum = (int)Math.Ceiling(products.Count() / (float)pageSize);
			ViewBag.pageNum = pageNum;
			var result = products
				.Skip(pageSize * (page - 1))
				.Take(pageSize)
				.Include(m => m.Category );
			return PartialView("ProductTable", result);
		}
		public IActionResult RenderProductByCate(int mid)
		{
			var lsPrd = _db.Products.Where(x => x.CategoryId == mid).ToList();
			return PartialView("ProductTable", lsPrd);
		}
		public IActionResult SearchByKeyword(string keyword)
		{
			var prd = _db.Products.Where(x => x.Id.Contains(keyword) ||
										x.Name.Contains(keyword)).ToList();
			ViewBag.keyword = keyword;
			return PartialView("ProductTable", prd);
		}
		public IActionResult Create()
        {
            ViewBag.Category = new SelectList(_db.Categories, "Id", "Name");
            return View();
        }
        [HttpPost]
		public IActionResult Create([Bind("Id", "Name", "UnitPrice", "Image","Available", "CategoryId", "Description")] Product obj)
		{
            if(ModelState.IsValid)
            {
                _db.Products.Add(obj);
                _db.SaveChanges();
                return Redirect(nameof(Index));
            }
            ViewBag.Category = new SelectList(_db.Categories, "Id", "Name");
            return View();
		}
		
	}
}
