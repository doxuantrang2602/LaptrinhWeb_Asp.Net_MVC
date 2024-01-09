using DoXuanTrang211240555_704.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoXuanTrang211240555_704.ViewComponents
{
    public class RenderViewComponent : ViewComponent
    {
        private List<NavItem> navItems = new List<NavItem>();
        private readonly OnlineShopContext _db;
        public RenderViewComponent(OnlineShopContext db)
        {
            _db = db;
            navItems = _db.NavItems.ToList();
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("RenderNavItem", navItems);
        }
    }
}
