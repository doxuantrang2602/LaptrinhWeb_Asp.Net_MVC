using System;
using System.Collections.Generic;

namespace DoXuanTrang_21124055_703.Models
{
    public partial class NavItem
    {
        public int Id { get; set; }
        public string NavName { get; set; } = null!;
        public string? NavNameVn { get; set; }
    }
}
