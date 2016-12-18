using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ys.Models;

namespace ys.Controllers
{
    public class ReservationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Reservation
        public ActionResult Index()
        {
            var model = new ReservationViewModel()
            {
                TicketList = db.Tickets.Where(x => x.Email == User.Identity.Name).ToList(),
                ShipList = db.Ships.ToList(),                
                JourneyList = db.journeys.ToList()
            };
            return View(model);
        }

        public ActionResult Book(int id)
        {
            var foundJourney = db.journeys.Find(id);
            var foundShip = db.Ships.Find(foundJourney.shipId);
            var model = new BookViewModel()
            {
                ShipName = foundShip.shipName,
                shipType = foundShip.Type,
                totalF = foundJourney.totalFirst,
                totalE = foundJourney.totalEco,
                fPrice = foundShip.FCPrice,
                ePrice = foundShip.ECPrice,
                jID = id
            };
            return View(model);
        }

        [Authorize]
        public ActionResult Purchase(int id, string type)
        {
            var foundJourney = db.journeys.Find(id);
            var foundShip = db.Ships.Find(foundJourney.shipId);
            if(type == "first")
            {
                var model = new ConfirmationViewModel()
                {
                    shipName = foundShip.shipName,
                    shipType = foundShip.Type,
                    departure = foundJourney.departLocation,
                    arrival = foundJourney.arrivedLocation,
                    startDate = foundJourney.startDate,
                    endDate = foundJourney.endDate,
                    cabinType = "First Class",
                    email = User.Identity.Name,
                    price = foundShip.FCPrice,
                    jID = id
                };
                return View(model);
            }
            if (type == "eco")
            {
                var model = new ConfirmationViewModel()
                {
                    shipName = foundShip.shipName,
                    shipType = foundShip.Type,
                    departure = foundJourney.departLocation,
                    arrival = foundJourney.arrivedLocation,
                    startDate = foundJourney.startDate,
                    endDate = foundJourney.endDate,
                    cabinType = "Economic Class",
                    email = User.Identity.Name,
                    price = foundShip.ECPrice,
                    jID = id
                };
                return View(model);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Purchase(ConfirmationViewModel model)
        {
            var foundJourney = db.journeys.Find(model.jID);
            var ticket = new Ticket()
            {
                Email = User.Identity.Name,
                TypeofClass = model.cabinType,
                startDate = foundJourney.startDate,
                endDate = foundJourney.endDate,
                departLocation = foundJourney.departLocation,
                arrivedLocation = foundJourney.arrivedLocation,
                PName = model.name,
                Price = model.price                
            };
            db.Tickets.Add(ticket);
            db.SaveChanges();
            if(model.cabinType == "First Class")
            {
                foundJourney.totalFirst--;
                db.SaveChanges();
            }
            if (model.cabinType == "Economic Class")
            {
                foundJourney.totalEco--;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}