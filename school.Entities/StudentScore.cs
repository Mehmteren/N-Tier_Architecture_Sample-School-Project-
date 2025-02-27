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
    public class StudentScore : BaseEntity
    {
        [ForeignKey("Student")]
        [Required]

        public Guid StudentId { get; set; } 

        public Student Student { get; set; }
        [ForeignKey("Lesson")]
        [Required]
        public Guid LessonId { get; set; }
        public Lesson Lesson { get; set; }

        [Required]
        public int ExamNumber { get; set; }

        [Required]
        public float Score { get; set; }   

    }
}
