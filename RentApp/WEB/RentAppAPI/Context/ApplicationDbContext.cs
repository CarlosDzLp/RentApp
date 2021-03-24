using System;
using Microsoft.EntityFrameworkCore;
using RentAppAPI.Entities;

namespace RentAppAPI.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Users> User { get; set; }
    }
}
