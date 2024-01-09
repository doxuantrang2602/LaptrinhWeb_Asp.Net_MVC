using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DoXuanTrang_211240555_705.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        [Required]
        public string Fullname { get; set; } = null!;
        [Required]
        [RegularExpression(@".*@gmail\.com$", ErrorMessage = "Email không hợp lệ!")]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        [Required]
        public string RePassword { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}
