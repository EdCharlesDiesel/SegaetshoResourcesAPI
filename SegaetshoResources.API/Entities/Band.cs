using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SegaetshoResources.API.Entities
{
    [Table("Bands")]
    public class Band : AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid BandId { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
    }
}
