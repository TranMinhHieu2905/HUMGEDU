using System;
using System.Collections.Generic;

#nullable disable

namespace EDUHUMG.Models
{
    public partial class Baihoc
    {
        public Baihoc()
        {
            Khoahocs = new HashSet<Khoahoc>();
        }

        public int Idbaihoc { get; set; }
        public string Tenbaihoc { get; set; }
        public string Motabaihoc { get; set; }
        public string Linkvideobaihoc { get; set; }
        public string Linkbaihoc { get; set; }

        public virtual ICollection<Khoahoc> Khoahocs { get; set; }
    }
}
