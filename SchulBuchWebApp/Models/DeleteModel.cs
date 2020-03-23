using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchulBuchWebApp.Models
{
    public class DeleteModel
    {
        public int ID { get; set; }
        public int IDtmpWerke { get; set; }
        public int IDWerke { get; set; }
        public string GegStdKurz { get; set; } = "";
        public string GegStdlang { get; set; } = "";
        public int BNR { get; set; }
        public string Kurztitel { get; set; } = "";
        public string Titel { get; set; } = "";
        public int Listtyp { get; set; }
        public int Schulform { get; set; }
        public string Gegenstand { get; set; } = "";
        public string Schulstufe { get; set; } = "";
        public string Lehrerexemplar { get; set; } = "";
        public string Anmerkung { get; set; } = "";
        public int VNR { get; set; }
        public string Verlag { get; set; } = "";
        public string Hauptbuch { get; set; } = "";
        public int Preis { get; set; }
        public int LngGegStd_lokal { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool ausgewählt { get; set; }
        public int lngSchuljahr { get; set; }
        public string Gegenstand_lokalBemerkung { get; set; } = "";
        public string LehrKurz { get; set; } = "";
        public string Zuweisungsgruppen { get; set; } = "";
        public string Klasse { get; set; } = "";
        public int Anzahl_m_F17 { get; set; }
        public int Anzahl_w_F18 { get; set; }
        public int LngIDFinanzUG { get; set; }
        public int Ges_Anzahl { get; set; }
        public string Betrag { get; set; } = "";
        public int IDLehrer { get; set; }
        public string Zuweisungstext { get; set; } = "";
        public int Betrag_pro_Schuel { get; set; }
        public string Pool_Zuordnung { get; set; } = "";
        public bool genehmigt { get; set; }
    }
}