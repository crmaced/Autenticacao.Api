namespace Autenticacao.Api.Domain.UserContext.Command.Output;
public class AuthenticatedUserModel
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
    public string Token {  get; set; }
}
