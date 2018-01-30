using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cargo4You.Models;

namespace Cargo4You.Controllers
{
    public class PackagesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Packages
        public ActionResult Index()
        {
            return View(db.Packages.ToList());
        }

        // GET: Packages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Package package = db.Packages.Find(id);
            if (package == null)
            {
                return HttpNotFound();
            }
            return View(package);
        }

        // GET: Packages/CheckOut/5
        public ActionResult CheckOut(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Package package = db.Packages.Find(id);
            if (package == null)
            {
                return HttpNotFound();
            }
            return View(package);
        }

        // GET: Packages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Packages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,height,width,depth,weight")] Package package)
        {
            calculatePrices(package); //calls method that calculates both prices

            if (ModelState.IsValid)
            {
                db.Packages.Add(package);
                db.SaveChanges();
                return RedirectToAction("CheckOut", "Packages", new { package.id });
            }

            return View(package);
        }

        // GET: Packages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Package package = db.Packages.Find(id);
            if (package == null)
            {
                return HttpNotFound();
            }
            return View(package);
        }

        // POST: Packages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,height,width,depth,weight")] Package package)
        {
            calculatePrices(package); //calls method that calculates both prices

            if (ModelState.IsValid)
            {
                db.Entry(package).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("CheckOut", "Packages", new { package.id });
            }
            return View(package);
        }

        // GET: Packages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Package package = db.Packages.Find(id);
            if (package == null)
            {
                return HttpNotFound();
            }
            return View(package);
        }

        // POST: Packages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Package package = db.Packages.Find(id);
            db.Packages.Remove(package);
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

        public void calculatePrices(Package package)
        {
            //Calculation of Price based on Volume
            double v = (package.height * package.width * package.depth);
            package.vol = v;
            double[] dim = new double[] { 5000.0, 2000, 1000.0, 0.0 }; //Array of Volumes
            double[] pr = new double[] { 150.0, 50.0, 20.0, 10.0 }; //Array of Prices

            for (int i = 0; i <= 3; i++) //for loop compares the calculated volume with array to calculate the appropriate price
            {
                if (v > dim[i])
                {
                    package.dprice = pr[i];
                    break;
                }
            }

            double[] wei = new double[] { 25, 15, 2, 0 }; //Array of Weights
            double[] pr2 = new double[] { 45, 35, 18, 15 }; //Array of Prices 

            for (int i = 0; i <= 3; i++)
            {
                if (package.weight > wei[i])
                {
                    if (i != 0)
                    {
                        package.wprice = pr2[i];
                        break;
                    }
                    else
                    {
                        package.wprice = 45 + ((package.weight - 25) * 0.537);
                        break;
                    }
                }
            }

            //Prices of both Weight and Volume are compared
            if (package.dprice >= package.wprice)
                package.price = package.dprice;
            else
                package.price = package.wprice; //The largest one becomes the Final Price
        }
    }
}
