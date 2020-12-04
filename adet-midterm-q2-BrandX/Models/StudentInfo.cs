using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BrandX.Models
{
    public class StudentInfo
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Course { get; set; }
        public string Address { get; set; }
        public int ContactNo { get; set; }
    }
}
