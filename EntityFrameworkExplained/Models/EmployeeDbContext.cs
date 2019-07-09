﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkExplained.Models
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }
}
