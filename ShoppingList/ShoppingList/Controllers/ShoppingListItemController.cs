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

        // GET: ShoppingListItem
        public ActionResult Index()
        {

            var list = new List<ShoppingListItem>
            {
                 new ShoppingListItem{ShoppingListItemModelId = 1, Note = "Aquafina", IsChecked = false},
                 new ShoppingListItem{ShoppingListItemModelId = 2, Note = "Mulshi Springs", IsChecked = false},
                 new ShoppingListItem{ShoppingListItemModelId = 3, Note = "Alfa Blue", IsChecked = false},
                 new ShoppingListItem{ShoppingListItemModelId = 4, Note = "Atlas Premium", IsChecked = false},
                 new ShoppingListItem{ShoppingListItemModelId = 5, Note = "Bailley", IsChecked = false},
                 new ShoppingListItem{ShoppingListItemModelId = 6, Note = "Bisleri", IsChecked = false},
                 new ShoppingListItem{ShoppingListItemModelId = 7, Note = "Himalayan", IsChecked = false},
                 new ShoppingListItem{ShoppingListItemModelId = 8, Note = "Cool Valley", IsChecked = false},
                 new ShoppingListItem{ShoppingListItemModelId = 9, Note = "Dew Drops", IsChecked = false},
                 new ShoppingListItem{ShoppingListItemModelId = 10, Note = "Dislaren", IsChecked = false},

            };

            return View(db.ShoppingListItems.ToList());
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

            return View(shoppingListItem);
        }

        // GET: ShoppingListItem/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: ShoppingListItem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShoppingListItemId,ShoppingListId,Content,Priority,Note,IsChecked,CreatedUtc,ModifiedUtc")] ShoppingListItem shoppingListItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shoppingListItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shoppingListItem);
        }

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
