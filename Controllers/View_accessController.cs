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
using api_financial_control.Models;
using api_financial_control_entitiesLibrary;

namespace api_financial_control.Controllers
{
    public class View_accessController : ApiController
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: api/View_access
        public IQueryable<View_access> GetView_Accesses()
        {
            return db.View_Accesses;
        }

        // GET: api/View_access/5
        [ResponseType(typeof(View_access))]
        public IHttpActionResult GetView_access(int id)
        {
            View_access view_access = db.View_Accesses.Find(id);
            if (view_access == null)
            {
                return NotFound();
            }

            return Ok(view_access);
        }

        // PUT: api/View_access/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutView_access(int id, View_access view_access)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != view_access.ID)
            {
                return BadRequest();
            }

            db.Entry(view_access).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!View_accessExists(id))
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

        // POST: api/View_access
        [ResponseType(typeof(View_access))]
        public IHttpActionResult PostView_access(View_access view_access)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.View_Accesses.Add(view_access);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = view_access.ID }, view_access);
        }

        // DELETE: api/View_access/5
        [ResponseType(typeof(View_access))]
        public IHttpActionResult DeleteView_access(int id)
        {
            View_access view_access = db.View_Accesses.Find(id);
            if (view_access == null)
            {
                return NotFound();
            }

            db.View_Accesses.Remove(view_access);
            db.SaveChanges();

            return Ok(view_access);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool View_accessExists(int id)
        {
            return db.View_Accesses.Count(e => e.ID == id) > 0;
        }
    }
}