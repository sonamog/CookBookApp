using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using NewCookbook.Models;

namespace NewCookbook.Controllers
{
    [EnableCors("","","*")]
    public class RecipeController : ApiController
    {
        private Cookbook_DBEntities db = new Cookbook_DBEntities();

        // GET: api/Recipe
        public IQueryable<tblRecipe> GettblRecipes()
        {
            return db.tblRecipes;
        }

        // GET: api/Recipe/5
        [ResponseType(typeof(tblRecipe))]
        public IHttpActionResult GettblRecipe(int id)
        {
            tblRecipe tblRecipe = db.tblRecipes.Find(id);
            if (tblRecipe == null)
            {
                return NotFound();
            }

            return Ok(tblRecipe);
        }

        // PUT: api/Recipe/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblRecipe(int id, tblRecipe tblRecipe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblRecipe.Recipe_Id)
            {
                return BadRequest();
            }

            db.Entry(tblRecipe).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblRecipeExists(id))
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

        // POST: api/Recipe
        [ResponseType(typeof(tblRecipe))]
        public IHttpActionResult PosttblRecipe(tblRecipe tblRecipe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblRecipes.Add(tblRecipe);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblRecipe.Recipe_Id }, tblRecipe);
        }

        // DELETE: api/Recipe/5
        [ResponseType(typeof(tblRecipe))]
        public IHttpActionResult DeletetblRecipe(int id)
        {
            tblRecipe tblRecipe = db.tblRecipes.Find(id);
            if (tblRecipe == null)
            {
                return NotFound();
            }

            db.tblRecipes.Remove(tblRecipe);
            db.SaveChanges();

            return Ok(tblRecipe);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblRecipeExists(int id)
        {
            return db.tblRecipes.Count(e => e.Recipe_Id == id) > 0;
        }
    }
}