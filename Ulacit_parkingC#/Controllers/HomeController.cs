using System;
using System.Web.Mvc;
using System.Web.UI;
using Ulacit_parkingC_.Models; // Asegúrate de que el espacio de nombres sea el correcto

namespace Ulacit_parkingC_.Controllers
{
    public class HomeController : Controller
    {
        // Acción para la página principal
        public ActionResult Index()
        {
            return View();
        }
    }

}



