namespace DeltaX.DataAccess.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
   

    [Table("Producer")]
    public partial class Producer : Entity<int>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Producer()
        {
            Movies = new HashSet<Movie>();
        }
        

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(1)]
        public string Sex { get; set; }

        [Column(TypeName = "date")]
        public DateTime DOB { get; set; }

        [StringLength(2000)]
        public string Bio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
