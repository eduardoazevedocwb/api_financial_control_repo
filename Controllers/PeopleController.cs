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
    public class PeopleController : ApiController
    {
        private DataBaseConnection.DataBaseConnection db = new DataBaseConnection.DataBaseConnection();

        // GET: api/Person
        [EnableCors("AllowSpecificOrigin")]
        public IQueryable<Person> GetPerson()
        {
            var list = db.Get("Person");
            return list.Cast<Person>().AsQueryable();
        }

        // GET: api/Person/5
        [EnableCors("AllowSpecificOrigin")]
        [ResponseType(typeof(Person))]
        public IHttpActionResult GetPerson(int id)
        {
            Person Person;
            var obj = db.GetById("Person", id);
            if (obj != null)
                Person = (Person)obj;
            else
                return NotFound();

            return Ok(Person);
        }

        // PUT: api/Person/5
        [EnableCors("AllowSpecificOrigin")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPerson(int id, Person Person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Person.ID)
            {
                return BadRequest();
            }

            var res = db.SetItem("Person",Person.ID, Entities_Functions.GetInsertString(Person));

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Person
        [EnableCors("AllowSpecificOrigin")]
        [ResponseType(typeof(Person))]
        public IHttpActionResult PostPerson(Person Person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var res = db.SetItem("Person", Person.ID, Entities_Functions.GetInsertString(Person));

            return CreatedAtRoute("DefaultApi", new { id = Person.ID }, Person);
        }

        // DELETE: api/Person/5
        [EnableCors("AllowSpecificOrigin")]
        [ResponseType(typeof(Person))]
        public IHttpActionResult DeletePerson(int id)
        {
            Person Person = (Person)db.GetById("Person", id);
            if (Person == null)
            {
                return NotFound();
            }
            var res = db.Inative("Person", id);

            return Ok(Person);
        }

        private bool PersonExists(int id)
        {
            return db.ContainsId("Person", id);
        }
    }
}