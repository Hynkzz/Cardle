using System;
using System.Linq;
using System.Threading.Tasks;
using Cardle.Data;   // Veritabanı için
using Cardle.Models; // User modeli için

namespace Cardle.Services;

public class AuthService
{
    private readonly AppDbContext _context; // Veritabanı bağlantısı

    // Constructor (Veritabanını içeri alıyoruz)
    public AuthService(AppDbContext context)
    {
        _context = context;
    }

    // O anki giriş yapmış kullanıcı
    public User? CurrentUser { get; private set; }

    // Giriş yapıldı mı kontrolü
    public bool IsLoggedIn => CurrentUser != null;

    // Admin mi kontrolü
    public bool IsAdmin => CurrentUser?.Role == "Admin";

    // Sayfaların haberdar olması için Olay (Event)
    public event Action? OnChange;

    public async Task InitializeAsync()
    {
        await Task.CompletedTask;
    }

    // GİRİŞ YAPMA (Login.razor burayı kullanıyor)
    public bool Login(string username, string password)
    {
        // Veritabanında bu kullanıcı var mı bak
        var user = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

        if (user != null)
        {
            CurrentUser = user;
            NotifyStateChanged(); // Haber ver Giriş yapıldı
            return true; // Başarılı
        }
        return false; // Başarısız
    }

    // KAYIT OLMA (Register.razor burayı kullanıyor)
    public bool Register(string username, string password)
    {
        // Kullanıcı adı zaten var mı?
        if (_context.Users.Any(u => u.Username == username))
        {
            return false;
        }

        // Yeni kullanıcı oluştur
        var newUser = new User 
        { 
            Username = username, 
            Password = password, 
            Role = "User" // Varsayılan rol
        };

        _context.Users.Add(newUser);
        _context.SaveChanges();

        // Kayıt olunca otomatik giriş de yapsın
        CurrentUser = newUser;
        NotifyStateChanged();
        return true;
    }

    // Çıkış İşlemi
    public void Logout()
    {
        CurrentUser = null;
        NotifyStateChanged();
    }

    // Durum değişince abone olan sayfaları tetikle
    private void NotifyStateChanged() => OnChange?.Invoke();
}