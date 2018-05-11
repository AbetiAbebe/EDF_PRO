using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class TASKSController : ApiController
    {
        private ESDprojectEntities db = new ESDprojectEntities();

        // GET: api/TASKS
        public IQueryable<TASKS> GetTASKS()
        {
            return db.TASKS;
        }

        // GET: api/TASKS/5
        [ResponseType(typeof(TASKS))]
        public IHttpActionResult GetTASKS(int id)
        {
            TASKS tASKS = db.TASKS.Find(id);
            if (tASKS == null)
            {
                return NotFound();
            }

            return Ok(tASKS);
        }

        // PUT: api/TASKS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTASKS(int id, TASKS tASKS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tASKS.Project_ID)
            {
                return BadRequest();
            }

            db.Entry(tASKS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TASKSExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/TASKS
        [ResponseType(typeof(TASKS))]
        public IHttpActionResult PostTASKS(TASKS tASKS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TASKS.Add(tASKS);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TASKSExists(tASKS.Project_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tASKS.Project_ID }, tASKS);
        }

        // DELETE: api/TASKS/5
        [ResponseType(typeof(TASKS))]
        public IHttpActionResult DeleteTASKS(int id)
        {
            TASKS tASKS = db.TASKS.Find(id);
            if (tASKS == null)
            {
                return NotFound();
            }

            db.TASKS.Remove(tASKS);
            db.SaveChanges();

            return Ok(tASKS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TASKSExists(int id)
        {
            return db.TASKS.Count(e => e.Project_ID == id) > 0;
        }
    }
}