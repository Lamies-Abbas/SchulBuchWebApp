using SchulBuchWebApp.CopyItem;
using SchulBuchWebApp.DataAccess;
using SchulBuchWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchulBuchWebApp.BusinessLogic
{
    public static class BookProcessor
    {
        public static List<BookModel> GetData(string userName)
        {
            string sql = "SELECT ID, GegStdKurz, Klasse, Kurztitel, Verlag, Preis, LehrKurz " +
                        "FROM Bestellungen_Werke_Webvorlage " +
                        "WHERE LehrKurz = '" + userName.ToString() + "';";


            return MDBDataAccess.LoadData<BookModel>(sql);

        }
    public static int DeleteBook(int id)
        {
            string sql = "DELETE FROM Bestellungen_Werke_Webtabelle " +
                         "WHERE ID=" + id + ";";
            return MDBDataAccess.DeleteData(sql);
        }

        public static List<CartItem> GetAll(string userName)
        {
            string sql = "SELECT ID, GegStdKurz, Klasse, Kurztitel, Verlag, Preis, LehrKurz " +
                "FROM Bestellungen_Werke_Webtabelle " +
                 "WHERE LehrKurz = '" + userName.ToString() + "';";
            return MDBDataAccess.LoadData<CartItem>(sql);
        }

    }
}