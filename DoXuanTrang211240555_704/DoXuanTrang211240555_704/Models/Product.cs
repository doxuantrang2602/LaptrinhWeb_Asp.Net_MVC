using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DoXuanTrang211240555_704.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
		[Required]
		public string Id { get; set; } = null!;
		[Required]

		public string Name { get; set; } = null!;
		[Required]
		[Range(100, double.MaxValue, ErrorMessage = "Đơn giá phải lớn hơn 100.")]
		public double UnitPrice { get; set; }
		[Required]
		public string? Image { get; set; }
		[Required]

		public bool Available { get; set; }
		[Required]

		public int CategoryId { get; set; }
		public string? Description { get; set; }

        public virtual Category? Category { get; set; } = null!;
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
