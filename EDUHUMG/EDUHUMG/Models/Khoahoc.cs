using System;
using System.Collections.Generic;

#nullable disable

namespace EDUHUMG.Models
{
    public partial class Khoahoc
    {
        public Khoahoc()
        {
            Danhmucs = new HashSet<Danhmuc>();
        }

        public int Idkhoahoc { get; set; }
        public string Tenkhoahoc { get; set; }
        public string Linkkhoahoc { get; set; }
        public string Motakhoahoc { get; set; }
        public string Anhmotakhoahoc { get; set; }
        public int Idbaihoc { get; set; }

        public virtual Baihoc IdbaihocNavigation { get; set; }
        public virtual ICollection<Danhmuc> Danhmucs { get; set; }
    }
}
