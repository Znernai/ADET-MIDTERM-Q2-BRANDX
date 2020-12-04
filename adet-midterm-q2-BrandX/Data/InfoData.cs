using BrandX.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrandX.Data
{
    public class InfoData : DbContext
    {
        public InfoData(DbContextOptions<InfoData> options) : base(options)
        {

        }

        public DbSet<PrelimData> Prelim { get; set; }
        public DbSet<MidtermData> Midterm { get; set; }
        public DbSet<PrefinalData> Prefinal { get; set; }
        public DbSet<FinalsData> Finals { get; set; }
        public DbSet<StudentInfo> StudentInfo { get; set; }
    }
}
