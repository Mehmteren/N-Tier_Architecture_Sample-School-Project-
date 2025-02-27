using Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school.Entities
{
    public class Teacher:BaseEntity
    {
        [ForeignKey("Person")]
        [Required]
        public Guid PersonId { get; set; }
        public virtual Person person { get; set; }
    }
}
