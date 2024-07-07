using Autenticacao.Api.CrossCutting.Configuration;
using Autenticacao.Api.Domain.UserContext.Repository;
using Autenticacao.Api.Infra.UserContext.Repository;
using Microsoft.Extensions.Options;
namespace Autenticacao.Api.CrossCutting.Injections;
public static class Repositories
{
    public static IServiceCollection InjectRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        var sqlConn = configuration.GetSection(DataBaseConfiguration.Key).Get<DataBaseConfiguration>();
        services.AddTransient<IUserRepository, UserRepository>(x =>
        {
            var optionConfig = x.GetRequiredService<IOptions<DataBaseConfiguration>>();
            return new UserRepository( optionConfig);
        });

        return services;
    }
}
