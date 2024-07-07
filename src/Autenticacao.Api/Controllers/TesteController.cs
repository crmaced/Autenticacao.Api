using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Autenticacao.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class TesteController : ControllerBase
{
    [HttpGet("Anonimo")]
    [AllowAnonymous]
    public string Anonymous() => "Anônimo";

    [HttpGet("Autenticado")]
    [Authorize]
    public string Authenticated() => String.Format($"Usuário Autenticado - {User.Identity.Name}");

    [HttpGet("Gestao")]
    [Authorize (Roles = "admin, sindico")]
    public string Gestao() => String.Format($"Usuário de Gestão Autenticado - {User.Identity.Name}");

    [HttpGet("Admin")]
    [Authorize(Roles = "admin")]
    public string Admin() => String.Format($"Usuário de Admin Autenticado - {User.Identity.Name}");



}
