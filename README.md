# 🚀 ASP.NET Core 9.0 ve Dapper ile Kaggle Veri Seti Paneli
Bu repository, M&Y Yazılım Akademi bünyesinde yaptığım dokuzuncu proje olan ASP.NET Core Web App ile Kaggle Kitap Veri Seti Paneli ve Dashboard Uygulaması projesini içermektedir. Bu eğitimde bana yol gösteren Murat Yücedağ'a çok teşekkür ederim.

Bu repository, Kaggle üzerinden elde ettiğim kitap verilerini kullanarak geliştirdiğim ASP.NET Core Web App (.NET 9.0) projesini içermektedir. Bu proje kapsamında modern bir yönetim paneli (Admin Panel) geliştirerek, istatistiksel verilerin grafiklerle sunulmasını ve detaylı veri tablolarının filtrelenebilir, sayfalı olarak gösterilmesini sağladım.

Bu projede, MS SQL veritabanı ile ilişkili olarak kitaplar, kullanıcılar ve puanlama (rating) verileri kullanılmakta olup, farklı görsel grafik bileşenleriyle birlikte anlamlı istatistikler kullanıcıya sunulmaktadır. Ayrıca DataTables ile tablolar üzerinden arama, sayfalama ve satır sayısı kontrolü gibi işlemler sağlanmıştır. Proje, istatistiksel analiz, kitap veri yönetimi ve kullanıcı değerlendirme sistemleri geliştirmek isteyenler için örnek teşkil etmektedir.

Bu projeyi geliştirirken amacım, ASP.NET Core ve Dapper teknolojileriyle modern bir veri paneli geliştirme konusunda kendimi ilerletmek ve sektörel projelere hazır hale gelmekti.

---

### 📁 Proje Modülleri
🔹 Dashboard: Grafikler üzerinden kitap, kullanıcı ve puanlama verileri ile ilgili görsel istatistikler (bar chart, doughnut chart, area chart vb.)<br>
🔹 Books Tablosu: Kitapların listelendiği, arama ve sayfalama özellikli DataTable<br>
🔹 Users Tablosu: Kullanıcıların detaylı listelendiği DataTable<br>
🔹 Ratings Tablosu: Kullanıcıların kitaplara verdiği puanların görüntülendiği tablo<br>
🔹 Görsel Kitap Kartları: Kitap kapaklarının optimize bir şekilde gösterildiği kullanıcı dostu grid yapı<br>

---

## 🗃️ Veri Kümesi Hakkında: Books Dataset (Kaggle)
Bu projede Kaggle’dan alınan "Books Dataset" veri seti kullanılmıştır.<br>
Veri Seti: https://www.kaggle.com/datasets/saurabhbagchi/books-dataset

Veri kümesi üç ayrı tablo içerir:<br>
### 📗 Books Tablosu

| Sütun Adı           | Açıklama                         |
|---------------------|----------------------------------|
| ISBN                | Kitabın benzersiz tanımlayıcısı |
| BookTitle           | Kitabın adı                      |
| BookAuthor          | Yazarın adı                      |
| YearOfPublication   | Yayın yılı                       |
| Publisher           | Yayıncı adı                      |
| ImageUrl            | Kitap kapağının görsel linki    |

🧾 **Satır Sayısı:** Yaklaşık 271,000 kitap verisi

---

### 👤 Users2 Tablosu

| Sütun Adı | Açıklama                |
|-----------|-------------------------|
| User_ID   | Kullanıcının benzersiz ID’si |
| Location  | Kullanıcının konumu     |
| Age       | Kullanıcının yaşı       |

🧾 **Satır Sayısı:** Yaklaşık 275,000 kullanıcı

---

### ⭐ Ratings Tablosu

| Sütun Adı  | Açıklama                         |
|------------|----------------------------------|
| User_ID    | Kullanıcı ID’si (FK)            |
| ISBN       | Kitap ID’si (FK)                |
| BookRating | 0-10 arasında kullanıcı puanı    |

🧾 **Satır Sayısı:** Yaklaşık 1,020,000 oylama

---

### 🚀 Kullandığım Teknolojiler
💻 ASP.NET Core Web App (.NET 9.0)<br>
📐 Tek Katmanlı Yapı (Services-DTOs-)<br>
🔄 AutoMapper
💾 Dapper (Micro ORM) <br>
🗄️ MS SQL Server (Kaggle'dan alınan veri setleri ile yapılandırıldı)<br>
📊 Chart.js (İstatistiksel grafikler için)<br>
📋 DataTables (Tablolar için paging, filtering, search)<br>
🎨 HTML5, CSS3, JavaScript, Bootstrap<br>


Projede genel anlamda 1 bölüm bulunmaktadır.<br>
Veri Seti Paneli: Burada kullanıcı, kitaplar, popüler kitaplar, kullanıcılar ve puanlamaları listeyebilir ve filtreleyebilir. Dashboard bölümünde de tablolar ile ilgili istatistikleri görüntüleyebilir.<br>

---

## :arrow_forward: Projeden Ekran Görüntüleri

### :triangular_flag_on_post: Veri Seti Paneli
<div align="center">
  <img src="https://github.com/melihcolak0/DapperKaggle/blob/6a8304952247db2c4cdc1baab89bb2740361d757/ss/screencapture-localhost-7039-Dashboard-Index-2025-08-05-22_55_27.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/DapperKaggle/blob/6a8304952247db2c4cdc1baab89bb2740361d757/ss/screencapture-localhost-7039-Book-Index-2025-08-05-22_56_31.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/DapperKaggle/blob/6a8304952247db2c4cdc1baab89bb2740361d757/ss/screencapture-localhost-7039-Book-Index2-2025-08-05-22_55_50.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/DapperKaggle/blob/6a8304952247db2c4cdc1baab89bb2740361d757/ss/screencapture-localhost-7039-User-Index-2025-08-05-22_56_53.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/DapperKaggle/blob/6a8304952247db2c4cdc1baab89bb2740361d757/ss/screencapture-localhost-7039-Rating-Index-2025-08-05-22_57_38.png" alt="image alt">
</div>
