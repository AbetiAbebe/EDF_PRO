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
    public class PROJECTsController : ApiController
    {
        private ESDprojectEntities db = new ESDprojectEntities();

        // GET: api/PROJECTs
        public IQueryable<PROJECT> GetPROJECT()
        {
            return db.PROJECT;
        }

        // GET: api/PROJECTs/5
        [ResponseType(typeof(PROJECT))]
        public IHttpActionResult GetPROJECT(int id)
        {
            PROJECT pROJECT = db.PROJECT.Find(id);
            if (pROJECT == null)
            {
                return NotFound();
            }

            return Ok(pROJECT);
        }

        // PUT: api/PROJECTs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPROJECT(int id, PROJECT pROJECT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pROJECT.Project_ID)
            {
                return BadRequest();
            }

            db.Entry(pROJECT).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PROJECTExists(id))
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

        // POST: api/PROJECTs
        [ResponseType(typeof(PROJECT))]
        public IHttpActionResult PostPROJECT(PROJECT pROJECT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PROJECT.Add(pROJECT);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PROJECTExists(pROJECT.Project_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pROJECT.Project_ID }, pROJECT);
        }

        // DELETE: api/PROJECTs/5
        [ResponseType(typeof(PROJECT))]
        public IHttpActionResult DeletePROJECT(int id)
        {
            PROJECT pROJECT = db.PROJECT.Find(id);
            if (pROJECT == null)
            {
                return NotFound();
            }

            db.PROJECT.Remove(pROJECT);
            db.SaveChanges();

            return Ok(pROJECT);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PROJECTExists(int id)
        {
            return db.PROJECT.Count(e => e.Project_ID == id) > 0;
        }
    }
}