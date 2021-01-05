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
    public class Secret_questionController : ApiController
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: api/Secret_question
        public IQueryable<Secret_question> GetSecret_Questions()
        {
            return db.Secret_Questions;
        }

        // GET: api/Secret_question/5
        [ResponseType(typeof(Secret_question))]
        public IHttpActionResult GetSecret_question(int id)
        {
            Secret_question secret_question = db.Secret_Questions.Find(id);
            if (secret_question == null)
            {
                return NotFound();
            }

            return Ok(secret_question);
        }

        // PUT: api/Secret_question/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSecret_question(int id, Secret_question secret_question)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != secret_question.ID)
            {
                return BadRequest();
            }

            db.Entry(secret_question).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Secret_questionExists(id))
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

        // POST: api/Secret_question
        [ResponseType(typeof(Secret_question))]
        public IHttpActionResult PostSecret_question(Secret_question secret_question)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Secret_Questions.Add(secret_question);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = secret_question.ID }, secret_question);
        }

        // DELETE: api/Secret_question/5
        [ResponseType(typeof(Secret_question))]
        public IHttpActionResult DeleteSecret_question(int id)
        {
            Secret_question secret_question = db.Secret_Questions.Find(id);
            if (secret_question == null)
            {
                return NotFound();
            }

            db.Secret_Questions.Remove(secret_question);
            db.SaveChanges();

            return Ok(secret_question);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Secret_questionExists(int id)
        {
            return db.Secret_Questions.Count(e => e.ID == id) > 0;
        }
    }
}