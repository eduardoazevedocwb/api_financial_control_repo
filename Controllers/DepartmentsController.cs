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
    public class DepartmentsController : ApiController
    {
        private DataBaseConnection.DataBaseConnection db = new DataBaseConnection.DataBaseConnection();

        // GET: api/Department
        [EnableCors("AllowSpecificOrigin")]
        public IQueryable<Department> GetDepartment()
        {
            var list = db.Get("Department");
            return list.Cast<Department>().AsQueryable();
        }

        // GET: api/Department/5
        [EnableCors("AllowSpecificOrigin")]
        [ResponseType(typeof(Department))]
        public IHttpActionResult GetDepartment(int id)
        {
            Department Department;
            var obj = db.GetById("Department", id);
            if (obj != null)
                Department = (Department)obj;
            else
                return NotFound();

            return Ok(Department);
        }

        // PUT: api/Department/5
        [EnableCors("AllowSpecificOrigin")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDepartment(int id, Department Department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Department.ID)
            {
                return BadRequest();
            }

            var res = db.SetItem("Department", Department.ID, Entities_Functions.GetInsertString(Department));

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Department
        [EnableCors("AllowSpecificOrigin")]
        [ResponseType(typeof(Department))]
        public IHttpActionResult PostDepartment(Department Department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var res = db.SetItem("Department", Department.ID,Entities_Functions.GetInsertString(Department));

            return CreatedAtRoute("DefaultApi", new { id = Department.ID }, Department);
        }

        // DELETE: api/Department/5
        [EnableCors("AllowSpecificOrigin")]
        [ResponseType(typeof(Department))]
        public IHttpActionResult DeleteDepartment(int id)
        {
            Department Department = (Department)db.GetById("Department", id);
            if (Department == null)
            {
                return NotFound();
            }
            var res = db.Inative("Department", id);

            return Ok(Department);
        }

        private bool DepartmentExists(int id)
        {
            return db.ContainsId("Department", id);
        }
    }
}