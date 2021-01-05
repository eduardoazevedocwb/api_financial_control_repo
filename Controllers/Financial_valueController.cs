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
    public class Financial_valueController : ApiController
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: api/Financial_value
        public IQueryable<Financial_value> GetFinancial_Values()
        {
            return db.Financial_Values;
        }

        // GET: api/Financial_value/5
        [ResponseType(typeof(Financial_value))]
        public IHttpActionResult GetFinancial_value(int id)
        {
            Financial_value financial_value = db.Financial_Values.Find(id);
            if (financial_value == null)
            {
                return NotFound();
            }

            return Ok(financial_value);
        }

        // PUT: api/Financial_value/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFinancial_value(int id, Financial_value financial_value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != financial_value.ID)
            {
                return BadRequest();
            }

            db.Entry(financial_value).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Financial_valueExists(id))
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

        // POST: api/Financial_value
        [ResponseType(typeof(Financial_value))]
        public IHttpActionResult PostFinancial_value(Financial_value financial_value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Financial_Values.Add(financial_value);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = financial_value.ID }, financial_value);
        }

        // DELETE: api/Financial_value/5
        [ResponseType(typeof(Financial_value))]
        public IHttpActionResult DeleteFinancial_value(int id)
        {
            Financial_value financial_value = db.Financial_Values.Find(id);
            if (financial_value == null)
            {
                return NotFound();
            }

            db.Financial_Values.Remove(financial_value);
            db.SaveChanges();

            return Ok(financial_value);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Financial_valueExists(int id)
        {
            return db.Financial_Values.Count(e => e.ID == id) > 0;
        }
    }
}