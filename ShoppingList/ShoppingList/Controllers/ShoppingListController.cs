using ShoppingList.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ShoppingList.Controllers
{
    public class ShoppingListController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ShoppingListModel
        public ActionResult Index()
        {
            return View(db.ShoppingLists.ToList());
        }

        // GET: ShoppingListModel/Details/5
        public ActionResult Details(int? id)
        {

            //replace with shoppinglistitem index
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.ShoppingList shoppingListModel = db.ShoppingLists.Find(id);
            if (shoppingListModel == null)
            {
                return HttpNotFound();
            }

            //var i = new ShoppingListItem {ShoppingListId = id.Value};
            return View(shoppingListModel);
        }

        //adding ViewIndex to ShoppingListController

        public ActionResult ViewIndex(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Models.ShoppingList shoppingListIndex = db.ShoppingLists.Find(id);
            if (shoppingListIndex == null)
            {
                return HttpNotFound();
            }
            
            return View(db.ShoppingListItems.ToList());
        }



        // GET: ShoppingListModel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShoppingListModel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShoppingListId,UserId,Name,Color,CreatedUtc,ModifiedUtc")] Models.ShoppingList shoppingListModel)
        {
            if (ModelState.IsValid)
            {
                db.ShoppingLists.Add(shoppingListModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shoppingListModel);
        }

        //copy and paste both create methods from shoppinglistitem to create a list item

        // GET: ShoppingListModel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.ShoppingList shoppingListModel = db.ShoppingLists.Find(id);
            if (shoppingListModel == null)
            {
                return HttpNotFound();
            }
            return View(shoppingListModel);
        }

        // POST: ShoppingListModel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShoppingListId,UserId,Name,Color,CreatedUtc,ModifiedUtc")] Models.ShoppingList shoppingListModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shoppingListModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shoppingListModel);
        }

        // GET: ShoppingListModel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.ShoppingList shoppingListModel = db.ShoppingLists.Find(id);
            if (shoppingListModel == null)
            {
                return HttpNotFound();
            }
            return View(shoppingListModel);
        }

        // POST: ShoppingListModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Models.ShoppingList shoppingListModel = db.ShoppingLists.Find(id);
            db.ShoppingLists.Remove(shoppingListModel);
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
