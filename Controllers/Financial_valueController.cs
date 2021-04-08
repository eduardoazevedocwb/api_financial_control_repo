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
    public class Financial_valueController : ApiController
    {
        private DataBaseConnection.DataBaseConnection db = new DataBaseConnection.DataBaseConnection();

        // GET: api/Financial_value
        [EnableCors("AllowSpecificOrigin")]
        public IQueryable<Financial_value> GetFinancial_value()
        {
            var list = db.Get("Financial_value");
            return list.Cast<Financial_value>().AsQueryable();
        }

        // GET: api/Financial_value/5
        [EnableCors("AllowSpecificOrigin")]
        [ResponseType(typeof(Financial_value))]
        public IHttpActionResult GetFinancial_value(int id)
        {
            Financial_value Financial_value;
            var obj = db.GetById("Financial_value", id);
            if (obj != null)
                Financial_value = (Financial_value)obj;
            else
                return NotFound();

            return Ok(Financial_value);
        }

        // PUT: api/Financial_value/5
        [EnableCors("AllowSpecificOrigin")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFinancial_value(int id, Financial_value Financial_value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Financial_value.ID)
            {
                return BadRequest();
            }

            var res = db.SetItem("Financial_value", Financial_value.ID,Entities_Functions.GetInsertString(Financial_value));

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Financial_value
        [EnableCors("AllowSpecificOrigin")]
        [ResponseType(typeof(Financial_value))]
        public IHttpActionResult PostFinancial_value(Financial_value Financial_value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var res = db.SetItem("Financial_value", Financial_value.ID, Entities_Functions.GetInsertString(Financial_value));

            return CreatedAtRoute("DefaultApi", new { id = Financial_value.ID }, Financial_value);
        }

        // DELETE: api/Financial_value/5
        [EnableCors("AllowSpecificOrigin")]
        [ResponseType(typeof(Financial_value))]
        public IHttpActionResult DeleteFinancial_value(int id)
        {
            Financial_value Financial_value = (Financial_value)db.GetById("Financial_value", id);
            if (Financial_value == null)
            {
                return NotFound();
            }
            var res = db.Inative("Financial_value", id);

            return Ok(Financial_value);
        }

        private bool Financial_valueExists(int id)
        {
            return db.ContainsId("Financial_value", id);
        }
    }
}