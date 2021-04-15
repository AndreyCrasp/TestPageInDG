namespace TestPageInDG.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Asset
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Asset()
        {
            EmergencyMaintenances = new HashSet<EmergencyMaintenance>();
        }

        public long ID { get; set; }

        [Required]
        [StringLength(20)]
        public string AssetSN { get; set; }

        [Required]
        [StringLength(150)]
        public string AssetName { get; set; }

        public long DepartmentLocationID { get; set; }

        public long EmployeeID { get; set; }

        public long AssetGroupID { get; set; }

        [Required]
        [StringLength(2000)]
        public string Description { get; set; }

        [Column(TypeName = "date")]
        public DateTime? WarrantyDate { get; set; }

        public virtual AssetGroup AssetGroup { get; set; }

        public virtual DepartmentLocation DepartmentLocation { get; set; }

        public virtual Employee Employee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmergencyMaintenance> EmergencyMaintenances { get; set; }
    }
}
