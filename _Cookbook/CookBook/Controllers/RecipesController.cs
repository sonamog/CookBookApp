using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Web.Script.Serialization;
using DataAccess.Entity;

namespace CookBook.Controllers
{
    public class RecipesController : ApiController
    {
        private Cookbook_DBEntities db = new Cookbook_DBEntities();

        // GET: api/Recipes
        public IQueryable<tblRecipe> GettblRecipes()
        {
            return db.tblRecipes;
        }

        // GET: api/Recipes/5
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
    

        // PUT: api/Recipes/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult Put(int id, tblRecipe tblRecipe)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != tblRecipe.Recipe_Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(tblRecipe).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!tblRecipeExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST (use to create and update): api/Recipes
        [ResponseType(typeof(tblRecipe))]
        public IHttpActionResult Post(string recipe)
        {            
            JavaScriptSerializer js = new JavaScriptSerializer();
            var newRecipe = js.Deserialize<tblRecipe>(recipe);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var findRecipe = db.tblRecipes.Find(newRecipe.Recipe_Id);

            if(findRecipe == null)
            {
                //Recipe does not exit : ADD
                db.tblRecipes.Add(newRecipe);
                db.SaveChanges();
                return CreatedAtRoute("DefaultApi", new { id = newRecipe.Recipe_Id }, newRecipe);
            }
            else
            {
                //Recipe exist : Update
                findRecipe.Recipe_name = string.IsNullOrWhiteSpace(newRecipe.Recipe_name) ?
                                            findRecipe.Recipe_name :
                                            newRecipe.Recipe_name;
                findRecipe.Recipe_Description = string.IsNullOrWhiteSpace(newRecipe.Recipe_Description) ?
                                            findRecipe.Recipe_Description :
                                            newRecipe.Recipe_Description;
                findRecipe.Recipe_Date = newRecipe.Recipe_Date == null ?
                                            findRecipe.Recipe_Date :
                                            newRecipe.Recipe_Date;
                findRecipe.Recipe_Category= string.IsNullOrWhiteSpace(newRecipe.Recipe_Category) ?
                                            findRecipe.Recipe_Category :
                                            newRecipe.Recipe_Category;
                db.SaveChanges();
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        // DELETE: api/Recipes/5
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

        public bool TblRecipeExists(int id)
        {
            return db.tblRecipes.Count(e => e.Recipe_Id == id) > 0;
        }
    }
}