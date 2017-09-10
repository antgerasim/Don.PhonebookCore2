using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Don.PhonebookCore2.EntityFrameworkCore
{
    public static class PhonebookCore2DbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<PhonebookCore2DbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<PhonebookCore2DbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}