using Autenticacao.Api.Domain.UserContext.Command.Output;
using Autenticacao.Api.Domain.UserContext.Repository;
using Autenticacao.Api.Infra.UserContext.Services;
using Serilog;
namespace Autenticacao.Api.Domain.UserContext.Handler;
public class AuthenticationHandler
{
    private readonly string job = "AuthenticationHandler";
    private IUserRepository _userRepository;
    private TokenService _tokenService;
    public AuthenticationHandler(
        IUserRepository userRepository,
        TokenService tokenService)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
    }

    public AuthenticatedUserModel Handler(string email, string password)
    {
        AuthenticatedUserModel authenticated;

        Log.Information($"{job} - Iniciando processamento em {DateTime.Now}");
        var user = _userRepository.GetUserAsync(email, password);

        if (user == null)
        {
            Log.Information($"{job} - Usuário ou senha inválidos.");
            return null;
        }

        var token = _tokenService.GenerateToken(user);

        authenticated = new AuthenticatedUserModel
        {
            Id = user.Id,
            Email = user.Email,
            Role = user.Role,
            Password = "",
            Token = token
        };

        return authenticated;
    }
}
