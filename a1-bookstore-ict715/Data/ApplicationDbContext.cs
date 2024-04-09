using a1_bookstore_ict715.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace a1_bookstore_ict715.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        //protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        //{
        //    base.ConfigureConventions(configurationBuilder);

        //    configurationBuilder.Properties<DateTime>().HaveConversion<DateTimeConverter>();
        //}
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
        // The Books table in our DB
        public DbSet<BookModel> Book { get; set; }

        // The book Genre list in our DB
        public DbSet<GenreModel> Genre { get; set; }

        // The Contact Us List in our database
        public DbSet<ContactUsModel> ContactUs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Create Seed data
            modelBuilder.Entity<GenreModel>().HasData(
                new GenreModel
                {
                    //GenreId = 1,
                    GenreId = "Phi",
                    GenreName = "Philosophy and psychology",
                },
                new GenreModel
                {
                    //GenreId = 2,
                    GenreId = "Rel",
                    GenreName = "Religion",
                },
                new GenreModel
                {
                    //GenreId = 3,
                    GenreId = "Soc",
                    GenreName = "Social sciences",
                },
                new GenreModel
                {
                    //GenreId = 4,
                    GenreId = "Lang",
                    GenreName = "Languages",
                },
                new GenreModel
                {
                    //GenreId = 5,
                    GenreId = "Nat",
                    GenreName = "Natural sciences & mathmatics",
                },
                new GenreModel
                {
                    //GenreId = 6,
                    GenreId = "ScFi",
                    GenreName = "Science Fiction and fantasy",
                },
                new GenreModel
                {
                    //GenreId = 7,
                    GenreId = "Tec",
                    GenreName = "Technology and applied sciences",
                },
                new GenreModel
                {
                    //GenreId = 8,
                    GenreId = "Art",
                    GenreName = "The arts",
                },
                new GenreModel
                {
                    //GenreId = 9,
                    GenreId = "Fic",
                    GenreName = "General Fiction and literature",
                },
                new GenreModel
                {
                    //GenreId = 10,
                    GenreId = "Geo",
                    GenreName = "Geography and history",
                }
                );
            modelBuilder.Entity<BookModel>().Property(p => p.Price).HasPrecision(18, 2);
            modelBuilder.Entity<BookModel>().HasData(
                new BookModel
                {
                    BookId = 1,
                    Name = "Winter's Heart",
                    GenreName = "Science Fiction and fantasy",
                    Description =
                    "Yet another book in the Eye of the World saga",
                    Authors = "Robert Jordan",
                    Price = 49,
                    PublishDate = new DateTime(2000, 11, 1)
                },
                new BookModel
                {
                    BookId = 2,
                    Name = "John Dies at the End",
                    GenreName = "General Fiction and literature",
                    Description =
                    "The spoiler is that John does not, in fact, die in the end",
                    Authors = "David Wong",
                    Price = 18,
                    PublishDate = new DateTime(2009, 06, 1)
                },
                new BookModel
                {
                    BookId = 3,
                    Name = "Cosmos",
                    GenreName = "Natural sciences & mathmatics",
                    Description =
                    "Cosmos is about science in its broadest human context, how science and society grew up together",
                    Authors = "Carl Sagan",
                    Price = 50,
                    PublishDate = new DateTime(2010, 10, 1)
                },
                new BookModel
                {
                    BookId = 4,
                    Name = "The Guns of August",
                    GenreName = "Geography and history",
                    Description =
                    "Tells the story of the opening months of World War 1",
                    Authors = "Barbara W Tuchman",
                    Price = 50,
                    PublishDate = new DateTime(1994, 04, 1)
                },
                new BookModel
                {
                    BookId = 5,
                    Name = "The Hobbit",
                    GenreName = "Science Fiction and fantasy",
                    Description =
                    "A masterful fantasy told by the legendary J.R.R. Tolkein",
                    Authors = "J.R.R. Tolkein",
                    Price = 50,
                    PublishDate = new DateTime(1978, 01, 1)
                },
                new BookModel
                {
                    BookId = 6,
                    Name = "Moby Dick",
                    GenreName = "General Fiction and literature",
                    Description =
                    "The latest edition of the classic tale by American writer Herman Melville",
                    Authors = "Herman Melville",
                    Price = 50,
                    PublishDate = new DateTime(1984, 01, 1)
                },
                new BookModel
                {
                    BookId = 7,
                    Name = "The Hitch Hiker's Guide to the Galaxy",
                    GenreName = "Science Fiction and fantasy",
                    Description =
                    "A trilogy in five parts",
                    Authors = "Douglas Adams",
                    Price = 50,
                    PublishDate = new DateTime(1995, 01, 1)
                },
                new BookModel
                {
                    BookId = 8,
                    Name = "The Ecology of the Planted Aquarium",
                    GenreName = "Natural sciences & mathmatics",
                    Description =
                    "A comprehensive guide to the science and biology within our aquariums",
                    Authors = "Diana Walstad",
                    Price = 30,
                    PublishDate = new DateTime(1999, 01, 1)
                },
                new BookModel
                {
                    BookId = 9,
                    Name = "13 Thing That Don't Make Sense",
                    GenreName = "Natural sciences & mathmatics",
                    Description =
                    "A thoughtful look into how science actually works",
                    Authors = "Mighael Brooks",
                    Price = 30,
                    PublishDate = new DateTime(2009, 01, 1)
                },
                new BookModel
                {
                    BookId = 10,
                    Name = "The Road",
                    GenreName = "General Fiction and literature",
                    Description =
                    "A searing, postapocalyptic tale of a father and son's journey",
                    Authors = "Cormac McCarthy",
                    Price = 11,
                    PublishDate = new DateTime(2006, 01, 1)
                }
                );
        }
    }
}