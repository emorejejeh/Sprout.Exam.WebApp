using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Sprout.Exam.DataAccess.Models;

namespace Sprout.Exam.DataAccess.Data
{
    public class EmployeeDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public EmployeeDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<Employee> Employee { get; set; }


    }
}
