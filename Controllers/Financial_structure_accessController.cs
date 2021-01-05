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
    public class Financial_structure_accessController : ApiController
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: api/Financial_structure_access
        public IQueryable<Financial_structure_access> GetFinancial_Structure_Accesses()
        {
            return db.Financial_Structure_Accesses;
        }

        // GET: api/Financial_structure_access/5
        [ResponseType(typeof(Financial_structure_access))]
        public IHttpActionResult GetFinancial_structure_access(int id)
        {
            Financial_structure_access financial_structure_access = db.Financial_Structure_Accesses.Find(id);
            if (financial_structure_access == null)
            {
                return NotFound();
            }

            return Ok(financial_structure_access);
        }

        // PUT: api/Financial_structure_access/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFinancial_structure_access(int id, Financial_structure_access financial_structure_access)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != financial_structure_access.ID)
            {
                return BadRequest();
            }

            db.Entry(financial_structure_access).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Financial_structure_accessExists(id))
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

        // POST: api/Financial_structure_access
        [ResponseType(typeof(Financial_structure_access))]
        public IHttpActionResult PostFinancial_structure_access(Financial_structure_access financial_structure_access)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Financial_Structure_Accesses.Add(financial_structure_access);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = financial_structure_access.ID }, financial_structure_access);
        }

        // DELETE: api/Financial_structure_access/5
        [ResponseType(typeof(Financial_structure_access))]
        public IHttpActionResult DeleteFinancial_structure_access(int id)
        {
            Financial_structure_access financial_structure_access = db.Financial_Structure_Accesses.Find(id);
            if (financial_structure_access == null)
            {
                return NotFound();
            }

            db.Financial_Structure_Accesses.Remove(financial_structure_access);
            db.SaveChanges();

            return Ok(financial_structure_access);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Financial_structure_accessExists(int id)
        {
            return db.Financial_Structure_Accesses.Count(e => e.ID == id) > 0;
        }
    }
}