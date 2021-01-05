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
    public class Cost_centerController : ApiController
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: api/Cost_center
        public IQueryable<Cost_center> GetCost_Centers()
        {
            return db.Cost_Centers;
        }

        // GET: api/Cost_center/5
        [ResponseType(typeof(Cost_center))]
        public IHttpActionResult GetCost_center(int id)
        {
            Cost_center cost_center = db.Cost_Centers.Find(id);
            if (cost_center == null)
            {
                return NotFound();
            }

            return Ok(cost_center);
        }

        // PUT: api/Cost_center/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCost_center(int id, Cost_center cost_center)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cost_center.ID)
            {
                return BadRequest();
            }

            db.Entry(cost_center).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Cost_centerExists(id))
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

        // POST: api/Cost_center
        [ResponseType(typeof(Cost_center))]
        public IHttpActionResult PostCost_center(Cost_center cost_center)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cost_Centers.Add(cost_center);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cost_center.ID }, cost_center);
        }

        // DELETE: api/Cost_center/5
        [ResponseType(typeof(Cost_center))]
        public IHttpActionResult DeleteCost_center(int id)
        {
            Cost_center cost_center = db.Cost_Centers.Find(id);
            if (cost_center == null)
            {
                return NotFound();
            }

            db.Cost_Centers.Remove(cost_center);
            db.SaveChanges();

            return Ok(cost_center);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Cost_centerExists(int id)
        {
            return db.Cost_Centers.Count(e => e.ID == id) > 0;
        }
    }
}