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
    public class CompaniesController : ApiController
    {
        private DataBaseConnection.DataBaseConnection db = new DataBaseConnection.DataBaseConnection();

        // GET: api/Company
        [EnableCors("AllowSpecificOrigin")]
        public IQueryable<Company> GetCompany()
        {
            var list = db.Get("Company");
            return list.Cast<Company>().AsQueryable();
        }

        // GET: api/Company/5
        [EnableCors("AllowSpecificOrigin")]
        [ResponseType(typeof(Company))]
        public IHttpActionResult GetCompany(int id)
        {
            Company Company;
            var obj = db.GetById("Company", id);
            if (obj != null)
                Company = (Company)obj;
            else
                return NotFound();

            return Ok(Company);
        }

        // PUT: api/Company/5
        [EnableCors("AllowSpecificOrigin")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCompany(int id, Company Company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Company.ID)
            {
                return BadRequest();
            }

            var res = db.SetItem("Company", Company.ID, Entities_Functions.GetInsertString(Company));

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Company
        [EnableCors("AllowSpecificOrigin")]
        [ResponseType(typeof(Company))]
        public IHttpActionResult PostCompany(Company Company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            } 

            var res = db.SetItem("Company", Company.ID, Entities_Functions.GetInsertString(Company));

            return CreatedAtRoute("DefaultApi", new { id = Company.ID }, Company);
        }

        // DELETE: api/Company/5
        [EnableCors("AllowSpecificOrigin")]
        [ResponseType(typeof(Company))]
        public IHttpActionResult DeleteCompany(int id)
        {
            Company Company = (Company)db.GetById("Company", id);
            if (Company == null)
            {
                return NotFound();
            }
            var res = db.Inative("Company", id);

            return Ok(Company);
        }

        private bool CompanyExists(int id)
        {
            return db.ContainsId("Company", id);
        }
    }
}