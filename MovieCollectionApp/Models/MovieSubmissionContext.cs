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

        public DbSet<Category> Category { get; set; }


        //Seeding the data
        protected override void OnModelCreating(ModelBuilder mb)
        {

            mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName="Action/Adventure"},
                new Category { CategoryId = 2, CategoryName = "Comedy" },
                new Category { CategoryId = 3, CategoryName = "Family" },
                new Category { CategoryId = 4, CategoryName = "Drama" },
                new Category { CategoryId = 5, CategoryName = "Horror/Suspense" },
                new Category { CategoryId = 6, CategoryName = "Miscellaneous" },
                new Category { CategoryId = 7, CategoryName = "Television" },
                new Category { CategoryId = 8, CategoryName = "VHS" }
                );

            mb.Entity<MovieInput>().HasData(

                new MovieInput
                {
                    MovieId = 1,
                    CategoryId = 1,
                    Title = "The Avengers",
                    Year = 2012,
                    Director = "Joss Whedon",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Note = "",
                },
                new MovieInput
                {
                    MovieId = 2,
                    CategoryId = 2,
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
                    CategoryId = 3,
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
