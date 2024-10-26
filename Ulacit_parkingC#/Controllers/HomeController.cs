using System;
using System.Web.Mvc;
using System.Web.UI;
using Ulacit_parkingC_.Models; // Asegúrate de que el espacio de nombres sea el correcto

namespace Ulacit_parkingC_.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Privacy()
        {
            return View();
        }

        // Acción para la vista de error
        [OutputCache(Duration = 0, Location = OutputCacheLocation.None, NoStore = true)]
        public ActionResult Error()
        {
            var errorViewModel = new ErrorViewModel
            {
                // En .NET Framework, puedes usar SessionID como alternativa para el Request ID
                RequestId = HttpContext?.Session?.SessionID ?? Guid.NewGuid().ToString()
            };
            return View(errorViewModel);
        }
    }
}



