using Autenticacao.Api.CrossCutting.Configuration;
using Autenticacao.Api.Domain.UserContext.Models;
using Autenticacao.Api.Domain.UserContext.Repository;
using Microsoft.Extensions.Options;
namespace Autenticacao.Api.Infra.UserContext.Repository;

public class UserRepository : IUserRepository
{
    private readonly DataBaseConfiguration _config;
    public UserRepository (IOptions<DataBaseConfiguration> configuration) => _config = configuration.Value;

    public UserModel GetUserAsync(string email, string password)
    {
        var users = new List<UserModel>()
        {
            new() {Id = 1, Nome = "Admin", Email = "admin@alvori.com.br", Password = "Cris@1234", Role = "admin" },
            new() {Id = 2, Nome = "Sindico", Email = "sindico@teste.com", Password = "Cris@1234", Role = "sindico" },
            new() {Id = 3, Nome = "Cliente", Email = "cliente@teste.com", Password = "Cris@1234", Role = "cliente" },
            new() {Id = 4, Nome = "Inadimplente", Email = "inadimplente@teste.com", Password = "Cris@1234", Role = "inadimplente" }
        };
        return users
            .FirstOrDefault(u => u.Email == email.ToLower()  && u.Password == password);
    }
}
