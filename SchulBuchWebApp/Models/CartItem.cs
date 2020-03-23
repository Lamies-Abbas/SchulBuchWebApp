using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchulBuchWebApp.Models
{
    public class CartItem
    {
        public int ID { get; set; }

        [DisplayName("Gegenstand")]
        public string GegStdKurz { get; set; } 

        public string Klasse { get; set; } 

        public string Kurztitel { get; set; } 

        public string Verlag { get; set; }

        [DataType(DataType.Currency)]
        public double Preis { get; set; }

        [DisplayName("LehrerIn")]
        public string LehrKurz { get; set; }

    }
}