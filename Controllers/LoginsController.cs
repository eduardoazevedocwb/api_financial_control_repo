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
    public class LoginsController : ApiController
    {
        private DataBaseConnection.DataBaseConnection db = new DataBaseConnection.DataBaseConnection();

        // GET: api/Login
        [EnableCors("AllowSpecificOrigin")]
        public IQueryable<Login> GetLogin()
        {
            var list = db.Get("Login");
            return list.Cast<Login>().AsQueryable();
        }

        // GET: api/Login/5
        [EnableCors("AllowSpecificOrigin")]
        [ResponseType(typeof(Login))]
        public IHttpActionResult GetLogin(int id)
        {
            Login Login;
            var obj = db.GetById("Login", id);
            if (obj != null)
                Login = (Login)obj;
            else
                return NotFound();

            return Ok(Login);
        }

        // PUT: api/Login/5
        [EnableCors("AllowSpecificOrigin")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLogin(int id, Login Login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Login.ID)
            {
                return BadRequest();
            }

            var res = db.SetItem("Login", Login.ID, Entities_Functions.GetInsertString(Login));

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Login
        [EnableCors("AllowSpecificOrigin")]
        [ResponseType(typeof(Login))]
        public IHttpActionResult PostLogin(Login Login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var res = db.SetItem("Login", Login.ID, Entities_Functions.GetInsertString(Login));

            return CreatedAtRoute("DefaultApi", new { id = Login.ID }, Login);
        }

        // DELETE: api/Login/5
        [EnableCors("AllowSpecificOrigin")]
        [ResponseType(typeof(Login))]
        public IHttpActionResult DeleteLogin(int id)
        {
            Login Login = (Login)db.GetById("Login", id);
            if (Login == null)
            {
                return NotFound();
            }
            var res = db.Inative("Login", id);

            return Ok(Login);
        }

        private bool LoginExists(int id)
        {
            return db.ContainsId("Login", id);
        }
    }
}