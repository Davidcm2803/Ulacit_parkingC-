using System.Collections.Generic;

namespace Ulacit_parkingC_.Models.ViewModels
{
    public class VehicleViewModel
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public string LicensePlate { get; set; }
        public string VehicleType { get; set; }
        public int OwnerId { get; set; }
        public string UsesSpecialSpace { get; set; }
        public string IsActive { get; set; }
    }

}




