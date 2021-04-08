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
    public class Financial_structure_accessController : ApiController
    {
        private DataBaseConnection.DataBaseConnection db = new DataBaseConnection.DataBaseConnection();

        // GET: api/Financial_structure_access
        [EnableCors("AllowSpecificOrigin")]
        public IQueryable<Financial_structure_access> GetFinancial_structure_access()
        {
            var list = db.Get("Financial_structure_access");
            return list.Cast<Financial_structure_access>().AsQueryable();
        }

        // GET: api/Financial_structure_access/5
        [EnableCors("AllowSpecificOrigin")]
        [ResponseType(typeof(Financial_structure_access))]
        public IHttpActionResult GetFinancial_structure_access(int id)
        {
            Financial_structure_access Financial_structure_access;
            var obj = db.GetById("Financial_structure_access", id);
            if (obj != null)
                Financial_structure_access = (Financial_structure_access)obj;
            else
                return NotFound();

            return Ok(Financial_structure_access);
        }

        // PUT: api/Financial_structure_access/5
        [EnableCors("AllowSpecificOrigin")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFinancial_structure_access(int id, Financial_structure_access Financial_structure_access)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Financial_structure_access.ID)
            {
                return BadRequest();
            }

            var res = db.SetItem("Financial_structure_access", Financial_structure_access.ID, Entities_Functions.GetInsertString(Financial_structure_access));

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Financial_structure_access
        [EnableCors("AllowSpecificOrigin")]
        [ResponseType(typeof(Financial_structure_access))]
        public IHttpActionResult PostFinancial_structure_access(Financial_structure_access Financial_structure_access)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var res = db.SetItem("Financial_structure_access", Financial_structure_access.ID, Entities_Functions.GetInsertString(Financial_structure_access));

            return CreatedAtRoute("DefaultApi", new { id = Financial_structure_access.ID }, Financial_structure_access);
        }

        // DELETE: api/Financial_structure_access/5
        [EnableCors("AllowSpecificOrigin")]
        [ResponseType(typeof(Financial_structure_access))]
        public IHttpActionResult DeleteFinancial_structure_access(int id)
        {
            Financial_structure_access Financial_structure_access = (Financial_structure_access)db.GetById("Financial_structure_access", id);
            if (Financial_structure_access == null)
            {
                return NotFound();
            }
            var res = db.Inative("Financial_structure_access", id);

            return Ok(Financial_structure_access);
        }

        private bool Financial_structure_accessExists(int id)
        {
            return db.ContainsId("Financial_structure_access", id);
        }
    }
}