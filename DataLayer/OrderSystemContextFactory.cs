using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataLayer
{
    internal class OrderSystemContextFactory : IDesignTimeDbContextFactory<OrderSystemContext>
    {
        private readonly string _connectionString =
            "Data Source=(localdb)\\MSSQLLocalDB;" +
            "Initial Catalog=OrderSystem;" +
            "Integrated Security=True;" +
            "Connect Timeout=30;" +
            "Encrypt=False;" +
            "TrustServerCertificate=False;" +
            "ApplicationIntent=ReadWrite;" +
            "MultiSubnetFailover=False";

        public OrderSystemContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<OrderSystemContext>();

            optionsBuilder.UseSqlServer(_connectionString)
                .UseLazyLoadingProxies();

            return new OrderSystemContext(optionsBuilder.Options);
        }
    }
}
