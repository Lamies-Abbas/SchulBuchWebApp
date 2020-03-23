using SchulBuchWebApp.DataAccess;
using SchulBuchWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace SchulBuchWebApp.CopyItem
{
    public static class CopyBook
    {
        public static int CopyBooks(int id)
        {
            
            int rows = 0;
                

            string sqlLoad = @"SELECT * FROM Bestellungen_Werke_Webvorlage WHERE ID = " + id.ToString() + ";";
            List<DataModel> booksLoaded = MDBDataAccess.LoadData<DataModel>(sqlLoad);

            
            DataModel book = booksLoaded.FirstOrDefault();

            
            string sqlWrite = @"INSERT INTO [Bestellungen_Werke_Webtabelle] ([ID], [IDtmpWerke], [IDWerke], [GegStdKurz], [GegStdlang], [BNR], [Kurztitel], [Titel], [Listtyp], [Schulform], [Gegenstand], [Schulstufe], [Lehrerexemplar], [Anmerkung], [VNR], [Verlag], [Hauptbuch], [Preis], [LngGegStd_lokal], [TimeStamp], [ausgewählt], [lngSchuljahr], [Gegenstand_lokalBemerkung], [LehrKurz], [Zuweisungsgruppen], [Klasse], [Anzahl_m_F17], [Anzahl_w_F18], [LngIDFinanzUG], [Ges_Anzahl], [Betrag], [IDLehrer], [Zuweisungstext], [Betrag_pro_Schuel], [Pool_Zuordnung], [genehmigt]) VALUES(@ID, @IDtmpWerke, @IDWerke, @GegStdKurz, @GegStdlang, @BNR, @Kurztitel, @Titel, @Listtyp, @Schulform, @Gegenstand, @Schulstufe, @Lehrerexemplar, @Anmerkung, @VNR, @Verlag, @Hauptbuch, @Preis, @LngGegStd_lokal, @TimeStamp, @ausgewählt, @lngSchuljahr, @Gegenstand_lokalBemerkung, @LehrKurz, @Zuweisungsgruppen, @Klasse, @Anzahl_m_F17, @Anzahl_w_F18, @LngIDFinanzUG, @Ges_Anzahl, @Betrag, @IDLehrer, @Zuweisungstext, @Betrag_pro_Schuel, @Pool_Zuordnung, @genehmigt);";

            using (OleDbConnection cnn = new OleDbConnection(MDBDataAccess.GetConnectionString()))
            {
                OleDbCommand command = new OleDbCommand
                {
                    CommandType = CommandType.Text,
                    CommandText = sqlWrite
                };
                command.Parameters.AddWithValue("@ID", book.ID);
                command.Parameters.AddWithValue("@IDtmpWerke", book.IDtmpWerke);
                command.Parameters.AddWithValue("@IDWerke", book.IDWerke);
                command.Parameters.AddWithValue("@GegStdKurz", book.GegStdKurz);
                command.Parameters.AddWithValue("@GegStdlang", book.GegStdlang);
                command.Parameters.AddWithValue("@BNR", book.BNR);
                command.Parameters.AddWithValue("@Kurztitel", book.Kurztitel);
                command.Parameters.AddWithValue("@Titel", book.Titel);
                command.Parameters.AddWithValue("@Listtyp", book.Listtyp);
                command.Parameters.AddWithValue("@Schulform", book.Schulform);
                command.Parameters.AddWithValue("@Gegenstand", book.Gegenstand);
                command.Parameters.AddWithValue("@Schulstufe", book.Schulstufe);
                command.Parameters.AddWithValue("@Lehrerexemplar", book.Lehrerexemplar);
                command.Parameters.AddWithValue("@Anmerkung", book.Anmerkung);
                command.Parameters.AddWithValue("@VNR", book.VNR);
                command.Parameters.AddWithValue("@Verlag", book.Verlag);
                command.Parameters.AddWithValue("@Hauptbuch", book.Hauptbuch);
                command.Parameters.AddWithValue("@Preis", book.Preis);
                command.Parameters.AddWithValue("@LngGegStd_lokal", book.LngGegStd_lokal);
                command.Parameters.AddWithValue("@TimeStamp", book.TimeStamp.ToString());
                command.Parameters.AddWithValue("@ausgewählt", book.ausgewählt);
                command.Parameters.AddWithValue("@lngSchuljahr", book.lngSchuljahr);
                command.Parameters.AddWithValue("@Gegenstand_lokalBemerkung", book.Gegenstand_lokalBemerkung);
                command.Parameters.AddWithValue("@LehrKurz", book.LehrKurz);
                command.Parameters.AddWithValue("@Zuweisungsgruppen", book.Zuweisungsgruppen);
                command.Parameters.AddWithValue("@Klasse", book.Klasse);
                command.Parameters.AddWithValue("@Anzahl_m_F17", book.Anzahl_m_F17);
                command.Parameters.AddWithValue("@Anzahl_w_F18", book.Anzahl_w_F18);
                command.Parameters.AddWithValue("@LngIDFinanzUG", book.LngIDFinanzUG);
                command.Parameters.AddWithValue("@Ges_Anzahl", book.Ges_Anzahl);
                command.Parameters.AddWithValue("@Betrag", book.Betrag);
                command.Parameters.AddWithValue("@IDLehrer", book.IDLehrer);
                command.Parameters.AddWithValue("@Zuweisungstext", book.Zuweisungstext);
                command.Parameters.AddWithValue("@Betrag_pro_Schuel", book.Betrag_pro_Schuel);
                command.Parameters.AddWithValue("@Pool_Zuordnung", book.Pool_Zuordnung);
                command.Parameters.AddWithValue("@genehmigt", book.genehmigt);
                command.Connection = cnn;
                cnn.Open();
                try
                {
                    rows = command.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    rows = 0;
                    
                }
                finally
                {
                    cnn.Close();
                    command.Dispose();
                }
            }
            return rows;
        }
    }
}