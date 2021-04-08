using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using api_financial_control_entitiesLibrary;
using DataBaseConnection;
using Microsoft.AspNetCore.Cors;

namespace api_financial_control.Controllers
{
    public class AddressesController : ApiController
    {
        private DataBaseConnection.DataBaseConnection db = new DataBaseConnection.DataBaseConnection();

        // GET: api/Addresses
        [EnableCors("AllowSpecificOrigin")]
        public IQueryable<Address> GetAddresses()
        {
            var list = db.Get("Address");
            return list.Cast<Address>().AsQueryable();
        }

        // GET: api/Addresses/5
        [EnableCors("AllowSpecificOrigin")]
        [ResponseType(typeof(Address))]
        public IHttpActionResult GetAddress(int id)
        {
            Address Address;
            var obj = db.GetById("Address", id);
            if (obj != null)
                Address = (Address)obj;
            else
                return NotFound();

            return Ok(Address);
        }

        // PUT: api/Addresses/5
        [EnableCors("AllowSpecificOrigin")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAddress(int id, Address address)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != address.ID)
            {
                return BadRequest();
            }

            var res = db.SetItem("Address", address.ID, Entities_Functions.GetInsertString(address));

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Addresses
        [EnableCors("AllowSpecificOrigin")]
        [ResponseType(typeof(Address))]
        public IHttpActionResult PostAddress(Address address)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var res = db.SetItem("Address",address.ID, Entities_Functions.GetInsertString(address));

            return CreatedAtRoute("DefaultApi", new { id = address.ID }, address);
        }

        // DELETE: api/Addresses/5
        [EnableCors("AllowSpecificOrigin")]
        [ResponseType(typeof(Address))]
        public IHttpActionResult DeleteAddress(int id)
        {
            Address address = (Address)db.GetById("Address",id);
            if (address == null)
            {
                return NotFound();
            }
            var res = db.Inative("Address", id);

            return Ok(address);
        }

        private bool AddressExists(int id)
        {
            return db.ContainsId("Address", id);
        }
    }
}