using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Employee.Areas.project.Models;
using Employee.Areas.Employee.Models;

namespace Employee.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<project> Projects { get; set; }
        public DbSet<EMP> EMPs { get; set; }
    }
}
