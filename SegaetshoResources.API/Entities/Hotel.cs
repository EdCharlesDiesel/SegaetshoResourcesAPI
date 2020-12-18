using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SegaetshoResources.API.Entities
{
    [Table("Hotels")]
    public class Hotel: AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
