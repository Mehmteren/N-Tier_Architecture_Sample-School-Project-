using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;

namespace school.Entities
{
    public class Person: BaseEntity
    {
        [MaxLength(128)]
        [Required]

        public string Name { get; set; }

        [MaxLength(11)]
        [Required]
        public string IdentityNuber { get; set; }
        [Required]
        public DateTime BornDate { get; set; }

        public virtual Student Student { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
