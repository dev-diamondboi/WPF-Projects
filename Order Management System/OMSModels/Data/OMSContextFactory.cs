using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace OMSModels.Data
{
    public class OMSContextFactory : IDesignTimeDbContextFactory<OMSContext>
    {
        public OMSContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<OMSContext>();
            optionsBuilder.UseSqlServer(
                "Server=localhost\\SQLEXPRESS;Database=OMS_FINAL;Trusted_Connection=True;TrustServerCertificate=True;",
                sqlOptions => sqlOptions.EnableRetryOnFailure()
            );
            return new OMSContext(optionsBuilder.Options);
        }

        public static DbContextOptions<OMSContext> CreateDbOptions()
        {
            var optionsBuilder = new DbContextOptionsBuilder<OMSContext>();
            optionsBuilder.UseSqlServer(
                "Server=localhost\\SQLEXPRESS;Database=OMS_FINAL;Trusted_Connection=True;TrustServerCertificate=True;",
                sqlOptions => sqlOptions.EnableRetryOnFailure()
            );
            return optionsBuilder.Options;
        }
    }
}
