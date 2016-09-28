using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShoppingList.Models;
using System.Data.Entity.Infrastructure;

namespace ShoppingList.Controllers
{
    public class ShoppingListItemController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ShoppingListItem
        public ActionResult Index()
        {
            var shoppingListItems = db.ShoppingListItems.Include(s => s.ShoppingList);
            return View(shoppingListItems.ToList());
        }

        // GET: ShoppingListItem/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingListItem shoppingListItem = db.ShoppingListItems.Find(id);
            if (shoppingListItem == null)
            {
                return HttpNotFound();
            }
            return View(shoppingListItem);
        }

        // GET: ShoppingListItem/Create
        public ActionResult Create()
        {
            ViewBag.ShoppingListId = new SelectList(db.ShoppingLists, "ShoppingListId", "Name");
            return View();
        }

        // POST: ShoppingListItem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShoppingListItemId,ShoppingListId,Content,Priority,Note,IsChecked,CreatedUtc,ModifiedUtc")] ShoppingListItem shoppingListItem)
        {
            if (ModelState.IsValid)
            {
                db.ShoppingListItems.Add(shoppingListItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ShoppingListId = new SelectList(db.ShoppingLists, "ShoppingListId", "Name", shoppingListItem.ShoppingListId);
            return View(shoppingListItem);
        }

        // GET: ShoppingListItem/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //ShoppingListItem shoppingListItem = db.ShoppingListItems.Find(id);
            ShoppingListItem shoppingListItem = db.ShoppingListItems.Include(s => s.Files).SingleOrDefault(s => s.ShoppingListItemId == id);
            if (shoppingListItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.ShoppingListId = new SelectList(db.ShoppingLists, "ShoppingListId", "Name", shoppingListItem.ShoppingListId);
            return View(shoppingListItem);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id, HttpPostedFileBase upload)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var itemToUpdate = db.ShoppingListItems.Find(id);
            if(TryUpdateModel(itemToUpdate, "", new string[] { "Content", "Priority", "Note" }))
            {
                try
                {
                    if (upload != null && upload.ContentLength > 0)
                    {
                        if (itemToUpdate.Files.Any(f => f.FileType == FileType.Photo))
                        {
                            db.Files.Remove(itemToUpdate.Files.First(f => f.FileType == FileType.Photo));
                        }
                        var photo = new File
                        {
                            FileName = System.IO.Path.GetFileName(upload.FileName),
                            FileType = FileType.Photo,
                            ContentType = upload.ContentType
                        };
                        using(var reader = new System.IO.BinaryReader(upload.InputStream))
                        {
                            photo.Content = reader.ReadBytes(upload.ContentLength);
                        }
                        itemToUpdate.Files = new List<File> { photo };
                    }
                    db.Entry(itemToUpdate).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("ViewItem", "ShoppingList", new { id = itemToUpdate.ShoppingListId });
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    // Log the error (uncomment dex variable name and add a line here to write a log).
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(itemToUpdate);
        }

        // POST: ShoppingListItem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ShoppingListItemId,ShoppingListId,Content,Priority,Note,IsChecked,CreatedUtc,ModifiedUtc")] ShoppingListItem shoppingListItem)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(shoppingListItem).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.ShoppingListId = new SelectList(db.ShoppingLists, "ShoppingListId", "Name", shoppingListItem.ShoppingListId);
        //    return View(shoppingListItem);
        //}

        // GET: ShoppingListItem/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingListItem shoppingListItem = db.ShoppingListItems.Find(id);
            if (shoppingListItem == null)
            {
                return HttpNotFound();
            }
            return View(shoppingListItem);
        }

        // POST: ShoppingListItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShoppingListItem shoppingListItem = db.ShoppingListItems.Find(id);
            db.ShoppingListItems.Remove(shoppingListItem);
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
