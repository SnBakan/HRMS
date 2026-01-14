# HRMS - İnsan Kaynakları Personel Takip Sistemi (Windows Forms)

Bu proje, Katmanlı Mimari (Presentation / Service / Domain / DAL) kullanılarak geliştirilmiş bir **İnsan Kaynakları Yönetim Sistemi (HRMS)** uygulamasıdır.

## 🎯 Amaç
- Kullanıcı rollerine göre yetkilendirme (Owner / Manager / Employee)
- Personel, departman ve izin süreçlerinin yönetimi
- Rapor ekranlarıyla verilerin görselleştirilmesi

---

## 👥 Roller ve Yetkiler

### Owner
- Departman Yönetimi (CRUD + aktif/pasif)
- Personel Yönetimi (CRUD + aktif/pasif)
- İzin Talepleri (onay/red)
- Geçmiş Personel İzinleri (tüm personel)
- Raporlar (filtresiz)

### Manager
- İzin Talepleri (sadece kendi departmanı, kendisi hariç)
- Geçmiş Personel İzinleri (sadece kendi departmanı)
- Raporlar (kendi departmanına filtreli)

### Employee
- Bilgilerim
- İzin Oluştur
- Geçmiş İzinlerim (onaylı filtre dahil)

---

## 🧩 Modüller

- **Bilgilerim**
- **İzin Oluşturma**
- **Geçmiş İzinlerim**
- **İzin Talepleri (Onay/Red)**
- **Geçmiş Personel İzinleri**
- **Raporlar**
  - Günlük Rapor
  - Kalan İzin Hakları Dağılımı
  - Personel Dağılımı
  - Maaş Dağılımı
  - Performans Dağılımı

---

## 🏗️ Mimari

- **Presentation**: Windows Forms UI
- **Service**: İş kuralları / doğrulamalar
- **Domain**: Entity + DTO
- **DAL**: MySQL erişimi (Repository Pattern)

---

## 🛠️ Teknolojiler
- C# (.NET Framework) Windows Forms
- MySQL
- Repository Pattern
- DTO yapısı
- Chart / DataGridView

---

## 📸 Ekran Görüntüleri
> `Ekran Taslakları` veya `Tasarım` klasörüne eklediğiniz görselleri burada listeleyebilirsiniz.

---

## 🚀 Kurulum
1. Projeyi klonlayın:
   ```bash
   git clone <repo-url>
2. Visual Studio ile Solution’ı açın.

3. MySQL bağlantı ayarlarınızı ConnectionStrings üzerinden düzenleyin.

4. Uygulamayı çalıştırın.


✅ Notlar

Proje eğitim amacıyla hazırlanmıştır.
Roller arası filtreleme ve yetkilendirme aktif olarak uygulanmıştır.
