using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ys.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string PName { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime startDate { get; set; }
        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime endDate { get; set; }
        [Display(Name = "Departure")]
        public string departLocation { get; set; }
        [Display(Name = "Arrived")]
        public string arrivedLocation { get; set; }
        [Display(Name = "Type")]
        public string TypeofClass { get; set; }
        [Display(Name = "Price")]
        public int Price { get; set; }
    }
}