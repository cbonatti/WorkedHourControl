namespace WorkedHourControl.Infra.Authorization
{
    public interface ITokenService
    {
        string GenerateToken(string user, string role);
    }
}