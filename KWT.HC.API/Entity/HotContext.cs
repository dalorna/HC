using Microsoft.EntityFrameworkCore;

namespace KWT.HC.API.Entity
{
    public class HotContext : DbContext
    {
        private string _connection;
        public HotContext(string connection)
        {
            _connection = connection;
        }

        public DbSet<HC_User> HC_User { get; set; }
        public DbSet<Turbine> Turbine { get; set; }
        public DbSet<TurbineLoad> TurbineLoad { get; set; }
        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<ScheduleTurbine> ScheduleTurbine { get; set; }
        public DbSet<ScheduleDay> ScheduleDay { get; set; }
        public DbSet<TurbineTime> TurbineTime { get; set; }
        public DbSet<TurbineData> TurbineData { get; set; }
        public DbSet<TurbineHour> TurbineHour { get; set; }
        public DbSet<GraphOption> GraphOption { get; set; }
        public DbSet<ActivityNote> ActivityNote { get; set; }
        public DbSet<Logo> Logo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseSqlServer(_connection);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TurbineData>().HasNoKey().ToView(null);
            modelBuilder.Entity<TurbineHour>().HasNoKey().ToView(null);
        }
   
    }
}
