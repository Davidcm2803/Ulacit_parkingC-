using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;
using System.Web.Security;
using Ulacit_parkingC_.Models;
using Ulacit_parkingC_.Models.ViewModels;

namespace Ulacit_parkingC_.Controllers
{
    public class NuevoUsuarioController : Controller
    {
        private readonly ParkingDatabaseEntities _db = new ParkingDatabaseEntities();

        // GET: NuevoUsuario
        [HttpGet]
        public ActionResult Index()
        {
            // Obtener los roles desde la base de datos
            var roles = _db.Roles
                           .Select(r => new { r.id, r.role_name }) // Seleccionar solo los datos necesarios
                           .ToList(); // Ejecutar la consulta

            // Convertir los datos seleccionados en objetos de la clase Roles
            var rolesList = roles.Select(r => new Ulacit_parkingC_.Models.Roles
            {
                id = r.id,
                role_name = r.role_name
            }).ToList();

            // Crear el modelo UserViewModel y asignar la lista de roles
            var model = new UserViewModel
            {
                Roles = rolesList // Pasar la lista de roles al modelo
            };

            return View(model); // Pasar el modelo con los roles a la vista
        }

        // POST: Agregar Usuario
        [HttpPost]
        public JsonResult AgregarUsuario(string nombre, string cedula, string email, DateTime fechaNacimiento, string password, int rol)
        {
            try
            {
                // Verifica si el rol existe en la base de datos
                var rolEntity = _db.Roles.FirstOrDefault(r => r.id == rol);
                if (rolEntity == null)
                {
                    return Json(new { success = false, message = "El rol seleccionado no es válido." });
                }

                // Verifica si el correo electrónico ya existe
                var usuarioExistente = _db.Users.FirstOrDefault(u => u.email == email);
                if (usuarioExistente != null)
                {
                    return Json(new { success = false, message = "El correo electrónico ya está registrado." });
                }

                // Verificar si la identificación ya está registrada
                var usuarioExistentePorCedula = _db.Users.FirstOrDefault(u => u.identification == cedula);
                if (usuarioExistentePorCedula != null)
                {
                    return Json(new { success = false, message = "La identificación proporcionada ya está registrada en el sistema. Por favor, utilice otra identificación." });
                }

                // Encriptar la contraseña con SHA256 antes de guardarla
                string contrasenaEncriptada = EncriptarContraseña(password);

                // Crear nueva entidad de usuario
                var nuevoUsuario = new Users
                {
                    name = nombre,
                    email = email,
                    date_of_birth = fechaNacimiento,
                    identification = cedula,
                    role_id = rol, // Se asigna directamente el ID del rol
                    password = contrasenaEncriptada,
                    first_login = "1", // Indica que es el primer inicio de sesión
                    password_changed = "0" // Contraseña aún no cambiada
                };

                // Usar una transacción para asegurar que todos los cambios se guarden correctamente
                using (var transaction = _db.Database.BeginTransaction())
                {
                    try
                    {
                        // Agregar el usuario a la base de datos
                        _db.Users.Add(nuevoUsuario);
                        _db.SaveChanges();

                        // Confirmar la transacción
                        transaction.Commit();

                        return Json(new { success = true, message = "Usuario agregado exitosamente." });
                    }
                    catch (Exception ex)
                    {
                        // Revertir la transacción en caso de error
                        transaction.Rollback();

                        // Captura todos los detalles del error para debug
                        var errorMessage = $"Error al agregar el usuario: {ex.ToString()}"; // Mostrar toda la traza del error
                        return Json(new { success = false, message = errorMessage });
                    }
                }
            }
            catch (Exception ex)
            {
                // Detalles más específicos en el error
                var errorMessage = $"Error al agregar el usuario: {ex.ToString()}"; // Captura todos los detalles
                return Json(new { success = false, message = errorMessage });
            }
        }

        // Función para encriptar la contraseña con SHA256
        private string EncriptarContraseña(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
}