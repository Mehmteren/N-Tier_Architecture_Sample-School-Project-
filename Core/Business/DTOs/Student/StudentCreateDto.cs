using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.DTOs.Student
{
    public class StudentCreateDto : IDto
    {
        public string FullName { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime BornDate { get; set; }
        public string SchoolNumber { get; set; }
    }
}