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
    public class ApplicationsController : ApiController
    {
        private DataBaseConnection.DataBaseConnection db = new DataBaseConnection.DataBaseConnection();

        // GET: api/Application
        [EnableCors("AllowSpecificOrigin")]
        public IQueryable<Application> GetApplication()
        {
            var list = db.Get("Application");
            return list.Cast<Application>().AsQueryable();
        }

        // GET: api/Application/5
        [EnableCors("AllowSpecificOrigin")]
        [ResponseType(typeof(Application))]
        public IHttpActionResult GetApplication(int id)
        {
            Application Application;
            var obj = db.GetById("Application", id);
            if (obj != null)
                Application = (Application)obj;
            else
                return NotFound();

            return Ok(Application);

        }

        // PUT: api/Application/5
        [EnableCors("AllowSpecificOrigin")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutApplication(int id, Application Application)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Application.ID)
            {
                return BadRequest();
            }

            var res = db.SetItem("Application",Application.ID, Entities_Functions.GetInsertString(Application));

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Application
        [EnableCors("AllowSpecificOrigin")]
        [ResponseType(typeof(Application))]
        public IHttpActionResult PostApplication(Application Application)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var res = db.SetItem("Application", Application.ID, Entities_Functions.GetInsertString(Application));

            return CreatedAtRoute("DefaultApi", new { id = Application.ID }, Application);
        }

        // DELETE: api/Application/5
        [EnableCors("AllowSpecificOrigin")]
        [ResponseType(typeof(Application))]
        public IHttpActionResult DeleteApplication(int id)
        {
            Application Application = (Application)db.GetById("Application", id);
            if (Application == null)
            {
                return NotFound();
            }
            var res = db.Inative("Application", id);

            return Ok(Application);
        }

        private bool ApplicationExists(int id)
        {
            return db.ContainsId("Application", id);
        }
    }
}