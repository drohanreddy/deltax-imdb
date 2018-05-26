namespace DeltaX.DataAccess.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Actor")]
    public partial class Actor : Entity<int>
    {

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
    }
}
