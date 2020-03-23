using SchulBuchWebApp.BusinessLogic;
using SchulBuchWebApp.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using SchulBuchWebApp.CopyItem;

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

        public ActionResult Delete(int ID)
        {
            List<DeleteModel> deleteModels = new List<DeleteModel>();
            deleteModels = BookProcessor.DeleteModels(ID);
            DeleteModel delete = new DeleteModel();
            delete = deleteModels.Find(b => b.ID == ID);
            return RedirectToAction("Cart");
        }

        public ActionResult Cart()
        {
            List<CartItem> cart = new List<CartItem>();
            var items = BookProcessor.GetAll("lamies.abbas");

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

        public ActionResult DisplayBook()
        {
            List<BookModel> books = new List<BookModel>();
            var data = BookProcessor.GetData("lamies.abbas");

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
            List<BookModel> books = new List<BookModel>();
            books = BookProcessor.GetData("lamies.abbas");

            BookModel specialBook = new BookModel();
            specialBook = books.Find(b => b.ID == ID);

            return View(specialBook);
        }
    }
}