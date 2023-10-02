using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RoleBased.Core;
using RoleBased.Core.Mapping;
using RoleBased.Infractructure.Presistance;
using RoleBased.Repository.Concrete;
using RoleBased.Repository.Interface;

namespace RoleBased.IoC.Configuration;
public static class ServiceCollectionExtention
{
    public static IServiceCollection MapCore(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<RoleBasedDbContext>(option =>
        {
            option.UseSqlServer(configuration.GetConnectionString("Conn"));
            option.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking); // I add This (this is for if update is not working. because dbconn trtacks all data, so sometime it restrict to update same data)
        });

        services.AddAutoMapper(typeof(MappingExtention).Assembly);

        services.AddTransient<IStudentInfoRepository,StudentInfoRepository>();
        services.AddTransient<ILoginDbRepository,LoginDbRepository>();

        services.AddValidatorsFromAssembly(typeof(ICore).Assembly);

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(typeof(ICore).Assembly);
            //validation register
            //cfg.AddBehavior(typeof(IPipelineBehavior<,>));
        });
        //new end

        return services;
    }
}
