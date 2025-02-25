using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;

namespace PRSNetWeb.Models;

public partial class PrsdbContext : DbContext
{

    public PrsdbContext(DbContextOptions<PrsdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<LineItem> LineItems { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Vendor> Vendors { get; set; }

    
}
