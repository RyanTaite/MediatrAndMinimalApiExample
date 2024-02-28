using FluentValidation;
using MediatR.Persistence.Members;
using MediatR.Persistence.Members.Interfaces;
using MediatR.ServiceLayer.MemberAttendance;
using MediatR.ServiceLayer.MemberAttendance.Interfaces;
using MediatR.ServiceLayer.Members;
using MediatR.ServiceLayer.Members.Interfaces;

namespace MediatR.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
    {
        RegisterRepos(services);
        RegisterServices(services);
        RegisterFluentValidators(services);
        RegisterMediatR(services);

        return services;
    }

    private static void RegisterServices(IServiceCollection services)
    {
        // Add DI for services here
        services.AddScoped<IMembersService, MembersService>();
        services.AddScoped<IMemberAttendanceService, MemberAttendanceService>();
    }

    private static void RegisterRepos(IServiceCollection services)
    {
        // Add DI for repos here
        services.AddScoped<IMembersRepo, MembersRepo>();
    }

    private static void RegisterMediatR(IServiceCollection services)
    {
        // Learned a lot from https://q.agency/blog/simplifying-complexity-with-mediatr-and-minimal-apis/
        // Had I kept the services that use MediatR in one project, this would have worked for registering MediatR
        // builder.Services.AddMediatR(mediatRServiceConfiguration => {
        //     mediatRServiceConfiguration.RegisterServicesFromAssembly(typeof(Program).Assembly);
        // });
        // Since I have moved out the services that use MediatR into their own projects, this will scan each project
        // assemblies for projects that use MediatR and register them
        foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            services.AddMediatR(mediatRServiceConfiguration => mediatRServiceConfiguration.RegisterServicesFromAssembly(assembly));
        }
    }

    private static void RegisterFluentValidators(IServiceCollection services)
    {
        //services.AddScoped<IValidator<UpdateAttendanceCommand>, UpdateAttendanceCommandValidator>();
        
        // Following this guide: https://docs.fluentvalidation.net/en/latest/di.html#automatic-registration
        foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            // Load an assembly reference rather than using a marker type.
            services.AddValidatorsFromAssembly(assembly);
        }
    }
}