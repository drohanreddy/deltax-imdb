namespace DeltaX.DataAccess.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
   

    [Table("Movie")]
    public partial class Movie : Entity<int>
    {

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Column(TypeName = "date")]
        public DateTime YearOfRelease { get; set; }

        [StringLength(5000)]
        public string Plot { get; set; }

        [StringLength(100)]
        public string PosterFileName { get; set; }

        public int? Producer { get; set; }
    }
}
