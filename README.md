# 🚗 Cardle – Araç Tahmin Oyunu

Cardle, kullanıcıların araçları tahmin etmeye çalıştığı, ASP.NET Core tabanlı bir web uygulamasıdır.  
Proje, **Web Programlama** dersi final projesi kapsamında geliştirilmiştir.

---

## 🎯 Projenin Amacı

Bu projenin amacı, bir web uygulamasını:
- Baştan sona planlamak
- Backend + frontend birlikte geliştirmek
- Gerçek bir veritabanı ile çalışmak
- Bir sunucuya canlı olarak deploy etmek
- Yazılım geliştirme sürecini raporlamak

ve öğrencinin **tam bir full-stack geliştirme sürecini** deneyimlemesini sağlamaktır.

---

## 🛠️ Kullanılan Teknolojiler

- **Backend:** ASP.NET Core 8 (Blazor Server)
- **Frontend:** HTML5, CSS3, Razor Components
- **Veritabanı:** SQLite (Entity Framework Core)
- **ORM:** Entity Framework Core
- **Sunucu:** Linux VM
- **Deployment:** Docker + Nginx
- **Versiyon Kontrol:** Git & GitHub
- **Alan Adı & SSL:** Cloudflare

---

## 🧱 Mimari Yapı

Proje, MVC benzeri bir mimari kullanmaktadır:

Cardle
│
├── Models/ → Veritabanı modelleri (Car, User, Score)
├── Services/ → İş mantığı (GameService, AuthService)
├── Components/ → Razor sayfaları (UI)
├── Data/ → DbContext ve EF yapılandırması
├── wwwroot/ → CSS, JS, resimler
└── Program.cs → Uygulama başlangıç noktası

---

## 🗃️ Veritabanı Yapısı (Özet)

### Cars Tablosu
| Alan | Açıklama |
|----|----|
| Id | Primary Key |
| Brand | Marka |
| Model | Model |
| Body | Kasa tipi |
| Country | Üretim ülkesi |
| ImageUrl | Araç görseli |

### Users Tablosu
| Alan | Açıklama |
|----|----|
| Id | Primary Key |
| Username | Kullanıcı adı |
| Password | Şifre |
| Role | Kullanıcı rolü |

### Scores Tablosu
| Alan | Açıklama |
|----|----|
| Id | Primary Key |
| Username | Kullanıcı |
| GameMode | Oyun modu |
| Score | Puan |

---

## 🔁 CRUD İşlemleri

Uygulamada aşağıdaki CRUD işlemleri yapılmaktadır:

- **Create:** Kullanıcı oluşturma, skor ekleme
- **Read:** Araç listesi, leaderboard, skorlar
- **Update:** Oyun durumu ve skor güncelleme
- **Delete:** Oyun resetleme / veri temizleme

Tüm işlemler **gerçek bir veritabanı** üzerinde yapılmaktadır.

---

## 🎮 Oyun Modları

- **Klasik Mod:**  
  Her gün aynı araç gelir, günlük yenilenir.
- **Sonsuz Mod:**  
  Arka arkaya tahmin yapılır.
- **Görsel Mod:**  
  Yakınlaştırılmış araç görselinden tahmin yapılır.
- **Leaderboard:**  
  En iyi oyuncular listelenir.

---

## 🌍 Canlı Yayın (Deployment)

Proje canlı olarak yayındadır:
-hasan.osdev.shop

- Docker container içinde çalışır
- Uygulama **localhost:5000** üzerinden dinlenir
- Nginx reverse proxy ile **80/443** portlarından yayınlanır
- Alan adı Cloudflare üzerinden yönlendirilmiştir

---


## 🧪 Form Validasyonları & UX

- Boş alan kontrolleri
- Responsive tasarım (mobil uyumlu)
- Kullanıcı dostu arayüz
- Anlamlı navigasyon

---


