using Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school.Entities
{
    public class Lesson :BaseEntity
    {
        [MaxLength(48)]
        [Required]
        public string Name { get; set; }

        public virtual ICollection<StudentScore> StudentScores { get; set; }
        
    }
}
