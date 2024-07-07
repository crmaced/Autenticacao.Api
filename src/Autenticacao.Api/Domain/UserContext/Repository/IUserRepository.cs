using Autenticacao.Api.Domain.UserContext.Models;
namespace Autenticacao.Api.Domain.UserContext.Repository;
public interface IUserRepository
{
    public UserModel GetUserAsync(string email, string password);
}
