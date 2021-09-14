using System;
using System.Collections.Generic;

#nullable disable

namespace EDUHUMG.Models
{
    public partial class Taikhoan
    {
        public int Iduser { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
    }
}
