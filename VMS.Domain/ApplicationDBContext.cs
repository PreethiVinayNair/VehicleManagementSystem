using System;
using VMS.Domain.Extensions;
using Microsoft.EntityFrameworkCore;
using VMS.Domain.Entities;

namespace VMS.Domain
{

  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public virtual DbSet<Vehicle> vehicles { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.RemovePluralizingTableNameConvention();

      modelBuilder.Entity<Vehicle>().Property(l => l.Id).HasDefaultValueSql("newsequentialid()");
      
      base.OnModelCreating(modelBuilder);
    }
  }
}
