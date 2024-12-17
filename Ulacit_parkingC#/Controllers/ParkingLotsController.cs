using System.Linq;
using System.Web.Mvc;
using Ulacit_parkingC_.Models;
using Ulacit_parkingC_.Models.ViewModels;

namespace Ulacit_parkingC_.Controllers
{
    public class ParkingLotsController : Controller
    {
        private readonly ParkingDatabaseEntities _context = new ParkingDatabaseEntities();

        // GET: ParkingLots
        public ActionResult Index()
        {
            var parkingLots = _context.ParkingLots
                .Select(pl => new ParkingLotViewModel
                {
                    Id = pl.id,
                    Name = pl.name,
                    RegularCapacity = pl.regular_capacity,
                    MotorcycleCapacity = pl.motorcycle_capacity,
                    SpecialCapacity = pl.special_capacity
                }).ToList(); // Asegúrate de que sea una lista

            return View(parkingLots); // Aquí se pasa una lista, no un solo objeto
        }

        // GET: ParkingLots/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ParkingLots/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ParkingLotViewModel model)
        {
            if (ModelState.IsValid)
            {
                var parkingLot = new ParkingLots
                {
                    name = model.Name,
                    regular_capacity = model.RegularCapacity,
                    motorcycle_capacity = model.MotorcycleCapacity,
                    special_capacity = model.SpecialCapacity
                };

                _context.ParkingLots.Add(parkingLot);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: ParkingLots/Edit/5
        public ActionResult Edit(int id)
        {
            var parkingLot = _context.ParkingLots.Find(id);
            if (parkingLot == null)
                return HttpNotFound();

            var model = new ParkingLotViewModel
            {
                Id = parkingLot.id,
                Name = parkingLot.name,
                RegularCapacity = parkingLot.regular_capacity,
                MotorcycleCapacity = parkingLot.motorcycle_capacity,
                SpecialCapacity = parkingLot.special_capacity
            };

            return View(model);
        }

        // POST: ParkingLots/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ParkingLotViewModel model)
        {
            if (ModelState.IsValid)
            {
                var parkingLot = _context.ParkingLots.Find(model.Id);
                if (parkingLot == null)
                    return HttpNotFound();

                parkingLot.name = model.Name;
                parkingLot.regular_capacity = model.RegularCapacity;
                parkingLot.motorcycle_capacity = model.MotorcycleCapacity;
                parkingLot.special_capacity = model.SpecialCapacity;

                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: ParkingLots/Delete/5
        public ActionResult Delete(int id)
        {
            var parkingLot = _context.ParkingLots.Find(id);
            if (parkingLot == null)
                return HttpNotFound();

            return View(parkingLot); // Muestra la vista con la información del estacionamiento a eliminar
        }

        // POST: ParkingLots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var parkingLot = _context.ParkingLots.Find(id);
            if (parkingLot == null)
                return HttpNotFound();

            _context.ParkingLots.Remove(parkingLot);
            _context.SaveChanges();

            TempData["Message"] = "Estacionamiento eliminado correctamente."; // Mensaje de confirmación
            return RedirectToAction("Index"); // Redirige a la lista de estacionamientos
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();

            base.Dispose(disposing);
        }
    }
}
