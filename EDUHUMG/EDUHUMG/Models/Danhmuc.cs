using System;
using System.Collections.Generic;

#nullable disable

namespace EDUHUMG.Models
{
    public partial class Danhmuc
    {
        public int Iddanhmuc { get; set; }
        public string Tendanhmuc { get; set; }
        public string Linkdanhmuc { get; set; }
        public int Idkhoahoc { get; set; }

        public virtual Khoahoc IdkhoahocNavigation { get; set; }

        public static implicit operator int(Danhmuc v)
        {
            throw new NotImplementedException();
        }
    }
}
