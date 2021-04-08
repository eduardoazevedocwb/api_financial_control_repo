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
    public class Secret_questionController : ApiController
    {
        private DataBaseConnection.DataBaseConnection db = new DataBaseConnection.DataBaseConnection();

        // GET: api/Secret_question
        [EnableCors("AllowSpecificOrigin")]
        public IQueryable<Secret_question> GetSecret_question()
        {
            var list = db.Get("Secret_question");
            return list.Cast<Secret_question>().AsQueryable();
        }

        // GET: api/Secret_question/5
        [EnableCors("AllowSpecificOrigin")]
        [ResponseType(typeof(Secret_question))]
        public IHttpActionResult GetSecret_question(int id)
        {
            Secret_question Secret_question;
            var obj = db.GetById("Secret_question", id);
            if (obj != null)
                Secret_question = (Secret_question)obj;
            else
                return NotFound();

            return Ok(Secret_question);
        }

        // PUT: api/Secret_question/5
        [EnableCors("AllowSpecificOrigin")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSecret_question(int id, Secret_question Secret_question)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Secret_question.ID)
            {
                return BadRequest();
            }

            var res = db.SetItem("Secret_question", Secret_question.ID, Entities_Functions.GetInsertString(Secret_question));

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Secret_question
        [EnableCors("AllowSpecificOrigin")]
        [ResponseType(typeof(Secret_question))]
        public IHttpActionResult PostSecret_question(Secret_question Secret_question)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var res = db.SetItem("Secret_question", Secret_question.ID ,Entities_Functions.GetInsertString(Secret_question));

            return CreatedAtRoute("DefaultApi", new { id = Secret_question.ID }, Secret_question);
        }

        // DELETE: api/Secret_question/5
        [EnableCors("AllowSpecificOrigin")]
        [ResponseType(typeof(Secret_question))]
        public IHttpActionResult DeleteSecret_question(int id)
        {
            Secret_question Secret_question = (Secret_question)db.GetById("Secret_question", id);
            if (Secret_question == null)
            {
                return NotFound();
            }
            var res = db.Inative("Secret_question", id);

            return Ok(Secret_question);
        }

        private bool Secret_questionExists(int id)
        {
            return db.ContainsId("Secret_question", id);
        }
    }
}