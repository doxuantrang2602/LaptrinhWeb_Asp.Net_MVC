using DeThiMau.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeThiMau.ViewComponents
{
	public class RenderViewComponent : ViewComponent
	{
		private List<LoaiHang> loaiHangs = new List<LoaiHang>();
		private readonly QLHangHoaContext _db;
		public RenderViewComponent(QLHangHoaContext db)
		{
			_db = db;
			loaiHangs = _db.LoaiHangs.ToList();
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View("RenderHeaderBottom",loaiHangs);
		}
	}
}
