using ShoppingList.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ShoppingList.Controllers
{
    public class ShoppingListItemController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ShoppingListItemModel
        public ActionResult Index()
        {
            return View(db.ShoppingListItems.ToList());
        }

        // GET: ShoppingListItemModel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingListItem shoppingListItemModel = db.ShoppingListItems.Find(id);
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
        [Route("/ShoppingList/details/{id:int}/CreateItem")]
        public ActionResult Create(
            [Bind(Include = "Content,Priority,Note,IsChecked,CreatedUtc,ModifiedUtc")]
                ShoppingListItem shoppingListItemModel, 
            int id)
        {
            if (ModelState.IsValid)
            {
                shoppingListItemModel.ShoppingListId = id;
                db.ShoppingListItems.Add(shoppingListItemModel);
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
            ShoppingListItem shoppingListItemModel = db.ShoppingListItems.Find(id);
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
        public ActionResult Edit([Bind(Include = "ShoppingListItemModelId,ShoppingListId,Content,Priority,Note,IsChecked,CreatedUtc,ModifiedUtc")] ShoppingListItem shoppingListItemModel)
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
            ShoppingListItem shoppingListItemModel = db.ShoppingListItems.Find(id);
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
            ShoppingListItem shoppingListItemModel = db.ShoppingListItems.Find(id);
            db.ShoppingListItems.Remove(shoppingListItemModel);
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
