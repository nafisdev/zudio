using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Zudio.Model;

namespace Zudio.Infra;

public class BloggingContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }

    public string DbPath { get; }

    public BloggingContext()
    {
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseMySql("server=localhost;Port=3308;database=zudio;user=zudio;password=zudio",ServerVersion.AutoDetect("server=localhost;Port=3308;database=zudio;user=zudio;password=zudio"));
}