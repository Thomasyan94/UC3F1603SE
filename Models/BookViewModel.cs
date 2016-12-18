using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ys.Models
{
    public class BookViewModel
    {
        public string ShipName { get; set; }
        public string shipType { get; set; }
        public int totalF { get; set; }
        public int totalE { get; set; }
        public int fPrice { get; set; }
        public int ePrice { get; set; }
        public int jID { get; set; }
    }
}