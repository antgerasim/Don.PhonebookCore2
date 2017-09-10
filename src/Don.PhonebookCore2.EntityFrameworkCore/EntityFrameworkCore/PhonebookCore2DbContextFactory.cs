using Don.PhonebookCore2.Configuration;
using Don.PhonebookCore2.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Don.PhonebookCore2.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class PhonebookCore2DbContextFactory : IDesignTimeDbContextFactory<PhonebookCore2DbContext>
    {
        public PhonebookCore2DbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<PhonebookCore2DbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            PhonebookCore2DbContextConfigurer.Configure(builder, configuration.GetConnectionString(PhonebookCore2Consts.ConnectionStringName));

            return new PhonebookCore2DbContext(builder.Options);
        }
    }
}