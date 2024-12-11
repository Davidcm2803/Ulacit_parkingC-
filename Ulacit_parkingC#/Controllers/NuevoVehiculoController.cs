using System;
using System.Linq;
using System.Web.Mvc;
using Ulacit_parkingC_.Models;
using Ulacit_parkingC_.Models;  // Asegúrate de que el namespace sea el adecuado
using ParkingDatabaseEntities = Ulacit_parkingC_;  // Usa el contexto correcto de Entity Framework

public class NuevoVehiculoController : Controller
{
    private readonly ParkingDatabaseEntities _db = new ParkingDatabaseEntities(); // Contexto de Entity Framework

    // Acción para mostrar la vista de creación de vehículo
    public ActionResult Index()
    {
        // Obtener los usuarios para poder asignar un vehículo a uno de ellos
        var usuarios = _db.Users.ToList();
        ViewBag.Usuarios = new SelectList(usuarios, "id", "name");  // Opcional: Selección de usuarios
        return View();
    }

    // Acción para agregar un vehículo
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Vehicles newVehicle)
    {
        if (ModelState.IsValid)
        {
            // Agregar el nuevo vehículo
            _db.Vehicles.Add(newVehicle);
            _db.SaveChanges();

            // Redirigir a la vista Index después de agregar el vehículo
            return RedirectToAction("Index");
        }

        // Si el modelo no es válido, recargar los usuarios para la selección en la vista
        var usuarios = _db.Users.ToList();
        ViewBag.Usuarios = new SelectList(usuarios, "id", "name");
        return View("Index", newVehicle);
    }
}
