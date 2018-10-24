using System;
using System.Collections.Generic;
using System.Text;
using GameOfDojan.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GameOfDojan.Data
{
    public class GameOfDojanDbContext : IdentityDbContext<ApplicationUser>
    {
        public GameOfDojanDbContext(DbContextOptions<GameOfDojanDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<ShoePic> ShoePics { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Likes> Likes { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Likes>().HasKey(x => new { x.ApplicationUserId, x.ShoePicId });
            base.OnModelCreating(builder);
        }

    }
}
