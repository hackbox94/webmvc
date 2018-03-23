using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace WEBAPI.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
           // builder.Entity<Post>()
           //.HasOne(p => p.Blog)
           //.WithMany(b => b.Posts)
           //.HasForeignKey(p => p.BlogId)
           //.HasConstraintName("ForeignKey_Post_Blog");
            //builder.Entity<Employee>().Ma
        }

        public DbSet<JobServiceHead> JobServiceHeads { get; set; }
        public DbSet<JobService> JobServices { get; set; }
        public DbSet<PriceMatrix> PriceMatrices { get; set; }
        public DbSet<Company> Companys { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Models.Bank> Bank { get; set; }
    }
   
    

    //public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    //{
    //    public ApplicationDbContext CreateDbContext(string[] args)
    //    {


    //        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
    //        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=aspnet-SampleCore-22c8cdfd68d9fb64;Trusted_Connection=True;");

    //        return new ApplicationDbContext(optionsBuilder.Options);
    //    }
    //}
}
