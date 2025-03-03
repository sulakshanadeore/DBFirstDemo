using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBFirstDemo;
using DBFirstDemo_WebApp.Models;

namespace DBFirstDemo_WebApp.Controllers
{
    public class CategoriesController : Controller
    {
        northwindEntities entities=new northwindEntities();

        // GET: Categories
        public ActionResult Index()
        {

            IEnumerable<Category> catList=entities.Categories;

            List<CategoryModel> list = new List<CategoryModel>();
            foreach (var item in catList)
            {
                CategoryModel c = new CategoryModel();
                c.CategoryID = item.CategoryID;
                c.CategoryName = item.CategoryName;
                c.Description = item.Description;
                c.Picture = item.Picture;
                list.Add(c);

                //list.Add(new CategoryModel { CategoryID = item.CategoryID, CategoryName = item.CategoryName, Description = item.Description, Picture = item.Picture });
            }


            return View(list);
        }

        // GET: Categories/Details/5
        public ActionResult Details(int id)
        {
            Category data = entities.Categories.Find(id);
            CategoryModel model = new CategoryModel();
            model.CategoryID = data.CategoryID;
            model.CategoryName = data.CategoryName;
            model.Description = data.Description;
            model.Picture = data.Picture;
            return View(model);

      
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                CategoryModel model=new CategoryModel();
                model.CategoryName = collection["CategoryName"].ToString();
                model.Description=collection["Description"].ToString();


                Category category = new Category();
                category.CategoryName = model.CategoryName;
               category.Description = model.Description;

                entities.Categories.Add(category);
                entities.SaveChanges(); 


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int id)
        {
            Category data=entities.Categories.Find(id);
            CategoryModel model=new CategoryModel();
            model.CategoryID = data.CategoryID;
            model.CategoryName = data.CategoryName; 
            model.Description = data.Description;   
            model.Picture = data.Picture;
            return View(model);
        }

        // POST: Categories/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Category data = entities.Categories.Find(id);
                data.CategoryID = Convert.ToInt32(collection["CategoryID"]);
                data.CategoryName = collection["CategoryName"].ToString();
                data.Description = collection["Description"].ToString();
                entities.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int id)
        {
            Category data = entities.Categories.Find(id);
            CategoryModel model = new CategoryModel();
            model.CategoryID = data.CategoryID;
            model.CategoryName = data.CategoryName;
            model.Description = data.Description;
            model.Picture = data.Picture;
            return View(model);
            
        }

        // POST: Categories/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Category data = entities.Categories.Find(id);
                entities.Categories.Remove(data);
                entities.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
