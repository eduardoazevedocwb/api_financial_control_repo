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
    public class ContactsController : ApiController
    {
        private DataBaseConnection.DataBaseConnection db = new DataBaseConnection.DataBaseConnection();

        // GET: api/Contact
        [EnableCors("AllowSpecificOrigin")]
        public IQueryable<Contact> GetContact()
        {
            var list = db.Get("Contact");
            return list.Cast<Contact>().AsQueryable();
        }

        // GET: api/Contact/5
        [EnableCors("AllowSpecificOrigin")]
        [ResponseType(typeof(Contact))]
        public IHttpActionResult GetContact(int id)
        {
            Contact Contact;
            var obj = db.GetById("Contact", id);
            if (obj != null)
                Contact = (Contact)obj;
            else
                return NotFound();

            return Ok(Contact);
        }

        // PUT: api/Contact/5
        [EnableCors("AllowSpecificOrigin")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutContact(int id, Contact Contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Contact.ID)
            {
                return BadRequest();
            }

            var res = db.SetItem("Contact", Contact.ID, Entities_Functions.GetInsertString(Contact));

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Contact
        [EnableCors("AllowSpecificOrigin")]
        [ResponseType(typeof(Contact))]
        public IHttpActionResult PostContact(Contact Contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var res = db.SetItem("Contact", Contact.ID, Entities_Functions.GetInsertString(Contact));

            return CreatedAtRoute("DefaultApi", new { id = Contact.ID }, Contact);
        }

        // DELETE: api/Contact/5
        [EnableCors("AllowSpecificOrigin")]
        [ResponseType(typeof(Contact))]
        public IHttpActionResult DeleteContact(int id)
        {
            Contact Contact = (Contact)db.GetById("Contact", id);
            if (Contact == null)
            {
                return NotFound();
            }
            var res = db.Inative("Contact", id);

            return Ok(Contact);
        }

        private bool ContactExists(int id)
        {
            return db.ContainsId("Contact", id);
        }
    }
}