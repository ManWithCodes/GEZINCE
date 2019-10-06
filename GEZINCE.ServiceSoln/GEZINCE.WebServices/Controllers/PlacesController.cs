using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using GEZINCE.WebServices.Models;

namespace GEZINCE.WebServices.Controllers
{
    public class PlacesController : ApiController
    {
        private GEZINCEEntities db = new GEZINCEEntities();

        PlacesController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        // GET: api/Places
        [HttpGet]
        public HttpResponseMessage GetPlaces()
        {
            IEnumerable<Place> places = db.Places;

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, places);
            return response;

        }

        // GET: api/Places/5
        [HttpGet]
        [ResponseType(typeof(Place))]
        public HttpResponseMessage GetPlace(int id)
        {
            try
            {
                Place place = db.Places.Where(x => x.Id == id).FirstOrDefault();
                if (place != null)
                {
                    return Request.CreateResponse<Place>(HttpStatusCode.OK, place);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Place Bulunamadi");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // PUT: api/Places/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public HttpResponseMessage PutPlace(int id, Place place)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != place.Id)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, id + " Id'li Kayıt Bulunamadi");
            }

            db.Entry(place).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlaceExists(id))
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Bulunamadi.");
                }
                else
                {
                    throw;
                }
            }

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        // POST: api/Places
        [HttpPost]
        [ResponseType(typeof(Place))]
        public HttpResponseMessage PostPlace(Place place)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            db.Places.Add(place);
            db.SaveChanges();

            return Request.CreateResponse<Place>(HttpStatusCode.OK, place);

        }

        // DELETE: api/Places/5
        [HttpDelete]
        [ResponseType(typeof(Place))]
        public HttpResponseMessage DeletePlace(int id)
        {
            Place place = db.Places.Find(id);
            if (place == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Bulunamadi.");
            }

            db.Places.Remove(place);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);
        }
       
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlaceExists(int id)
        {
            return db.Places.Count(e => e.Id == id) > 0;
        }
    }
}