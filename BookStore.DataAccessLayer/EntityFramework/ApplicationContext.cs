using BookStore.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DataAccessLayer.EntityFramework
{
    public class ApplicationContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Magazine> Magazines { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<MagazineOrder> MagazoneOrders { get; set; }
        public DbSet<BookOrder> BookOrders { get; set; }
        public DbSet<MainOrder> MainOrders { get; set; }


        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
           : base(options)
        { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-47T6FVE\\SQLEXPRESS;Initial Catalog=IonicTest; Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BookAuthor>()
                .HasKey(x => new { x.BookId, x.AuthorId });

            modelBuilder.Entity<MagazineOrder>()
                .HasKey(x => new { x.MagazineId, x.UserId });
            modelBuilder.Entity<BookOrder>()
                .HasKey(x => new { x.BookId, x.UserId });

        }   

    }
    
}

