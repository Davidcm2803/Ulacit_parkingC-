using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ulacit_parkingC_.Models.ViewModels
{
    public class ParkingLotViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RegularCapacity { get; set; }
        public int MotorcycleCapacity { get; set; }
        public int SpecialCapacity { get; set; }
    }
}
