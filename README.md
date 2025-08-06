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
Bu projede Kaggle’dan alınan "Books Dataset" veri seti kullanılmıştır. Veri kümesi üç ayrı tablo içerir:<br>
Veri Seti: https://www.kaggle.com/datasets/saurabhbagchi/books-dataset

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
💾 Dapper (Micro ORM) <br>
🗄️ MS SQL Server (Kaggle'dan alınan veri setleri ile yapılandırıldı)<br>
📊 Chart.js (İstatistiksel grafikler için)<br>
📋 DataTables (Tablolar için paging, filtering, search)<br>
🎨 HTML5, CSS3, JavaScript, Bootstrap<br>


Projede genel anlamda 1 bölüm bulunmaktadır.<br>
Ana Sayfa: Burada kullanıcı, Takvim Çizelgesi uygulaması ile etkinliklerini düzenleyebilir, Etkinlik ve Kategori entity'lerinin de CRUD işlemlerini yapabilir.<br>

---

## :arrow_forward: Projeden Ekran Görüntüleri

---

### :triangular_flag_on_post: Veri Seti Paneli
<div align="center">
  <img src="https://github.com/melihcolak0/ScheduleMVC/blob/1a0d5a0d1b9637fda6f7322cecfcb8ffe23e594d/ss/localhost_44327_Schedule_Index%20(4).png" alt="image alt">
</div>
