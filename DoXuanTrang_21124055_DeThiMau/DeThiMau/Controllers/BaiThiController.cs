using DeThiMau.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DeThiMau.Controllers
{
	public class BaiThiController : Controller
	{
		private readonly QLHangHoaContext _db;
		public BaiThiController(QLHangHoaContext db)
		{
			_db = db;
		}

		public IActionResult Index()
		{
			List<HangHoa> hangHoas = _db.HangHoas.Where(x=>x.Gia>=100).ToList();
			return View(hangHoas);
		}
		public IActionResult Create()
		{
			ViewBag.LoaiHang = new SelectList(_db.LoaiHangs, "MaLoai", "TenLoai");
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create([Bind("MaLoai,TenHang,Gia,Anh")] HangHoa hangHoa)
		{
			if (ModelState.IsValid)
			{
				_db.Add(hangHoa);
				_db.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			ViewBag.LoaiHang = new SelectList(_db.LoaiHangs, "MaLoai", "TenLoai");
			return View(hangHoa);
		}
		public IActionResult RenderByID(int mid)
		{
			List<HangHoa> lstLoaiHang = _db.HangHoas.Where(x => x.MaLoai == mid).ToList();
			return PartialView("RenderLoaiHang", lstLoaiHang);
		}
	}
}
