# 🚗 RentCar API

Bu proje, araç kiralama süreçlerini yönetmek için geliştirilmiş bir **ASP.NET Core Web API** uygulamasıdır. JWT tabanlı kimlik doğrulama, katmanlı mimari, Entity Framework Core ve temiz kod prensipleriyle yapılandırılmıştır.

## 🔧 Kullanılan Teknolojiler

- ASP.NET Core Web API
- Entity Framework Core
- JWT Authentication
- Onion Architecture (Clean Architecture yaklaşımıyla)
- SQL Server
- Swagger UI

## 📁 Proje Mimarisi

Proje, SOLID prensipleri ve temiz mimari yaklaşımıyla aşağıdaki katmanlara ayrılmıştır:

- `RentCar.API` → API katmanı (Controller’lar burada)
- `RentCar.Application` → İş kuralları ve servis arayüzleri (DTO'lar, Interface'ler)
- `RentCar.Domain` → Temel domain modelleri ve entity’ler
- `RentCar.Persistence` → Veritabanı işlemleri (DbContext, EF Core konfigurasyonları)

## 🔐 Kimlik Doğrulama

Proje, JWT (JSON Web Token) ile kullanıcı doğrulaması sağlar. Kullanıcı giriş yaptıktan sonra kendisine token verilir ve bu token ile yetkili işlemleri gerçekleştirebilir.

## 🚀 Nasıl Başlatılır?

1. **Veritabanını ayarla:** `appsettings.json` dosyasındaki bağlantı ayarlarını yap.
2. **Migration oluştur (isteğe bağlı):**
   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
