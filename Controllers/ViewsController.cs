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
    public class ViewsController : ApiController
    {
        private DataBaseConnection.DataBaseConnection db = new DataBaseConnection.DataBaseConnection();

        // GET: api/View
        [EnableCors("AllowSpecificOrigin")]
        public IQueryable<View> GetView()
        {
            var list = db.Get("[View]");
            return list.Cast<View>().AsQueryable();
        }

        // GET: api/View/5
        [EnableCors("AllowSpecificOrigin")]
        [ResponseType(typeof(View))]
        public IHttpActionResult GetView(int id)
        {
            View View;
            var obj = db.GetById("[View]", id);
            if (obj != null)
                View = (View)obj;
            else
                return NotFound();

            return Ok(View);
        }

        // PUT: api/View/5
        [EnableCors("AllowSpecificOrigin")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutView(int id, View View)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != View.ID)
            {
                return BadRequest();
            }

            var res = db.SetItem("[View]", View.ID, Entities_Functions.GetInsertString(View));

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/View
        [EnableCors("AllowSpecificOrigin")]
        [ResponseType(typeof(View))]
        public IHttpActionResult PostView(View View)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var res = db.SetItem("[View]", View.ID, Entities_Functions.GetInsertString(View));

            return CreatedAtRoute("DefaultApi", new { id = View.ID }, View);
        }

        // DELETE: api/View/5
        [EnableCors("AllowSpecificOrigin")]
        [ResponseType(typeof(View))]
        public IHttpActionResult DeleteView(int id)
        {
            View View = (View)db.GetById("[View]", id);
            if (View == null)
            {
                return NotFound();
            }
            var res = db.Inative("[View]", id);

            return Ok(View);
        }

        private bool ViewExists(int id)
        {
            return db.ContainsId("[View]", id);
        }
    }
}