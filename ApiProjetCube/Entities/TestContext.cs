using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ApiProjetCube.Models;
using Org.BouncyCastle.Crypto.Tls;
using System.Configuration;

namespace ApiProjetCube.Entities;

public partial class TestContext : DbContext
{
    public TestContext()
    {
    }

    public TestContext(DbContextOptions<TestContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=Corentin72;database=test");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public DbSet<ApiProjetCube.Models.SubjectForum>? SubjectForum { get; set; }

    public DbSet<ApiProjetCube.Models.Category>? Category { get; set; }
}
