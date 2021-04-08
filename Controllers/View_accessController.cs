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
    public class View_accessController : ApiController
    {
        private DataBaseConnection.DataBaseConnection db = new DataBaseConnection.DataBaseConnection();

        // GET: api/View_access
        [EnableCors("AllowSpecificOrigin")]
        public IQueryable<View_access> GetView_access()
        {
            var list = db.Get("View_access");
            return list.Cast<View_access>().AsQueryable();
        }

        // GET: api/View_access/5
        [EnableCors("AllowSpecificOrigin")]
        [ResponseType(typeof(View_access))]
        public IHttpActionResult GetView_access(int id)
        {
            View_access View_access;
            var obj = db.GetById("View_access", id);
            if (obj != null)
                View_access = (View_access)obj;
            else
                return NotFound();

            return Ok(View_access);
        }

        // PUT: api/View_access/5
        [EnableCors("AllowSpecificOrigin")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutView_access(int id, View_access View_access)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != View_access.ID)
            {
                return BadRequest();
            }

            var res = db.SetItem("View_access", View_access.ID, Entities_Functions.GetInsertString(View_access));

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/View_access
        [EnableCors("AllowSpecificOrigin")]
        [ResponseType(typeof(View_access))]
        public IHttpActionResult PostView_access(View_access View_access)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var res = db.SetItem("View_access", View_access.ID, Entities_Functions.GetInsertString(View_access));

            return CreatedAtRoute("DefaultApi", new { id = View_access.ID }, View_access);
        }

        // DELETE: api/View_access/5
        [EnableCors("AllowSpecificOrigin")]
        [ResponseType(typeof(View_access))]
        public IHttpActionResult DeleteView_access(int id)
        {
            View_access View_access = (View_access)db.GetById("View_access", id);
            if (View_access == null)
            {
                return NotFound();
            }
            var res = db.Inative("View_access", id);

            return Ok(View_access);
        }

        private bool View_accessExists(int id)
        {
            return db.ContainsId("View_access", id);
        }
    }
}