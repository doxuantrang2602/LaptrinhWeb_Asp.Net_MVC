using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DeThiMau.Models
{
    public partial class HangHoa
    {

        public int MaHang { get; set; }
        [Required]
        public int MaLoai { get; set; }
		[Required]
		public string TenHang { get; set; } = null!;
		[Required]
		[Range(100, 5000, ErrorMessage = "Giá phải nằm trong khoảng từ 100 đến 5000")]
		public decimal? Gia { get; set; }
		[Required]
        [RegularExpression(@"^.*\.(jpg|png|gif|tiff)$", ErrorMessage = "Tên file phải có đuôi .jpg, .png, .gif hoặc .tiff")]

        public string? Anh { get; set; }

        public virtual LoaiHang? MaLoaiNavigation { get; set; } = null!;
    }
}
