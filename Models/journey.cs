using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ys.Models
{
    public class journey
    {
        public int Id { get; set; }
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime startDate { get; set; }
        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime endDate { get; set; }
        [Display(Name = "Departure")]
        public string departLocation { get; set; }
        [Display(Name = "Arrived")]
        public string arrivedLocation { get; set; }
        public int shipId { get; set; }
        public int totalFirst { get; set; }
        public int totalEco { get; set; }
    }
}