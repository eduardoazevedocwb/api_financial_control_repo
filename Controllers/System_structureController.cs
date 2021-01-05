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
    public class System_structureController : ApiController
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: api/System_structure
        public IQueryable<System_structure> GetSystem_Structures()
        {
            return db.System_Structures;
        }

        // GET: api/System_structure/5
        [ResponseType(typeof(System_structure))]
        public IHttpActionResult GetSystem_structure(int id)
        {
            System_structure system_structure = db.System_Structures.Find(id);
            if (system_structure == null)
            {
                return NotFound();
            }

            return Ok(system_structure);
        }

        // PUT: api/System_structure/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSystem_structure(int id, System_structure system_structure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != system_structure.ID)
            {
                return BadRequest();
            }

            db.Entry(system_structure).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!System_structureExists(id))
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

        // POST: api/System_structure
        [ResponseType(typeof(System_structure))]
        public IHttpActionResult PostSystem_structure(System_structure system_structure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.System_Structures.Add(system_structure);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = system_structure.ID }, system_structure);
        }

        // DELETE: api/System_structure/5
        [ResponseType(typeof(System_structure))]
        public IHttpActionResult DeleteSystem_structure(int id)
        {
            System_structure system_structure = db.System_Structures.Find(id);
            if (system_structure == null)
            {
                return NotFound();
            }

            db.System_Structures.Remove(system_structure);
            db.SaveChanges();

            return Ok(system_structure);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool System_structureExists(int id)
        {
            return db.System_Structures.Count(e => e.ID == id) > 0;
        }
    }
}