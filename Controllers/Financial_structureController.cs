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
    public class Financial_structureController : ApiController
    {
        private DataBaseConnection.DataBaseConnection db = new DataBaseConnection.DataBaseConnection();

        // GET: api/Financial_structure
        [EnableCors("AllowSpecificOrigin")]
        public IQueryable<Financial_structure> GetFinancial_structure()
        {
            var list = db.Get("Financial_structure");
            return list.Cast<Financial_structure>().AsQueryable();
        }

        // GET: api/Financial_structure/5
        [EnableCors("AllowSpecificOrigin")]
        [ResponseType(typeof(Financial_structure))]
        public IHttpActionResult GetFinancial_structure(int id)
        {
            Financial_structure Financial_structure;
            var obj = db.GetById("Financial_structure", id);
            if (obj != null)
                Financial_structure = (Financial_structure)obj;
            else
                return NotFound();

            return Ok(Financial_structure);
        }

        // PUT: api/Financial_structure/5
        [EnableCors("AllowSpecificOrigin")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFinancial_structure(int id, Financial_structure Financial_structure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Financial_structure.ID)
            {
                return BadRequest();
            }

            var res = db.SetItem("Financial_structure", Financial_structure.ID, Entities_Functions.GetInsertString(Financial_structure));

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Financial_structure
        [EnableCors("AllowSpecificOrigin")]
        [ResponseType(typeof(Financial_structure))]
        public IHttpActionResult PostFinancial_structure(Financial_structure Financial_structure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var res = db.SetItem("Financial_structure", Financial_structure.ID, Entities_Functions.GetInsertString(Financial_structure));

            return CreatedAtRoute("DefaultApi", new { id = Financial_structure.ID }, Financial_structure);
        }

        // DELETE: api/Financial_structure/5
        [EnableCors("AllowSpecificOrigin")]
        [ResponseType(typeof(Financial_structure))]
        public IHttpActionResult DeleteFinancial_structure(int id)
        {
            Financial_structure Financial_structure = (Financial_structure)db.GetById("Financial_structure", id);
            if (Financial_structure == null)
            {
                return NotFound();
            }
            var res = db.Inative("Financial_structure", id);

            return Ok(Financial_structure);
        }

        private bool Financial_structureExists(int id)
        {
            return db.ContainsId("Financial_structure", id);
        }
    }
}