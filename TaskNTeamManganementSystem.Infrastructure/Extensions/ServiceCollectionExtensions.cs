using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskNTeamManganementSystem.Application.Interfaces;
using TaskNTeamManganementSystem.Infrastructure.Persistent.Data;
using TaskNTeamManganementSystem.Infrastructure.Repositories;

namespace TaskNTeamManganementSystem.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    config.GetConnectionString("TaskNTeamManagementSystemCS"),
                    sql => sql.MigrationsAssembly("TaskNTeamManganementSystem")
                )
            );


            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(config.GetConnectionString("TaskNTeamManagementSystemCS")));

            //services.AddScoped<IDbConnection>(sp =>
            //    new SqlConnection(config.GetConnectionString("TaskNTeamManagementSystemCS")));


            //services.AddScoped<ICustomDBConnection, CustomDBConnection>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITeamRepository, TeamRepository>();
            return services;
        }
    }
}
