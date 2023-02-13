using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollectionApp.Models
{
    public class MovieSubmissionContext : DbContext
    {
        // Constructor
        public MovieSubmissionContext (DbContextOptions<MovieSubmissionContext> options) : base (options)
        {
            // Leave blank for now
        }

        public DbSet<MovieInput> Inputs { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<MovieInput>().HasData(

                new MovieInput
                {
                    MovieId = 1,
                    Category = "Action/Adventure",
                    Title = "The Avengers",
                    Year = 2012,
                    Director = "Joss Whedon",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Note = ""
                },
                new MovieInput
                {
                    MovieId = 2,
                    Category = "Comedy",
                    Title = "Madagascar",
                    Year = 2005,
                    Director = "Eric Darnell, Tom McGrath",
                    Rating = "PG",
                    Edited = false,
                    LentTo = "",
                    Note = ""
                },
                new MovieInput
                {
                    MovieId = 3,
                    Category = "Family",
                    Title = "Moana",
                    Year = 2016,
                    Director = "Ron Clements, John Musker",
                    Rating = "PG",
                    Edited = false,
                    LentTo = "",
                    Note = ""
                }
            );
        }
    }
}
