using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ys.Models
{
    public class ConfirmationViewModel
    {
        public string shipName { get; set; }
        public string shipType { get; set; }
        public string cabinType { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string departure { get; set; }
        public string arrival { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string creditCardNumber { get; set; }
        public int price { get; set; }
        public int jID { get; set; }
    }
}