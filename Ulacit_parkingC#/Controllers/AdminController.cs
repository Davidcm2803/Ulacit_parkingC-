using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;
using Ulacit_parkingC_.Models;
using Ulacit_parkingC_.Models.ViewModels;


namespace Ulacit_parkingC_.Controllers
{
    public class AdminController : Controller
    {
        private ParkingDatabaseEntities db = new ParkingDatabaseEntities();

        // GET: Admin/Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        // POST: Admin/Login
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            try
            {
                // Buscar el usuario en la base de datos por su correo electrónico
                var admin = db.Users.FirstOrDefault(u => u.email == email);

                // Verificar si el usuario existe y la contraseña es correcta
                if (admin == null)
                {
                    ViewBag.ErrorMessage = "El correo electrónico no está registrado.";
                    return View();
                }

                // Verificar si la contraseña coincide
                if (admin.password != password)
                {
                    ViewBag.ErrorMessage = "La contraseña es incorrecta.";
                    return View();
                }

                // Si ambos son correctos, entonces se inicia sesión
                Session["AdminLogged"] = admin;
                TempData["SuccessMessage"] = "Inicio de sesión exitoso.";
                return RedirectToAction("Index", "Home");

            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Ocurrió un error: " + ex.Message;
                return View();
            }
        }

        // Método para Logout
        public ActionResult Logout()
        {
            Session["AdminLogged"] = null;
            return RedirectToAction("Login"); // Redirige a la página de login
        }

        // GET: Admin/Register
        [HttpPost]
        public ActionResult Register(UserViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Validar que el correo electrónico no esté ya registrado
            if (db.Users.Any(u => u.email == model.Email))
            {
                ModelState.AddModelError("Email", "El correo electrónico ya está en uso.");
                return View(model);
            }

            // Crear nuevo usuario
            var newUser = new Users // Asegúrate de que sea del tipo correcto
            {
                name = model.Name,
                email = model.Email,
                DateOfBirth = model.DateOfBirth,
                identification = model.Identification,
                cardNumber = model.CardNumber,
                role = model.Role,
                PasswordChanged = "N", // Cambiar según sea necesario
                isActive = 'Y' // Cambiar según sea necesario
            };

            db.Users.Add(newUser); // Esto ahora debería funcionar correctamente
            db.SaveChanges(); // Guarda los cambios en la base de datos
            return RedirectToAction("Login", new { showToast = "registrationSuccessful" });
        }




        // GET: Admin/ChangePassword
        public ActionResult ChangePassword()
        {
            return View();
        }

        // POST: Admin/ChangePassword
        [HttpPost]
        public ActionResult ChangePassword(string currentPassword, string newPassword)
        {
            var admin = (User)Session["AdminLogged"];
            if (admin == null)
            {
                return RedirectToAction("Login");
            }

            var user = db.Users.Find(admin.id);

            ViewBag.ErrorMessage = "La contraseña actual es incorrecta.";
            return View();
        }


    }
}



