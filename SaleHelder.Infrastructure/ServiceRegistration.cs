using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Data;
using SaleHelder.Application.Interfaces.Repositories;
using SaleHelder.Infrastructure.Repositories;

namespace SaleHelder.Application
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {

            #region context
            services.AddDbContext<DataContext>(options =>
           options.UseSqlServer(configuration.GetConnectionString("SqlLocalConnection"),
           m => m.MigrationsAssembly(typeof(DataContext).Assembly.FullName)));
            #endregion

            #region repositories
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<IFaqRepository, FaqRepository>();
            services.AddTransient<IIssueRepository, IssueRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            #endregion
        }
    }
}
