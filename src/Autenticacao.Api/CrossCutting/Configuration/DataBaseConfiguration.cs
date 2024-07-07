namespace Autenticacao.Api.CrossCutting.Configuration;
public class DataBaseConfiguration
{
    public const string Key = "DataBase";
    public string? ConnString { get; set; }
    public override string ToString()
    {
        string connString = string.Format($"{ConnString}");
        return connString;
    }
}