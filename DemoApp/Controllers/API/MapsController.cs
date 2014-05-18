using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using DemoRealtApp.DAL.Context;
using DemoRealtApp.DAL.Models;
using FrontMaps.Extensions;
using FrontMaps.Filters;
using FrontMaps.Models;

namespace DemoApp.Controllers.API
{
    public class MapsController : ApiController
    {
        private readonly MapsContext db = new MapsContext();

        // GET api/MapsApi

        /*public IHttpActionResult GetGeoObjects([FromUri] LatLng left, [FromUri] LatLng right)
        {
            return db
                .GeoObjects
                .FilterBy(new BoundsFilter(), new BoundsFilterArgs(left, right))
                .QueryGeoData();
        }*/

        // GET api/MapsApi/5
        [ResponseType(typeof(GeoObject))]
        public IHttpActionResult GetGeoObject(Guid id)
        {
            GeoObject geoobject = db.GeoObjects.Find(id);
            if (geoobject == null)
            {
                return NotFound();
            }

            return Ok(geoobject);
        }

        // PUT api/MapsApi/5
        public IHttpActionResult PutGeoObject(Guid id, GeoObject geoobject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != geoobject.ID)
            {
                return BadRequest();
            }

            db.Entry(geoobject).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeoObjectExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/MapsApi
        [ResponseType(typeof(GeoObject))]
        public IHttpActionResult PostGeoObject(GeoObject geoobject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GeoObjects.Add(geoobject);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (GeoObjectExists(geoobject.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = geoobject.ID }, geoobject);
        }

        // DELETE api/MapsApi/5
        [ResponseType(typeof(GeoObject))]
        public IHttpActionResult DeleteGeoObject(Guid id)
        {
            GeoObject geoobject = db.GeoObjects.Find(id);
            if (geoobject == null)
            {
                return NotFound();
            }

            db.GeoObjects.Remove(geoobject);
            db.SaveChanges();

            return Ok(geoobject);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GeoObjectExists(Guid id)
        {
            return db.GeoObjects.Count(e => e.ID == id) > 0;
        }
    }
}