using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobApi.Models
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }

        // Create a table named Employees with the column fields of Model Employee
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Job> Jobs { get; set; }


    }
}
