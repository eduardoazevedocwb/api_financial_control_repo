using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using api_financial_control_entitiesLibrary;
using Microsoft.AspNetCore.Cors;

namespace api_financial_control.Controllers
{
    public class System_structureController : ApiController
    {
        private DataBaseConnection.DataBaseConnection db = new DataBaseConnection.DataBaseConnection();

        // GET: api/System_structure
        [EnableCors("AllowSpecificOrigin")]
        public IQueryable<System_structure> GetSystem_structure()
        {
            var list = db.Get("System_structure");
            return list.Cast<System_structure>().AsQueryable();
        }

        // GET: api/System_structure/5
        [EnableCors("AllowSpecificOrigin")]
        [ResponseType(typeof(System_structure))]
        public IHttpActionResult GetSystem_structure(int id)
        {
            System_structure System_structure;
            var obj = db.GetById("System_structure", id);
            if (obj != null)
                System_structure = (System_structure)obj;
            else
                return NotFound();

            return Ok(System_structure);
        }

        // PUT: api/System_structure/5
        [EnableCors("AllowSpecificOrigin")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSystem_structure(int id, System_structure System_structure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != System_structure.ID)
            {
                return BadRequest();
            }

            var res = db.SetItem("System_structure", System_structure.ID, Entities_Functions.GetInsertString(System_structure));

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/System_structure
        [EnableCors("AllowSpecificOrigin")]
        [ResponseType(typeof(System_structure))]
        public IHttpActionResult PostSystem_structure(System_structure System_structure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var res = db.SetItem("System_structure", System_structure.ID, Entities_Functions.GetInsertString(System_structure));

            return CreatedAtRoute("DefaultApi", new { id = System_structure.ID }, System_structure);
        }

        // DELETE: api/System_structure/5
        [EnableCors("AllowSpecificOrigin")]
        [ResponseType(typeof(System_structure))]
        public IHttpActionResult DeleteSystem_structure(int id)
        {
            System_structure System_structure = (System_structure)db.GetById("System_structure", id);
            if (System_structure == null)
            {
                return NotFound();
            }
            var res = db.Inative("System_structure", id);

            return Ok(System_structure);
        }

        private bool System_structureExists(int id)
        {
            return db.ContainsId("System_structure", id);
        }
    }
}