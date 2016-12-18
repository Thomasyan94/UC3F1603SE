using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ys.Models
{
    public class Ship
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Ship Name")]
        public String shipName { get; set; }
        [Display(Name = "Type")]
        public String Type { get; set; }
        [Display(Name = "First Class")]
        public int FClass { get; set; }
        [Display(Name = "First Class Price")]
        public int FCPrice { get; set; }
        [Display(Name = "Economy Class")]
        public int EClass { get; set; }
        [Display(Name = "Economy Class Price")]
        public int ECPrice { get; set; }
    }
}