using SchulBuchWebApp.BusinessLogic;
using SchulBuchWebApp.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using SchulBuchWebApp.CopyItem;
using SchulBuchWebApp.DataAccess;

namespace SchulBuchWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("DisplayBook");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult Confirm(int id)
        {
            CopyBook.CopyBooks(id);

            /*string message = "Do you want to add this book?";
             string title = "Message";
             MessageBoxButtons buttons = MessageBoxButtons.YesNo;
             DialogResult result = MessageBox.Show(message, title, buttons);
             if (result == DialogResult.Yes)
             {
                 CopyItem.CopyBook.CopyBooks(id);
                 if (MessageBox.Show("This book has been added to your list! Do you want to check your list?", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
                 {
                     return new RedirectResult("MyBooks");
                 }
                 else
                 {
                     return new RedirectResult("DisplayBook");
                 }
             }
             else
             {
                 return new RedirectResult("DisplayBook");
             }*/
            return RedirectToAction("Cart");
        }

        public ActionResult Delete(int id)
        {
            int booksDeleted = BookProcessor.DeleteBook(id);
            return RedirectToAction("Cart");
        }

        public ActionResult Cart()
        {
            string userName = User.Identity.Name.Substring(0, User.Identity.Name.IndexOf("@")).ToLower();
            List<CartItem> cart = new List<CartItem>();
            var items = BookProcessor.GetAll(userName);

            foreach (CartItem row in items)
            {
                cart.Add(new CartItem
                {
                    ID = row.ID,
                    GegStdKurz = row.GegStdKurz,
                    Klasse = row.Klasse,
                    Kurztitel = row.Kurztitel,
                    Verlag = row.Verlag,
                    Preis = row.Preis,
                    LehrKurz = row.LehrKurz
                });
             }
                    return View(cart);

         }
        [Authorize]
        public ActionResult DisplayBook()
        {
            string userName = User.Identity.Name.Substring(0, User.Identity.Name.IndexOf("@")).ToLower();
            List<BookModel> books = new List<BookModel>();
            var data = BookProcessor.GetData(userName);

            foreach (BookModel row in data)
            {
                books.Add(new BookModel
                {
                    ID = row.ID,
                    GegStdKurz = row.GegStdKurz,
                    Klasse = row.Klasse,
                    Kurztitel = row.Kurztitel,
                    Verlag = row.Verlag,
                    Preis = row.Preis,
                    LehrKurz = row.LehrKurz
                });
            }
            return View(books);
        }

        public ActionResult Details(int ID)
        {
            string userName = User.Identity.Name.Substring(0, User.Identity.Name.IndexOf("@")).ToLower();
            List<BookModel> books = new List<BookModel>();
            books = BookProcessor.GetData(userName);

            BookModel specialBook = new BookModel();
            specialBook = books.Find(b => b.ID == ID);

            return View(specialBook);
        }
    }
}