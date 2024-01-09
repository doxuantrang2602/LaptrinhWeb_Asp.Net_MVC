using DoXuanTrang_21124055_703.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoXuanTrang_21124055_703.ViewComponents
{
	public class RenderViewComponent : ViewComponent
	{
		private List<Category> cats = new List<Category>();
		private readonly OnlineShopContext _db;
		public RenderViewComponent(OnlineShopContext db)
		{
			_db = db;
			cats = _db.Categories.ToList();
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View("RenderProductLeft", cats);
		}
	}
}
