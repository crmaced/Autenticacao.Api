namespace Autenticacao.Api.CrossCutting.Configuration;
public class SecretSettings
{
    public const string Key = "TokenService";
    public string? Secret { get; set; }

    public override string ToString()
    {
        string secret = string.Format($"{Secret}");
        return secret;
    }
}
