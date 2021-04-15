namespace TestPageInDG.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ChangedPart
    {
        public long ID { get; set; }

        public long EmergencyMaintenanceID { get; set; }

        public long PartID { get; set; }

        public decimal Amount { get; set; }

        public virtual EmergencyMaintenance EmergencyMaintenance { get; set; }

        public virtual Part Part { get; set; }
    }
}
