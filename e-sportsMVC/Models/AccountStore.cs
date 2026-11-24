using System.Text.Json;
using Microsoft.AspNetCore.Identity;
namespace e_sportsMVC.Models
{
    public class AccountRecord
    {
        public int Id { get; set; }
        public string FullName { get; set; } = "";
        public string Email { get; set; } = "";
        public string PasswordHash { get; set; } = "";
    }
    public static class AccountStore
    {
        private static readonly object Sync = new();
        private static readonly string FilePath = Path.Combine(AppContext.BaseDirectory, "App_Data", "accounts.json");
        private static readonly PasswordHasher<AccountRecord> Hasher = new();
        private static List<AccountRecord>? _accounts;
        private static List<AccountRecord> Accounts
        {
            get {
                if (_accounts != null) return _accounts;
                Directory.CreateDirectory(Path.GetDirectoryName(FilePath)!);
                _accounts = File.Exists(FilePath) ? JsonSerializer.Deserialize<List<AccountRecord>>(File.ReadAllText(FilePath)) ?? new() : new();
                return _accounts;
            }
        }
        private static void Save() {
            Directory.CreateDirectory(Path.GetDirectoryName(FilePath)!);
            File.WriteAllText(FilePath, JsonSerializer.Serialize(Accounts, new JsonSerializerOptions { WriteIndented = true }));
        }
        public static AccountRecord? FindByEmail(string email) {
            lock (Sync) return Accounts.FirstOrDefault(a => a.Email.Equals(email.Trim(), StringComparison.OrdinalIgnoreCase));
        }
        public static bool Register(string name, string email, string password) {
            lock (Sync) {
                email = email.Trim();
                if (Accounts.Any(a => a.Email.Equals(email, StringComparison.OrdinalIgnoreCase))) return false;
                var user = new AccountRecord { Id = Accounts.Count == 0 ? 1 : Accounts.Max(a => a.Id) + 1, FullName = name.Trim(), Email = email };
                user.PasswordHash = Hasher.HashPassword(user, password);
                Accounts.Add(user); Save(); return true;
            }
        }
        public static bool VerifyPassword(AccountRecord user, string password) =>
            Hasher.VerifyHashedPassword(user, user.PasswordHash, password) != PasswordVerificationResult.Failed;
    }
}