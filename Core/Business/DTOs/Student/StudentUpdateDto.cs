using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.DTOs.Student
{
    public class StudentUpdateDto: IDto
    {
        public string FullName { get; set; }
        public DateTime BornDate { get; set; }
    }
}
