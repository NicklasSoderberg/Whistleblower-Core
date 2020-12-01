using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Areas.Identity.Data;
using API.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace API.Data
{
    public class IdentityContext : IdentityDbContext<AppUser>
    {
        private readonly IConfiguration _config;

        public IdentityContext(DbContextOptions<IdentityContext> options, IConfiguration config)
            : base(options)
        {
            _config = config;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            //builder.Entity<DtoWhistle>().ToTable("Whistles");

        }
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Whistle> Whistles { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Lawyer> Lawyers { get; set; }
    }
}
