using Microsoft.EntityFrameworkCore;
using PassportIssues.Domain.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassportIssues.Repository.Dbcontext
{
    public class ApplicationManagementContext:DbContext
    {

        public ApplicationManagementContext(DbContextOptions<ApplicationManagementContext> options) : base(options)
        {

        }

        public DbSet<FormModel> FormModels { get; }

        protected override void OnModelCreating(ModelBuilder modelbBuilder)
        {
            modelbBuilder.Entity<FormModel>().HasKey(x => x.Id);
            modelbBuilder.Entity<FormModel>().Property(x => x.Service).IsRequired();
            modelbBuilder.Entity<FormModel>().Property(x => x.Email).IsRequired();
            modelbBuilder.Entity<FormModel>().Property(x => x.FirstName).IsRequired();
            modelbBuilder.Entity<FormModel>().Property(x => x.LastName).IsRequired();
            modelbBuilder.Entity<FormModel>().Property(x => x.Origin).IsRequired();
        }
    }
}
