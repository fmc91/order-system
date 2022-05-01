using DataLayer.Model;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class OrderSystemContext : DbContext
    {
        public OrderSystemContext(DbContextOptions<OrderSystemContext> options) : base(options) { }

        public DbSet<Address> Address => Set<Address>();

        public DbSet<Carrier> Carrier => Set<Carrier>();

        public DbSet<Category> Category => Set<Category>();

        public DbSet<Contact> Contact => Set<Contact>();

        public DbSet<ContactInformation> ContactInformation => Set<ContactInformation>();

        public DbSet<Country> Country => Set<Country>();

        public DbSet<Customer> Customer => Set<Customer>();

        public DbSet<DistributionCentre> DistributionCentre => Set<DistributionCentre>();

        public DbSet<DistributionCentreAddress> DistributionCentreAddress => Set<DistributionCentreAddress>();

        public DbSet<Order> Order => Set<Order>();

        public DbSet<OrderItem> OrderItem => Set<OrderItem>();

        public DbSet<Product> Product => Set<Product>();

        public DbSet<Region> Region => Set<Region>();

        public DbSet<ShippingAddress> ShippingAddress => Set<ShippingAddress>();

        public DbSet<StockItem> StockItem => Set<StockItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //PRIMARY KEYS

            modelBuilder.Entity<Address>()
                .HasKey(x => x.AddressId);

            modelBuilder.Entity<Carrier>()
                .HasKey(x => x.CarrierId);

            modelBuilder.Entity<Category>()
                .HasKey(x => x.CategoryId);

            modelBuilder.Entity<Contact>()
                .HasKey(x => x.ContactId);

            modelBuilder.Entity<ContactInformation>()
                .HasKey(x => x.ContactInformationId);

            modelBuilder.Entity<Country>()
                .HasKey(x => x.CountryId);

            modelBuilder.Entity<Customer>()
                .HasKey(x => x.CustomerId);

            modelBuilder.Entity<DistributionCentre>()
                .HasKey(x => x.DistributionCentreId);

            modelBuilder.Entity<DistributionCentreAddress>()
                .HasKey(x => new { x.DistributionCentreId, x.AddressId });

            modelBuilder.Entity<Order>()
                .HasKey(x => x.OrderId);

            modelBuilder.Entity<OrderItem>()
                .HasKey(x => new { x.OrderId, x.ProductId });

            modelBuilder.Entity<Product>()
                .HasKey(x => x.ProductId);

            modelBuilder.Entity<Region>()
                .HasKey(x => x.RegionId);

            modelBuilder.Entity<ShippingAddress>()
                .HasKey(x => new { x.CustomerId, x.AddressId });

            modelBuilder.Entity<StockItem>()
                .HasKey(x => new { x.DistributionCentreId, x.ProductId });


            //RELATIONSHIPS

            modelBuilder.Entity<Product>()
                .HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId);

            modelBuilder.Entity<StockItem>()
                .HasOne(x => x.Product)
                .WithMany(x => x.StockItems)
                .HasForeignKey(x => x.ProductId);

            modelBuilder.Entity<StockItem>()
                .HasOne(x => x.DistributionCentre)
                .WithMany()
                .HasForeignKey(x => x.DistributionCentreId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(x => x.Product)
                .WithMany(x => x.OrderItems)
                .HasForeignKey(x => x.ProductId );

            modelBuilder.Entity<OrderItem>()
                .HasOne(x => x.Order)
                .WithMany(x => x.OrderItems)
                .HasForeignKey(x => x.OrderId);

            modelBuilder.Entity<Order>()
                .HasOne(x => x.Carrier)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.CarrierId);

            modelBuilder.Entity<Order>()
                .HasOne(x => x.DistributionCentre)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.DistributionCentreId);

            modelBuilder.Entity<Order>()
                .HasOne(x => x.Customer)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.CustomerId);

            modelBuilder.Entity<Customer>()
                .HasOne(x => x.Region)
                .WithMany(x => x.Customers)
                .HasForeignKey(x => x.RegionId);

            modelBuilder.Entity<Contact>()
                .HasOne<Customer>()
                .WithMany(x => x.Contacts)
                .HasForeignKey(x => x.CustomerId);

            modelBuilder.Entity<ContactInformation>()
                .HasOne<Contact>()
                .WithMany(x => x.ContactInformation)
                .HasForeignKey(x => x.ContactId);

            modelBuilder.Entity<ShippingAddress>()
                .HasOne(x => x.Customer)
                .WithOne(x => x.ShippingAddress)
                .HasForeignKey<ShippingAddress>(x => x.CustomerId);

            modelBuilder.Entity<ShippingAddress>()
                .HasOne(x => x.Address)
                .WithOne()
                .HasForeignKey<ShippingAddress>(x => x.AddressId);

            modelBuilder.Entity<DistributionCentreAddress>()
                .HasOne(x => x.DistributionCentre)
                .WithOne(x => x.DistributionCentreAddress)
                .HasForeignKey<DistributionCentre>(x => x.DistributionCentreId);

            modelBuilder.Entity<DistributionCentreAddress>()
                .HasOne(x => x.Address)
                .WithOne()
                .HasForeignKey<DistributionCentreAddress>(x => x.AddressId);
        }
    }
}