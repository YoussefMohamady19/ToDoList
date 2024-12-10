using Microsoft.EntityFrameworkCore;
using System;
using ToDoList.Models;

namespace ToDoList.DataBase
{
    public class Db : DbContext
    {
        public Db(DbContextOptions<Db> options) : base(options)
        {

        }
        public DbSet<Account> accounts { get; set; }
        public DbSet<Mission> missions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
