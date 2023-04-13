using eTicket2.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace eTicket2.Data
{
    public class AppDbContext : DbContext
    {
        //  database context files are used to translate or
        //  link between the application Models and the database
        //  dbcontext files can understand both C# & SQL
        //  they are C# classes that inherit from DbContext class
        //  which is found in the Microsoft.EntityFrameworkCore Package
        //  add builder.Services.AddDbContext<AppDbContext>(); to Program.cs

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor_Movie>().HasKey(am => new
            {
                am.ActorId,
                am.MovieId
            });

            modelBuilder.Entity<Actor_Movie>()
                .HasOne(m => m.Movie)
                .WithMany(am => am.Actors_Movies)
                .HasForeignKey(am => am.MovieId);


            modelBuilder.Entity<Actor_Movie>()
                .HasOne(m => m.Actor)
                .WithMany(am => am.Actors_Movies)
                .HasForeignKey(am => am.ActorId);


            base.OnModelCreating(modelBuilder);
        }

        // defining the table names for each Model
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor_Movie> Actors_Movies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Producer> Producers { get; set; }
    }
}
