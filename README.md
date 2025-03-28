# 🛒 DEFINEX .NET BOOTCAMP | E-Ticaret Mikroservis Projesi

Bu proje, **Definex** ve **Coderspace** iş birliğiyle düzenlenen 1 aylık yoğun .NET Bootcamp sürecinin final projesi olarak geliştirilmiştir.  
Amaç, gerçek dünya senaryolarına uygun olarak modern teknolojilerle ölçeklenebilir bir e-ticaret sistemi tasarlamaktı.

Frontend tarafında **Nuxt (Vue.js)**, backend tarafında ise **.NET Core** kullanılarak, **mikroservis mimarili bir demo e-ticaret uygulaması** oluşturulmuştur.

Bu süreçte yalnızca teknik bilgiler değil, aynı zamanda yazılım mimarisi, proje yönetimi gibi konularda da önemli kazanımlar elde ettim.  
💡 Projeye katkı sağlayan değerli bilgi ve yaklaşımları için **İbrahim Gökyar** hocama,  
bu imkânı sağlayan **Coderspace** ve **Definex** ekibine teşekkür ederim.
## 🚀 Kurulum ve Başlatma

Projeyi bilgisayarınıza klonladıktan sonra aşağıdaki adımları takip ederek sistemi çalıştırabilirsiniz.  
Admin girişi için gerekli bilgiler:

> 👤 **Admin Username:** `admin`  
> 🔒 **Admin Password:** `admin123`

---

### 🖥️ Frontend (Nuxt.js)

Client klasörüne girin ve aşağıdaki komutları çalıştırın:

```bash
cd ecommerce-client
npm install
npm run dev
```

Uygulama varsayılan olarak `http://localhost:3000` adresinde çalışacaktır.

---

### ⚙️ Backend (.NET Core Mikroservisler)

Backend tarafında her servisin ayrı ayrı build edilip çalıştırılması gerekir. Örneğin:

```bash
cd /Gateway
dotnet run

cd Services/Identity
dotnet run

cd Services/ProductApi

cd Services/MessageService
dotnet run
```

  
> API Gateway varsayılan olarak `http://localhost:5000` adresinde çalışacaktır. SignalR için `http://localhost:5003` adresiyle haberleşiliyor.



## 🧰 Kullanılan Teknolojiler
### Frontend (Client)
- **Nuxt.js** 
- **Pinia** 
- **Axios** 
- **Bootstrap**
- **Swiper**

### 🔧 Backend (Server)
- **.NET Core** 
- **SignalR**
- **Entity Framework Core (EF Core)** 
- **PostgreSQL** 
- **Ocelot** 

### Diğer Araçlar & Entegrasyonlar
- **Cloudinary**

## Ekran Görüntüleri
![Ekran görüntüsü 2025-03-28 194622](https://github.com/user-attachments/assets/615c871f-ae71-47be-a730-12020d8d0401)
![Ekran görüntüsü 2025-03-28 194641](https://github.com/user-attachments/assets/5889c89d-71ee-4fa4-8499-312d82413d6a)
![Ekran görüntüsü 2025-03-28 194701](https://github.com/user-attachments/assets/ed7ed3c1-eece-4a73-a75f-465c958f9ff4)
![Ekran görüntüsü 2025-03-28 194814](https://github.com/user-attachments/assets/c5b8bbef-1202-4ab4-b116-f17ffc988677)
  
## Proje Demo
youtube linki: https://youtu.be/uoGm5_ZoU4g
## 📘 Proje Hakkında

Bu Bölümde proje hakkında hangi özellikleri geliştirdiğimi hangi özellikleri ise niye geliştirmediğimi açıklamak isterim. Projeyi sıfırdan herhangi bir template kullanmadan geliştirdim verilen sürede. Dolayısıyla daha iyi yapabileceğim şeyler olduğunu düşünüyorum.

### ✅ Geliştirdiğim Özellikler

-  **Kendi geliştirdiğim Admin Paneli**  
  Ürün ekleme, silme, kullanıcılarla mesajlaşma ve basit bir authentication sistemi içeriyor.

-  **Ürün Yönetimi**  
  Tüm ürünleri listeleme,Filtreleme, kategoriye göre filtreleme ve ürün detay sayfasına yönlendirme işlemleri.

-  **Sepet İşlemleri**  
  Kullanıcılar ürünleri sepete ekleyip çıkarabiliyor.

-  **SignalR Entegrasyonu**  
  Admin ile kullanıcılar arasında gerçek zamanlı mesajlaşma sistemi kuruldu.

-  **Bildirim Sistemi**  
  Kullanıcılara yapılan işlemler sonrası toast mesajlarıyla bilgilendirme yapılmakta.

-  **State Yönetimi için Pinia**  
  Uygulamanın global state yönetiminde Pinia kullanıldı.

-  **Filtreleme Seçenekleri**  
  Tüm ürünler çekildikten sonra üzerinde filtreleme yapılabiliyor.

 - **Dosya Yükleme**  
 Admin panelinden ürün eklerken yüklenilen fotoğrafı bulut sunucuda tutuyorum. (Backendde cloudinary servisi)

---

### 🚧 Henüz Geliştirilmemiş / Eksik Kalan Özellikler
-  **Sepet verileri şu an Local Storage'da tutuluyor**  
  Aslında bu yapı, kullanıcıya ait verilerin veritabanında saklanmasıyla daha güvenli ve sürdürülebilir hale getirilebilir.

-  **Mesaj geçmişi kayboluyor**  
  SignalR entegrasyonu mevcut olsa da, mesajlar kalıcı olarak saklanmıyor. Redis veya benzeri bir cache mekanizması kullanılabilir.

-  **Kullanıcı Arayüzü (UI)**  
  React ile daha tecrübeli olduğum için Vue tarafında UI geliştirmelerine çok fazla odaklanamadım. Temel bir görünümle ilerledim.

-  **Admin Girişi için Yetkilendirme Eksikliği**  
  Şu an admin paneline giriş hardcoded şekilde sağlanıyor. Token servisinden token üretilip cliente gönderiliyor ve saklanıyor. Güvenlik açısından (xss) tokenı çerezlerle gönderebilirdim.
