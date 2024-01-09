using DoXuanTrang_211240555_702.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DoXuanTrang_211240555_702.Controllers
{
	public class BaiThiController : Controller
	{
		private readonly OnlineShopContext _db;
		public BaiThiController(OnlineShopContext db)
		{
			_db = db;
		}
		private int pageSize = 2;
		public IActionResult Index()
		{
			List<Product> products = _db.Products.OrderByDescending(x=>x.UnitPrice).Take(4).ToList();
			return View(products);
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
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
		public IActionResult SearchByName(string keyword)
		{
			var prd = (IQueryable<Product>)_db.Products;
			prd = prd.Where(x=>x.Name.Contains(keyword));
			ViewBag.keyword = keyword;
			return PartialView("ProductTable", prd);
		}
		public IActionResult SearchAndPaging(string keyword)
		{
			var prd = (IQueryable<Product>)_db.Products;
			prd = prd.Where(x => x.Name.Contains(keyword));
			ViewBag.keyword = keyword;
			return PartialView("ProductTable", prd);
		}
		public async Task<IActionResult> Edit(string id)
		{
			if (id == null || _db.Products == null)
			{
				return NotFound();
			}

			var product = await _db.Products.FindAsync(id);
			if (product == null)
			{
				return NotFound();
			}
			ViewBag.Category= new SelectList(_db.Categories, "Id", "Name");
			return View(product);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(string id, [Bind("Id,Name,UnitPrice,Image,Available,CategoryId,Description")] Product product)
		{
			if (id != product.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_db.Update(product);
					await _db.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!ProductExists(product.Id))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			ViewBag.Category = new SelectList(_db.Categories, "Id", "Name");
			return View(product);
		}

		public async Task<IActionResult> Delete(string id)
		{
			if (id == null || _db.Products == null)
			{
				return NotFound();
			}

			var product = await _db.Products
				.Include(p => p.Category)
				.FirstOrDefaultAsync(m => m.Id == id);
			if (product == null)
			{
				return NotFound();
			}

			return View(product);
		}
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(string id)
		{
			if (_db.Products == null)
			{
				return Problem("Entity set 'OnlineShopContext.Products'  is null.");
			}
			var product = await _db.Products.FindAsync(id);
			if (product != null)
			{
				_db.Products.Remove(product);
			}

			await _db.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool ProductExists(string id)
		{
			return (_db.Products?.Any(e => e.Id == id)).GetValueOrDefault();
		}

	}
}
