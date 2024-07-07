using Autenticacao.Api.Domain.UserContext.Command.Input;
using Autenticacao.Api.Domain.UserContext.Command.Output;
using Autenticacao.Api.Domain.UserContext.Handler;
using Microsoft.AspNetCore.Mvc;
namespace Autenticacao.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class TokenController : ControllerBase
{
    [HttpPost("Authenticator")]
    public async Task<ActionResult<AuthenticatedUserModel>> AuthenticateAsync(
        [FromBody] LoginModel login, [FromServices] AuthenticationHandler handler)
    {
        var result = handler.Handler(login.Email, login.Password);

        return result == null ? 
            NotFound(new { message = "Usuário ou senha inválidos." }) : 
            Ok(new { message = "Usuário Autenticado", data = result });
    }
}
