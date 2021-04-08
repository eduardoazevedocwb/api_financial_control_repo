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
    public class Cost_centerController : ApiController
    {
        private DataBaseConnection.DataBaseConnection db = new DataBaseConnection.DataBaseConnection();

        // GET: api/Cost_center
        [EnableCors("AllowSpecificOrigin")]
        public IQueryable<Cost_center> GetCost_center()
        {
            var list = db.Get("Cost_center");
            return list.Cast<Cost_center>().AsQueryable();
        }

        // GET: api/Cost_center/5
        [EnableCors("AllowSpecificOrigin")]
        [ResponseType(typeof(Cost_center))]
        public IHttpActionResult GetCost_center(int id)
        {
            Cost_center Cost_center;
            var obj = db.GetById("Cost_center", id);
            if (obj != null)
                Cost_center = (Cost_center)obj;
            else
                return NotFound();

            return Ok(Cost_center);
        }

        // PUT: api/Cost_center/5
        [EnableCors("AllowSpecificOrigin")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCost_center(int id, Cost_center Cost_center)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Cost_center.ID)
            {
                return BadRequest();
            }

            var res = db.SetItem("Cost_center", Cost_center.ID, Entities_Functions.GetInsertString(Cost_center));

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Cost_center
        [EnableCors("AllowSpecificOrigin")]
        [ResponseType(typeof(Cost_center))]
        public IHttpActionResult PostCost_center(Cost_center Cost_center)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var res = db.SetItem("Cost_center", Cost_center.ID, Entities_Functions.GetInsertString(Cost_center));

            return CreatedAtRoute("DefaultApi", new { id = Cost_center.ID }, Cost_center);
        }

        // DELETE: api/Cost_center/5
        [EnableCors("AllowSpecificOrigin")]
        [ResponseType(typeof(Cost_center))]
        public IHttpActionResult DeleteCost_center(int id)
        {
            Cost_center Cost_center = (Cost_center)db.GetById("Cost_center", id);
            if (Cost_center == null)
            {
                return NotFound();
            }
            var res = db.Inative("Cost_center", id);

            return Ok(Cost_center);
        }

        private bool Cost_centerExists(int id)
        {
            return db.ContainsId("Cost_center", id);
        }
    }
}