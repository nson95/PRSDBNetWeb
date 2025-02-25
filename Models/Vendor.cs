﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PRSNetWeb.Models;

[Table("Vendor")]
[Index("Code", Name = "UQ__Vendor__A25C5AA797409249", IsUnique = true)]
public partial class Vendor
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string Code { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string Address { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string City { get; set; } = null!;

    [StringLength(12)]
    [Unicode(false)]
    public string State { get; set; } = null!;

    [StringLength(5)]
    [Unicode(false)]
    public string Zip { get; set; } = null!;

    [StringLength(12)]
    [Unicode(false)]
    public string PhoneNumber { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [InverseProperty("Vendor")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
