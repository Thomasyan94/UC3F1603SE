using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ys.Models
{
    public class CreateJourneyViewModel
    {
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Start_Date { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime End_Date { get; set; }
        [Required]
        public string Departure { get; set; }
        [Required]
        public string Arrival { get; set; }
        [Required]
        public List<string> shipIds { get; set; }
        [Required]
        public SelectList Ships { get; set; }
    }
}