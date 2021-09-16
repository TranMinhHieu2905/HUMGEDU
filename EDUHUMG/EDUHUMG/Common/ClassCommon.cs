using EDUHUMG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDUHUMG.Common
{
    public class ClassCommon
    {
        public class layuser
        {
            public string user { get; set; }
            public string pass { get; set; }
            public int idcanlay { get; set; }
        }

        public class loginStatus
        {
            public bool status { get; set; }
            public string message { get; set; }

            public int code { get; set; }
            public IEnumerable<Taikhoan> data { get; set; }
        }

        public class DanhmucChicoten
        {
            public string tendanhmuc { get; set; }
        }
    }
}
