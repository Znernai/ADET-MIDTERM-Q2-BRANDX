using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BrandX.Models
{
    public class PrefinalData
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

        //Prefinal Quiz
        public int Quiz1 { get; set; }
        public int Quiz2 { get; set; }
        public int Quiz3 { get; set; }

        //Prefinal Assignment
        public int Assignment1 { get; set; }
        public int Assignment2 { get; set; }
        public int Assignment3 { get; set; }

        //Prefinal Exam
        public int Exam { get; set; }
    }
}
