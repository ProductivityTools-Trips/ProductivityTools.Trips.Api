using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ProductivityTools.Trips.Api.Db
{
    public class TripContext :DbContext
    {

        private readonly IConfiguration Configuration; 

        public TripContext(IConfiguration conf)
        {
            this.Configuration = conf;
        }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseFullView> ExpensesFullView { get; set; }
        public DbSet<Currency> Currency { get; set; }

        public DbSet<Category> Category { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = Configuration["ConnectionString"];
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trip>().ToTable("Trip", "t").HasKey("TripId");

            modelBuilder.Entity<Expense>().ToTable("Expense", "t").HasKey("ExpenseId");
            modelBuilder.Entity<Expense>().Property(x => x.Name).IsRequired(false);

            modelBuilder.Entity<Currency>().ToTable("Currency", "t").HasKey("CurrencyId");
            modelBuilder.Entity<Category>().ToTable("Category", "t").HasKey("CategoryId");

            modelBuilder.Entity<ExpenseFullView>().ToView("ExpenseFullView", "t").HasKey("ExpenseId");

            base.OnModelCreating(modelBuilder);
        }
    }
}