using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShoppingList.Models;

namespace ShoppingList.Controllers
{
    public class ShoppingListItemModelController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ShoppingListItemModel
        public ActionResult Index()
        {
            return View(db.ShoppingListItemModels.ToList());
        }

        // GET: ShoppingListItemModel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingListItemModel shoppingListItemModel = db.ShoppingListItemModels.Find(id);
            if (shoppingListItemModel == null)
            {
                return HttpNotFound();
            }
            return View(shoppingListItemModel);
        }

        // GET: ShoppingListItemModel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShoppingListItemModel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShoppingListItemModelId,ShoppingListId,Content,Note,IsChecked,CreatedUtc,ModifiedUtc")] ShoppingListItemModel shoppingListItemModel)
        {
            if (ModelState.IsValid)
            {
                db.ShoppingListItemModels.Add(shoppingListItemModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shoppingListItemModel);
        }

        // GET: ShoppingListItemModel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingListItemModel shoppingListItemModel = db.ShoppingListItemModels.Find(id);
            if (shoppingListItemModel == null)
            {
                return HttpNotFound();
            }
            return View(shoppingListItemModel);
        }

        // POST: ShoppingListItemModel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShoppingListItemModelId,ShoppingListId,Content,Note,IsChecked,CreatedUtc,ModifiedUtc")] ShoppingListItemModel shoppingListItemModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shoppingListItemModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shoppingListItemModel);
        }

        // GET: ShoppingListItemModel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingListItemModel shoppingListItemModel = db.ShoppingListItemModels.Find(id);
            if (shoppingListItemModel == null)
            {
                return HttpNotFound();
            }
            return View(shoppingListItemModel);
        }

        // POST: ShoppingListItemModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShoppingListItemModel shoppingListItemModel = db.ShoppingListItemModels.Find(id);
            db.ShoppingListItemModels.Remove(shoppingListItemModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
