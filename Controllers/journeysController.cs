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
    [Authorize(Users = "admin@carnival.com")]
    public class journeysController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: journeys
        public ActionResult Index()
        {
            return View(db.journeys.ToList());
        }

        // GET: journeys/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            journey journey = db.journeys.Find(id);
            if (journey == null)
            {
                return HttpNotFound();
            }
            return View(journey);
        }

        // GET: journeys/Create
        public ActionResult Create()
        {
            var allShips = db.Ships.OrderBy(x => x.shipName).ToList();
            List<SelectListItem> shipItem = new List<SelectListItem>();
            foreach (var ship in allShips)
            {
                var item = new SelectListItem
                {
                    Value = ship.Id.ToString(),
                    Text = ship.shipName
                };
                shipItem.Add(item);
            }
            SelectList shipList = new SelectList(shipItem.OrderBy(i => i.Text), "Value", "Text");
            var model = new CreateJourneyViewModel()
            {
                Ships = shipList
            };
            return View(model);
        }

        // POST: journeys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateJourneyViewModel model)
        {
            var selectedShip = db.Ships.Find(int.Parse(model.shipIds.First()));
            var journey = new journey()
            {
                shipId = selectedShip.Id,
                departLocation = model.Departure,
                arrivedLocation = model.Arrival,
                startDate = model.Start_Date,
                endDate = model.End_Date,
                totalFirst = selectedShip.FClass,
                totalEco = selectedShip.EClass                                
            };
            db.journeys.Add(journey);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: journeys/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            journey journey = db.journeys.Find(id);
            if (journey == null)
            {
                return HttpNotFound();
            }
            return View(journey);
        }

        // POST: journeys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,startDate,endDate,departLocation,arrivedLocation,shipId")] journey journey)
        {
            if (ModelState.IsValid)
            {
                db.Entry(journey).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(journey);
        }

        // GET: journeys/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            journey journey = db.journeys.Find(id);
            if (journey == null)
            {
                return HttpNotFound();
            }
            return View(journey);
        }

        // POST: journeys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            journey journey = db.journeys.Find(id);
            db.journeys.Remove(journey);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
