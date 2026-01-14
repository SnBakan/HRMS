# HRMS - İnsan Kaynakları Personel Takip Sistemi (Windows Forms)
> Katmanlı mimari ile geliştirilmiş, rol bazlı yetkilendirme içeren masaüstü İK yönetim sistemi.

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

## 📸 Video 
 - Youtube proje tanıtım videosu izlemek için
   
---

## 📸 Ekran Görüntüleri
- Login ve Rol Bazlı Giriş
  <img width="632" height="784" alt="image" src="https://github.com/user-attachments/assets/b8c47384-aa31-4b01-8ffd-72767c1d933f" />


- Owner - Main Ekranı
  <img width="1022" height="707" alt="image" src="https://github.com/user-attachments/assets/05fc719a-6d4b-4c83-bcbd-ee8863479d69" />


- Owner – Personel Yönetimi
  <img width="1022" height="719" alt="image" src="https://github.com/user-attachments/assets/9fd716a0-9a99-4981-bec9-71184b26ebde" />


- Owner – Departman Yönetimi
  <img width="990" height="680" alt="image" src="https://github.com/user-attachments/assets/c68a99de-0f3a-4a8d-bcde-9a6c053be36e" />


- Owner - Raporlar - Günlük Rapor
  <img width="1304" height="904" alt="image" src="https://github.com/user-attachments/assets/f239ee54-c8cb-416e-8dde-47d19fcd0753" />


- Owner - Raporlar - Kalan İzin Hakları Dağılım Raporu
  <img width="1301" height="903" alt="image" src="https://github.com/user-attachments/assets/4b8bc3fe-598f-4f11-9c5f-ee2e7c522fef" />

- Manager - Main
  <img width="1023" height="715" alt="image" src="https://github.com/user-attachments/assets/7fcc008e-36b3-421f-b77a-9a98691f8a68" />


- Manager – İzin Talepleri
  <img width="1025" height="710" alt="image" src="https://github.com/user-attachments/assets/43747c1f-05da-46aa-96bc-3a1dfa2dbc36" />


- Manager - Geçmiş Personel İzinleri (Departmanına özel)
  <img width="1025" height="713" alt="image" src="https://github.com/user-attachments/assets/ae82f7a9-7ffd-4411-a0d5-19eee9b896ca" />


- Manager - Raporlar - Günlük Rapor
  <img width="1300" height="905" alt="Ekran görüntüsü 2026-01-14 052833" src="https://github.com/user-attachments/assets/a58f5fa3-ee53-4521-ad16-03b370801f21" />


- Manager - Raporlar - Performans Dağılım Raporu
  <img width="1303" height="904" alt="image" src="https://github.com/user-attachments/assets/848c487f-de56-4d24-9318-06bc223b7803" />


- Employee - Main
  <img width="1025" height="711" alt="image" src="https://github.com/user-attachments/assets/14b4b5c8-237f-4845-a152-5953894b4fab" />


- Employee - Bilgilerim
  <img width="1026" height="713" alt="image" src="https://github.com/user-attachments/assets/ee5753f4-a416-4533-aaa5-de0701f3b47f" />


- Employee – İzin Oluşturma
  <img width="1026" height="716" alt="image" src="https://github.com/user-attachments/assets/bcf5b8f4-1094-4101-8b0b-09db69cf74a9" />


- Employee - Geçmiş İzinlerim
  <img width="1025" height="717" alt="image" src="https://github.com/user-attachments/assets/ee570488-5c19-4b5f-bfb8-fa2d971aaaa9" />

---

## 🚀 Kurulum
1. Projeyi klonlayın:
   ```bash
   [git clone <repo-url>](https://github.com/SnBakan/HRMS.git)
2. Visual Studio ile Solution’ı açın.

3. MySQL bağlantı ayarlarınızı ConnectionStrings üzerinden düzenleyin.

4. Uygulamayı çalıştırın.


✅ Notlar

Proje eğitim amacıyla hazırlanmıştır.
Roller arası filtreleme ve yetkilendirme aktif olarak uygulanmıştır.
