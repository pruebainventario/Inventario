using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using InventarioGoalSytem.Controllers;
using InventarioGoalSytem.Models;

namespace InventarioGoalSytem.Tests
{
    [TestClass]
    public class UnitTest1
    {
        List<Elemento> inventarioTest = new List<Elemento>
        {
            new Elemento { Tipo = "Coche", Nombre = "Toyota", FechaCaducidad = DateTime.Now.AddDays(10).ToString("yyyy-MM-dd") },
            new Elemento { Tipo = "Movil", Nombre = "Samsung", FechaCaducidad = DateTime.Now.AddDays(-10).ToString("yyyy-MM-dd") },
            new Elemento { Tipo = "Comida", Nombre = "Pollo", FechaCaducidad = DateTime.Now.AddDays(10).ToString("yyyy-MM-dd") }
        };

        InventarioController controller = new InventarioController();

        [TestMethod]
        public void GetInventarioTest()
        {
            InventarioController.inventario.AddRange(inventarioTest);
            List<Elemento> result = controller.GetInventario();
            Assert.AreEqual(inventarioTest.Count, result.Count);
            InventarioController.inventario.Clear();
        }

        [TestMethod]
        public void GetElementoCaducado()
        {
            InventarioController.inventario.AddRange(inventarioTest);
            Elemento elemento = InventarioController.inventario.FirstOrDefault(x => x.Caducado);
            Assert.IsNotNull(elemento);
            InventarioController.inventario.Clear();
        }

        [TestMethod]
        public void IntroducirElemento()
        {
            Assert.IsTrue(controller.InsertarElemento("PC", "MSI", DateTime.Now.ToString("yyyy-MM-dd")));
            InventarioController.inventario.Clear();
        }

        [TestMethod]
        public void SacarElemento()
        {
            InventarioController.inventario.AddRange(inventarioTest);
            string result = controller.SacarElemento("Samsung");
            Assert.AreEqual(result, "El elemento [Samsung:Movil] se ha sacado del inventario");
            InventarioController.inventario.Clear();
        }
    }
}
