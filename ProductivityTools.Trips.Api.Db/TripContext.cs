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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = Configuration["ConnectionString"];
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trip>().ToTable("Bag", "mw").HasKey("BagID");
            modelBuilder.Entity<Expense>().ToTable("Expense", "mw").HasKey("ExpenseID");
            modelBuilder.Entity<Expense>().Property(x => x.Name).IsRequired(false);
            base.OnModelCreating(modelBuilder);
        }
    }
}