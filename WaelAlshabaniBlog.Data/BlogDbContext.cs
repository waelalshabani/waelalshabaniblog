using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WaelAlshabaniBlog.Core.Domain;

namespace WaelAlshabaniBlog.Data
{
    public class BlogDbContext : IdentityDbContext
    {

        public DbSet<BlogEntity> Blogs { get; set; }

        public BlogDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
