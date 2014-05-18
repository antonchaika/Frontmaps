using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Mvc;
using DemoRealtApp.DAL.Context;
using DemoRealtApp.DAL.Models;
using FrontMaps.Extensions;
using FrontMaps.Filters;
using FrontMaps.Models;

namespace DemoApp.Controllers
{
    public class MapsController : Controller
    {
        private readonly MapsContext db = new MapsContext();

        // GET: /Maps/
        public ActionResult Index()
        {
            return View(db.GeoObjects.ToList());
        }

        // GET: /Maps/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GeoObject geoobject = db.GeoObjects.Find(id);
            if (geoobject == null)
            {
                return HttpNotFound();
            }
            return View(geoobject);
        }

        // GET: /Maps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Maps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Title,Latitude,Longitude,Type")] GeoObject geoobject)
        {
            if (ModelState.IsValid)
            {
                geoobject.ID = Guid.NewGuid();
                db.GeoObjects.Add(geoobject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(geoobject);
        }

        // GET: /Maps/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GeoObject geoobject = db.GeoObjects.Find(id);
            if (geoobject == null)
            {
                return HttpNotFound();
            }
            return View(geoobject);
        }

        // POST: /Maps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Title,Latitude,Longitude,Type")] GeoObject geoobject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(geoobject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(geoobject);
        }

        // GET: /Maps/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GeoObject geoobject = db.GeoObjects.Find(id);
            if (geoobject == null)
            {
                return HttpNotFound();
            }
            return View(geoobject);
        }

        // POST: /Maps/Delete/5
        [System.Web.Mvc.HttpPost, System.Web.Mvc.ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            GeoObject geoobject = db.GeoObjects.Find(id);
            db.GeoObjects.Remove(geoobject);
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

        [System.Web.Mvc.HttpGet]
        public GeoActionResult CityObjects([FromUri] LatLng northEast, [FromUri] LatLng southWest)
        {
            var query = db
                .GeoObjects
                .FilterBy(new BoundsFilter(), new BoundsFilterArgs(northEast, southWest))
                .CollectGeoData();

            return new GeoActionResult(query);
        }

        /*[System.Web.Mvc.HttpPost]
        public JsonResult AddCityObject([FromBody] GeoObject cityObject)
        {
            
        }*/
    }
}
