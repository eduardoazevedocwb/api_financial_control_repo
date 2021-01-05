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
    public class Financial_structureController : ApiController
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: api/Financial_structure
        public IQueryable<Financial_structure> GetFinancial_Structures()
        {
            return db.Financial_Structures;
        }

        // GET: api/Financial_structure/5
        [ResponseType(typeof(Financial_structure))]
        public IHttpActionResult GetFinancial_structure(int id)
        {
            Financial_structure financial_structure = db.Financial_Structures.Find(id);
            if (financial_structure == null)
            {
                return NotFound();
            }

            return Ok(financial_structure);
        }

        // PUT: api/Financial_structure/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFinancial_structure(int id, Financial_structure financial_structure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != financial_structure.ID)
            {
                return BadRequest();
            }

            db.Entry(financial_structure).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Financial_structureExists(id))
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

        // POST: api/Financial_structure
        [ResponseType(typeof(Financial_structure))]
        public IHttpActionResult PostFinancial_structure(Financial_structure financial_structure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Financial_Structures.Add(financial_structure);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = financial_structure.ID }, financial_structure);
        }

        // DELETE: api/Financial_structure/5
        [ResponseType(typeof(Financial_structure))]
        public IHttpActionResult DeleteFinancial_structure(int id)
        {
            Financial_structure financial_structure = db.Financial_Structures.Find(id);
            if (financial_structure == null)
            {
                return NotFound();
            }

            db.Financial_Structures.Remove(financial_structure);
            db.SaveChanges();

            return Ok(financial_structure);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Financial_structureExists(int id)
        {
            return db.Financial_Structures.Count(e => e.ID == id) > 0;
        }
    }
}