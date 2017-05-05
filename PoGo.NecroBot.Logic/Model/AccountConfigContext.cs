﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.IO;

namespace PoGo.NecroBot.Logic.Model
{
    public partial class AccountConfigContext : DbContext
    {
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<PokemonTimestamp> PokemonTimestamp { get; set; }
        public virtual DbSet<PokestopTimestamp> PokestopTimestamp { get; set; }

        public AccountConfigContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var profilePath = Path.Combine(Directory.GetCurrentDirectory());
            var profileConfigPath = Path.Combine(profilePath, "config");
            var dbFile = Path.Combine(profileConfigPath, "accounts.db");

            optionsBuilder.UseSqlite($"data source={dbFile}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}