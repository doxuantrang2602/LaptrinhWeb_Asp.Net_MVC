using DoXuanTrang_211240555_705.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DoXuanTrang_211240555_705.ViewComponents
{
	public class RenderViewComponent : ViewComponent
	{
		private readonly OnlineShopContext _db;
		private List<Category> cats = new List<Category>();
		public RenderViewComponent(OnlineShopContext db)
		{
			_db = db;
			cats = _db.Categories.ToList();
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			//ViewBag.Categories = new SelectList(_db.Categories, "Id", "Name");
			return View("RenderCategories", cats);
		}
	}
}
