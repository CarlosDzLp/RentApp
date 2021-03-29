using System;
using Microsoft.EntityFrameworkCore;
using RentAppEntities.Entities;

namespace RentAppAPI.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
