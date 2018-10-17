using System;
using System.Collections.Generic;
using System.Text;
using GameOfDojan.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GameOfDojan.Data
{
    public class GameOfDojanDbContext : IdentityDbContext
    {
        public GameOfDojanDbContext(DbContextOptions options)
            : base(options)
        {
            
        }

        public DbSet<ShoePic> ShoePics { get; set; }
        public DbSet<Comment> Comments { get; set; }


    }
}
