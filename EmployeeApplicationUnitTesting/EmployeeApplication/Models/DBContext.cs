using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApplication.Models
{
    public class DBContext:DbContext
    {

        public DBContext(DbContextOptions options)
           : base(options)
        {

        }

        public DbSet<EmployeeModel> Employees { get; set; }
    }
}
