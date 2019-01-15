using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

using music_player_android.Interfaces;
using music_player_android.Resx;
using music_player_android.Views;
using music_player_android.ViewModels;
using music_player_android.Models;
using System.IO;
using Xamarin.Essentials;

namespace music_player_android.DAL
{
    class MusicDatabase : DbContext
    {
        public MusicDatabase()
        {
            try
            {
                this.Database.EnsureCreated();
                this.Database.Migrate();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public DbSet<Music> MusicTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "Musics.db3");
            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }
    }
}
