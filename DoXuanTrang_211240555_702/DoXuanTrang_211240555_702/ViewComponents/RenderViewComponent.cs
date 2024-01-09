using DoXuanTrang_211240555_702.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoXuanTrang_211240555_702.ViewComponents
{
	public class RenderViewComponent: ViewComponent
	{
		private readonly OnlineShopContext _db;
		private List<NavItem> navItems = new List<NavItem>();
		public RenderViewComponent(OnlineShopContext db)
		{
			_db = db;
			navItems = _db.NavItems.ToList();
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View("RenderNav", navItems);
		}

	}
}
