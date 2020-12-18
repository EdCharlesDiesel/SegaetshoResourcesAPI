using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SegaetshoResources.API.Entities
{
    [Table("Managers")]
    public class Manager : AuditableEntity
    {
        public Guid ManagerId { get; set; }
        public string Name { get; set; }
    }
}
