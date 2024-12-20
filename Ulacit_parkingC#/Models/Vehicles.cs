namespace Ulacit_parkingC_.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Vehicles
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vehicles()
        {
            this.MovementLog = new HashSet<MovementLog>();
        }

        public int id { get; set; }
        public string brand { get; set; }
        public string color { get; set; }
        public string license_plate { get; set; }
        public string vehicle_type { get; set; }
        public int owner_id { get; set; }
        public string uses_special_space { get; set; }
        public string is_active { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MovementLog> MovementLog { get; set; }
        public virtual Users Users { get; set; }
    }
}
