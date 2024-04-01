using LPSTest.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPSTest.DataAccessLayer
{
    public class LPSDBContext : DbContext
    {
        public LPSDBContext(DbContextOptions<LPSDBContext> options) : base(options)
        {

        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Pengguna> Penggunas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>().ToTable("Event");
            modelBuilder.Entity<Event>().Property(x => x.Nama).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Event>().Property(x => x.CreatedAt).IsRequired();

            modelBuilder.Entity<Pengguna>().ToTable("Pengguna");
            modelBuilder.Entity<Pengguna>().Property(x => x.Nama).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Pengguna>().Property(x => x.Email).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Pengguna>().Property(x => x.Password).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Pengguna>().Property(x => x.CreatedAt).IsRequired();
        }
    }
}
