//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ulacit_parkingC_.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ParkingAssignments
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public int parking_lot_id { get; set; }
        public System.DateTime assignment_date { get; set; }
    
        public virtual ParkingLots ParkingLots { get; set; }
        public virtual Users Users { get; set; }
    }
}
