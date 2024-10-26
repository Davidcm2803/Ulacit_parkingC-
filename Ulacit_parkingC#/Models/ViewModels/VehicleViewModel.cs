using System.ComponentModel.DataAnnotations;

namespace Ulacit_parkingC_.Models.ViewModels
{
    public class VehicleViewModel
    {
        [Required(ErrorMessage = "La marca es obligatoria.")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "El color es obligatorio.")]
        public string Color { get; set; }

        [Required(ErrorMessage = "El número de placa es obligatorio.")]
        public string LicensePlate { get; set; }

        [Required(ErrorMessage = "El tipo de vehículo es obligatorio.")]
        public string VehicleType { get; set; } // Ejemplo: "Vehículo", "Moto"

        [Required(ErrorMessage = "El ID del propietario es obligatorio.")]
        public int OwnerId { get; set; } // Asegúrate de que este ID sea correcto

        public char UsesSpecialSpace { get; set; } // Asumiendo que es un char
    }
}
