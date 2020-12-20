﻿using System;
using System.ComponentModel.DataAnnotations;

namespace SegaetshoResources.Services.TourManagement.Entities
{
    public abstract class AuditableEntity
    {
        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        public string UpdatedBy { get; set; }
    }
}