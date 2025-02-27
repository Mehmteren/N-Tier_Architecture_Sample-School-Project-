using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;

namespace school.Entities
{
    public class Student:BaseEntity
    {
        [ForeignKey("person")]
        [Required]
        public Guid PersonId { get; set; }
        public virtual Person Person { get; set; }

        [MaxLength(6)]
        [Required]
        public string SchoolNumber { get; set; }

        public virtual ICollection<StudentScore>StudentScores { get; set; }


    }
}
