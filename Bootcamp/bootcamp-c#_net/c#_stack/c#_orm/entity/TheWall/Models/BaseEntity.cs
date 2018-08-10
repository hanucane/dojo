using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheWall.Models
{
    public abstract class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime created_at { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime updated_at { get; set; }
    }
}
