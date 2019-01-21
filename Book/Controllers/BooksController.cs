using System.Web.Mvc;
using Book.Logic;
using Book.Models;

namespace Book.Controllers
{
    public class BooksController : Controller
    {
        //private CommonDBContext db = new CommonDBContext();

        private BookLogic logic = new BookLogic();

        // GET: Books
        public ActionResult Index(string id)
        {
            //var list = logic.GetBooks(id);
            //return View("~/Views/Shared/Error.cshtml");
            //return View(list);
            return View();
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            BookModel books = logic.GetBookDetail(id);
            if (books == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            return View(books);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,BookName,BookType,BookPrice,IsEable,Created")] BookModel books)
        {
            if (ModelState.IsValid)
            {
                var result = logic.CreateBook(books);
                if (result == null)
                {
                    return View("~/Views/Shared/Error.cshtml");
                }

                return RedirectToAction("Index");
            }

            return View(books);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            BookModel books = logic.GetBookDetail(id);
            if (books == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            return View(books);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,BookName,BookType,BookPrice,IsEable,Created")] BookModel books)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(books).State = EntityState.Modified;
                //db.SaveChanges();
                if (!logic.EditBook(books))
                {
                    return View("~/Views/Shared/Error.cshtml");
                }
                return RedirectToAction("Index");
            }
            return View(books);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            BookModel books = logic.GetBookDetail(id);
            if (books == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            return View(books);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Books books = db.Books.Find(id);
            //db.Books.Remove(books);
            //db.SaveChanges();
            if (!logic.DeleteBook(id))
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
