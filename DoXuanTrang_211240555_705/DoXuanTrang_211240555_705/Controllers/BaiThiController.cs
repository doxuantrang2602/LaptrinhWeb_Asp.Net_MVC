using DoXuanTrang_211240555_705.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoXuanTrang_211240555_705.Controllers
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
			var prd = _db.Products.Where(x=>x.Available==true);
			return View(prd);
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create([Bind("Fullname,Email,Password,RePassword")] Customer customer)
		{
			if (ModelState.IsValid)
			{
				_db.Add(customer);
				await _db.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(customer);
		}
		public IActionResult FilterProductByCate(int? mid)
		{
			var product = _db.Products.Include(c => c.Category).AsNoTracking();
			if(mid != null && mid>0)
			{
				product = (IOrderedQueryable<Product>)product.Where(x => x.CategoryId == mid);
			}
			var prdFilter = product.ToList();
			return PartialView("ProductTable", product);
		}
		//public IActionResult RenderProduct(int mid)
		//{
		//	var products = _db.Products.ToList();
		//	if (mid != 0)
		//	{
		//		products = _db.Products.Where(x => x.CategoryId == mid).ToList();
		//	}
		//	return PartialView("ProductTable", products);
		//}
	}
}
