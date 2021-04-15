namespace TestPageInDG.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EmergencyMaintenance
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EmergencyMaintenance()
        {
            ChangedParts = new HashSet<ChangedPart>();
        }

        public long ID { get; set; }

        public long AssetID { get; set; }

        public long PriorityID { get; set; }

        [Required]
        [StringLength(200)]
        public string DescriptionEmergency { get; set; }

        [Required]
        [StringLength(200)]
        public string OtherConsiderations { get; set; }

        [Column(TypeName = "date")]
        public DateTime EMReportDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EMStartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EMEndDate { get; set; }

        [StringLength(200)]
        public string EMTechnicianNote { get; set; }

        public virtual Asset Asset { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChangedPart> ChangedParts { get; set; }

        public virtual Priority Priority { get; set; }
    }
}
