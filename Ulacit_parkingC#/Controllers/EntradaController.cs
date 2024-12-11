using System;
using System.Linq;
using System.Web.Mvc;
using Ulacit_parkingC_.Models;
using Ulacit_parkingC_.Models.ViewModels;

namespace Ulacit_parkingC_.Controllers
{
    public class EntradaController : Controller
    {
        // GET: Entrada vehiculo
        public ActionResult Entrada()
        {
            // Inicializa ViewBag.estado para evitar errores en la vista
            ViewBag.estado = null;
            ViewBag.message = null;
            return View();
        }

        // POST: Entrada/SearchV
        [HttpPost]
        public ActionResult SearchV(string placa)
        {
            if (!string.IsNullOrWhiteSpace(placa)) // Valida que la placa no sea nula ni vacía
            {
                using (ParkingDatabaseEntities db = new ParkingDatabaseEntities())
                {
                    // Busca si la placa existe en la base de datos
                    bool estado = db.Vehicles.Any(v => v.license_plate == placa);

                    // Establece los valores de ViewBag según el resultado
                    ViewBag.estado = estado;
                    ViewBag.message = estado
                        ? "El vehículo está registrado en el sistema."
                        : "El vehículo no está registrado en el sistema.";
                }
            }
            else
            {
                // Maneja el caso de una placa vacía
                ViewBag.estado = null;
                ViewBag.message = "Por favor, ingrese una placa válida.";
            }

            return View("Entrada"); // Retorna siempre la vista Entrada
        }
    }
}
