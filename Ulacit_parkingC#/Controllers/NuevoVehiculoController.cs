using System;
using System.Linq;
using System.Web.Mvc;
using Ulacit_parkingC_.Models;
using Ulacit_parkingC_.Models.ViewModels;


public class NuevoVehiculoController : Controller
{
    private readonly ParkingDatabaseEntities _db = new ParkingDatabaseEntities();

    // Acción para mostrar la vista de creación de vehículo
    public ActionResult Index()
    {
        var usuarios = _db.Users.Select(u => new UserViewModel
        {
            Id = u.id,
            Name = u.name
        }).ToList();

        var viewModel = new VehicleViewModel
        {
            Usuarios = usuarios // Agregar la lista de usuarios al modelo
        };

        return View(viewModel);
    }


    // Acción para agregar un vehículo
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(VehicleViewModel newVehicle)
    {
        if (ModelState.IsValid)
        {
            // Convertir UsesSpecialSpace a 'Y' o 'N'
            newVehicle.UsesSpecialSpace = newVehicle.UsesSpecialSpace == "on" ? "Y" : "N";  // 'on' es el valor por defecto del checkbox

            // Crear el vehículo en la base de datos
            var vehicle = new Vehicles
            {
                brand = newVehicle.Brand,
                color = newVehicle.Color,
                license_plate = newVehicle.LicensePlate,
                vehicle_type = newVehicle.VehicleType,
                owner_id = newVehicle.OwnerId,
                uses_special_space = newVehicle.UsesSpecialSpace,
                is_active = "1"
            };

            _db.Vehicles.Add(vehicle);
            _db.SaveChanges();

            TempData["SuccessMessage"] = "Vehículo registrado exitosamente.";
            return RedirectToAction("Index");
        }

        // Si el modelo no es válido, pasa de nuevo la lista de usuarios
        var usuarios = _db.Users.ToList();
        ViewBag.Usuarios = new SelectList(usuarios, "Id", "Name");
        return View("Index", newVehicle);
    }


}
