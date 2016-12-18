using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ys.Models
{
    public class ReservationViewModel
    {
        public IEnumerable<Ticket> TicketList { get; set; }
        public IEnumerable<Ship> ShipList { get; set; }
        public IEnumerable<journey> JourneyList { get; set; }
    }
}