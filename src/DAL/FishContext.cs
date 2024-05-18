using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.Sqlite;
using System.IO;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using UnderwaterBot.Modules;

namespace UnderwaterBot.DAL
{ 

    public partial class FishContext : DbContext
    {
        public DbSet<Fish> FishCollection { get; set; }
            
        public FishContext()
        {
            Database.EnsureDeleted(); // Use this only when you want to clear database contents on start
            Database.EnsureCreated(); // Creates the database
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string directory = Path.Combine(AppContext.BaseDirectory);

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            string dbDirectory = Path.Combine(directory, "Fish.db");

            optionsBuilder.UseSqlite($"Filename={dbDirectory}");
        }
    }
    }