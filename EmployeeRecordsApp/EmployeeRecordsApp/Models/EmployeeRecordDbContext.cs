using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRecordsApp.Models
{
    public class EmployeeRecordDbContext:DbContext
    {
        public EmployeeRecordDbContext(DbContextOptions<EmployeeRecordDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employee { get; set; }
    }
}
