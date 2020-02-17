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

  }
}
