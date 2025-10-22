using Application.Interfaces;
using Domain.Entities;
using Domain.Enum;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly AuthDbContext _db;
        public UserService(AuthDbContext db) { _db = db; }

        private static string Hash(string pwd) => Convert.ToBase64String(System.Security.Cryptography.SHA256.HashData(Encoding.UTF8.GetBytes(pwd)));

        public async Task<string> RegisterAsync(string username, string password, string role)
        {
            if (await _db.Users.AnyAsync(u => u.Username == username)) throw new Exception("username taken");
            var u = new User { Username = username, PasswordHash = Hash(password), Role = Enum.Parse<UserRole>(role, true) };
            _db.Users.Add(u);
            await _db.SaveChangesAsync();
            return $"registered:{u.UserId}";
        }

        public async Task<string> LoginAsync(string username, string password)
        {
            var h = Hash(password);
            var u = await _db.Users.FirstOrDefaultAsync(x => x.Username == username && x.PasswordHash == h);
            if (u == null) throw new Exception("invalid credentials");
            return $"ok:{u.UserId}";
        }
    }
}
