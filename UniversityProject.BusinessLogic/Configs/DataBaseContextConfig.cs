using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UniversityProject.DataAccess.DataAccept;
using UniversityProject.Shared.Constants;

namespace UniversityProject.BusinessLogic.Configs
{
    public static class DataBaseContextConfig
    {
        public static void InjectDataBase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString(ApplicationConstants.LOCALHOST_CONNECTION_STRING_NAME)));
        }
    }
}