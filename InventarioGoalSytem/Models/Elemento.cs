using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventarioGoalSytem.Models
{
    public class Elemento
    {
        public string Tipo { get; set; }
        public string Nombre { get; set; }
        public string FechaCaducidad { get; set; }

        public bool Caducado 
        {
            get
            {
                return DateTime.Parse(FechaCaducidad).Date < DateTime.Now.Date;
            }
        }
    }
}