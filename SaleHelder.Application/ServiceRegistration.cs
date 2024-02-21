using Microsoft.Extensions.DependencyInjection;
using SaleHelder.Application.Interfaces.Services;
using SaleHelder.Application.Services;

namespace SaleHelder.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddTransient<ICategoryService,CategoryService>();
            services.AddTransient<IUserService,UserService>();
            services.AddTransient<IFaqService,FaqService>();
            services.AddTransient<IIssueService,IssueService>();    
            services.AddTransient<IDepartmentService,DepartmentService>();


        }
    }
}
