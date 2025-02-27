using Core.Business.DTOs.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.DTOs.Lesson
{
    public class LessonGetDto :LessonDto, IEntityGetDto
    {
        public Guid Id { get; set; }
    }
}
