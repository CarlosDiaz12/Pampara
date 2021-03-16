using Microsoft.EntityFrameworkCore;
using Pampara.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pampara.DataAccess.Data
{
   public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }
}
