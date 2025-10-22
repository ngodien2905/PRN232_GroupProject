namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<string> RegisterAsync(string username, string password, string role);
        Task<string> LoginAsync(string username, string password);
    }
}
