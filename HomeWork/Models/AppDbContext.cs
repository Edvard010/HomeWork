using HomeWork.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWork.Models
{
    public class AppDbContext : IdentityDbContext<CustomUser, IdentityRole<int>, int>
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<CustomUser> UsersCustom { get; set; }
        public DbSet<NoteEntity> Notes { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<NoteEntity>();

                //.HasOne(a => a.CustomUser)
                //.WithMany(b => b.Notes);
                
                
                
            
        }
    }
}
