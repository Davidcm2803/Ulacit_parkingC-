using System;
using System.Linq;
using System.Web.Mvc;
using Ulacit_parkingC_.Models;
using Ulacit_parkingC_.Models.ViewModels;


public class NuevoVehiculoController : Controller
{
    private readonly ParkingDatabaseEntities _db = new ParkingDatabaseEntities();

    public ActionResult Index()
    {

        var usuarios = _db.Users.Select(u => new UserViewModel
        {
            Id = u.id,
            Name = u.name
        }).ToList();


        var viewModel = new VehicleViewModel
        {
            Usuarios = usuarios
        };

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(VehicleViewModel newVehicle)
    {
        if (ModelState.IsValid)
        {

            string usesSpecialSpaceValue = newVehicle.UsesSpecialSpace ? "Y" : "N";

            var vehicle = new Vehicles
            {
                brand = newVehicle.Brand,
                color = newVehicle.Color,
                license_plate = newVehicle.LicensePlate,
                vehicle_type = newVehicle.VehicleType,
                owner_id = newVehicle.OwnerId,
                uses_special_space = usesSpecialSpaceValue, 
                is_active = "1" 
            };

            _db.Vehicles.Add(vehicle);
            _db.SaveChanges();

            TempData["SuccessMessage"] = "Vehículo registrado exitosamente.";

            return RedirectToAction("Index");
        }


        var usuarios = _db.Users.Select(u => new UserViewModel
        {
            Id = u.id,
            Name = u.name
        }).ToList();

        newVehicle.Usuarios = usuarios;
        return View("Index", newVehicle);
    }

}

