using System;
using System.Collections.Generic;

namespace DeThiMau.Models
{
    public partial class TblAccount
    {
        public int Uid { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
