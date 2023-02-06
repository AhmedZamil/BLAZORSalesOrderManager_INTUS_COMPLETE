using SalesOrderManager.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace SalesOrderManager.DAL
{
    public class AppDbContext : DbContext
    {

        //private readonly IConfiguration _config;
        //public AppDbContext(IConfiguration config)
        //{
        //    _config = config;
        //}

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Window> Windows { get; set; }
        public DbSet<SubElement> SubElements { get; set; }
        public DbSet<State> States { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder bldr)
        {
            base.OnConfiguring(bldr);

            bldr.UseSqlServer(@"Server=.;Database=SalesOrderManagerNew;Trusted_Connection=True;MultipleActiveResultSets=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //seed categories
            modelBuilder.Entity<State>().HasData(new State { StateId = 1, Name = "AL" });
            modelBuilder.Entity<State>().HasData(new State { StateId = 2, Name = "AK" });
            modelBuilder.Entity<State>().HasData(new State { StateId = 3, Name = "AZ" });
            modelBuilder.Entity<State>().HasData(new State { StateId = 4, Name = "AR" });
            modelBuilder.Entity<State>().HasData(new State { StateId = 5, Name = "CA" });
            modelBuilder.Entity<State>().HasData(new State { StateId = 6, Name = "CO" });
            modelBuilder.Entity<State>().HasData(new State { StateId = 7, Name = "CT" });
            modelBuilder.Entity<State>().HasData(new State { StateId = 8, Name = "DE" });
            modelBuilder.Entity<State>().HasData(new State { StateId = 9, Name = "DC" });
            modelBuilder.Entity<State>().HasData(new State { StateId = 10, Name = "FL" });
            modelBuilder.Entity<State>().HasData(new State { StateId = 11, Name = "GA" });
            modelBuilder.Entity<State>().HasData(new State { StateId = 12, Name = "HI" });
            modelBuilder.Entity<State>().HasData(new State { StateId = 13, Name = "ID" });
            modelBuilder.Entity<State>().HasData(new State { StateId = 14, Name = "IL" });

            modelBuilder.Entity<State>().HasData(new State { StateId = 15, Name = "IN" });
            modelBuilder.Entity<State>().HasData(new State { StateId = 16, Name = "IA" });
            modelBuilder.Entity<State>().HasData(new State { StateId = 17, Name = "KS" });
            modelBuilder.Entity<State>().HasData(new State { StateId = 18, Name = "KY" });
            modelBuilder.Entity<State>().HasData(new State { StateId = 19, Name = "LA" });
            modelBuilder.Entity<State>().HasData(new State { StateId = 20, Name = "ME" });
            modelBuilder.Entity<State>().HasData(new State { StateId = 21, Name = "MD" });
            modelBuilder.Entity<State>().HasData(new State { StateId = 22, Name = "MA" });
            modelBuilder.Entity<State>().HasData(new State { StateId = 23, Name = "MI" });
            modelBuilder.Entity<State>().HasData(new State { StateId = 24, Name = "MN" });
            modelBuilder.Entity<State>().HasData(new State { StateId = 25, Name = "MS" });
            modelBuilder.Entity<State>().HasData(new State { StateId = 26, Name = "MO" });
            modelBuilder.Entity<State>().HasData(new State { StateId = 27, Name = "MT" });
            modelBuilder.Entity<State>().HasData(new State { StateId = 28, Name = "NY" });

            modelBuilder.Entity<SubElement>().HasData(new SubElement
            {
                SubElementId = 1,
                ElementType = ElementType.Doors.ToString(),
                Element = 1,
                Width = 1200,
                Height = 1850,
                WindowId = 1
            });

            modelBuilder.Entity<SubElement>().HasData(new SubElement
            {
                SubElementId = 2,
                ElementType = ElementType.Window.ToString(),
                Element = 2,
                Width = 800,
                Height = 1850,
                WindowId = 1
            });

            modelBuilder.Entity<SubElement>().HasData(new SubElement
            {
                SubElementId = 3,
                ElementType = ElementType.Window.ToString(),
                Element = 3,
                Width = 700,
                Height = 1850,
                WindowId = 1

            });

            modelBuilder.Entity<SubElement>().HasData(new SubElement
            {
                SubElementId = 4,
                ElementType = ElementType.Window.ToString(),
                Element = 1,
                Width = 1500,
                Height = 2000,
                WindowId = 2
            });

            modelBuilder.Entity<SubElement>().HasData(new SubElement
            {
                SubElementId = 5,
                ElementType = ElementType.Doors.ToString(),
                Element = 1,
                Width = 1400,
                Height = 2200,
                WindowId = 3
            });

            modelBuilder.Entity<SubElement>().HasData(new SubElement
            {
                SubElementId = 6,
                ElementType = ElementType.Window.ToString(),
                Element = 2,
                Width = 600,
                Height = 2200,
                WindowId = 3
            });

            modelBuilder.Entity<SubElement>().HasData(new SubElement
            {
                SubElementId = 7,
                ElementType = ElementType.Window.ToString(),
                Element = 1,
                Width = 1500,
                Height = 2000,
                WindowId = 4
            });

            modelBuilder.Entity<SubElement>().HasData(new SubElement
            {
                SubElementId = 8,
                ElementType = ElementType.Window.ToString(),
                Element = 1,
                Width = 1500,
                Height = 2000,
                WindowId = 4
            });



            modelBuilder.Entity<Window>().HasData(new Window
            {
                WindowId = 1,
                Name = "A51",
                QuantityOfWindows = 4,
                TotalSubElements = 3,
                OrderId = 1
            });
            modelBuilder.Entity<Window>().HasData(new Window
            {
                WindowId = 2,
                Name = "C Zone 5",
                QuantityOfWindows = 2,
                TotalSubElements = 1,
                OrderId = 1
            });
            modelBuilder.Entity<Window>().HasData(new Window
            {
                WindowId = 3,
                Name = "GLB",
                QuantityOfWindows = 3,
                TotalSubElements = 2,
                OrderId = 2
            });

            modelBuilder.Entity<Window>().HasData(new Window
            {
                WindowId = 4,
                Name = "OHF",
                QuantityOfWindows = 10,
                TotalSubElements = 2,
                OrderId = 2
            });



            modelBuilder.Entity<Order>().HasData(new Order
            {
                OrderId = 1,
                StateId = 28,
                Name= "New York Building 1",
            });

            modelBuilder.Entity<Order>().HasData(new Order
            {
                OrderId = 2,
                StateId = 5,
                Name = "California Hotel AJK",
            });
        }
    }
}
