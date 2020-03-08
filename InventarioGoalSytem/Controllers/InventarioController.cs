using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;
using InventarioGoalSytem.Models;

namespace InventarioGoalSytem.Controllers
{
    [Authorize]
    public class InventarioController : ApiController
    {
        public static List<Elemento> inventario = new List<Elemento>();

        [HttpGet]
        public List<Elemento> GetInventario()
        {
            return inventario;
        }

        [HttpGet]
        public string SacarElemento(string nombre)
        {
            string result = string.Empty;
            Elemento elemento = inventario.FirstOrDefault(x => x.Nombre == nombre);

            if (elemento == null)
            {
                result = "El elemento no existe";
            }
            else
            {
                result = inventario.Remove(elemento) ? "El elemento [" + elemento.Nombre + ":" + elemento.Tipo + "] se ha sacado del inventario" : "No se ha podido sacar el elemento";
            }

            return result;
        }

        [HttpGet]
        public bool InsertarElemento(string tipo, string nombre, string fecha)
        {
            if (!string.IsNullOrWhiteSpace(tipo) && !string.IsNullOrWhiteSpace(nombre) && !string.IsNullOrWhiteSpace(fecha) && DateTime.TryParse(fecha, out _))
            {
                Elemento elemento = new Elemento
                {
                    Tipo = Regex.Replace(tipo, "[^0-9a-zA-Z]+", ""),
                    Nombre = Regex.Replace(nombre, "[^0-9a-zA-Z]+", ""),
                    FechaCaducidad = DateTime.Parse(fecha).ToString("dd-MM-yyyy")
                };

                if (!inventario.Exists(x => x.Nombre == elemento.Nombre))
                {
                    inventario.Add(elemento);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
