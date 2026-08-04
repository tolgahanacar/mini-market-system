# Changelog

## v2.1.0 (August 4, 2026)
- **Clean Architecture & Services Layer**: UI mantığı `ProductService`, `WalletService`, `CartService`, `ReceiptService` ve `JsonStorageService` katmanlarına ayrıştırıldı.
- **JSON Persistence (Kalıcı Veri)**: Ürünler, bakiye ve işlem geçmişi otomatik olarak JSON dosyalarına kaydediliyor; uygulama yeniden başlatıldığında veriler korunuyor.
- **İşlem Geçmişi (Transaction History)**: Tamamlanan tüm siparişler tarih, sepet içeriği ve ödeme detaylarıyla kaydediliyor ve `HistoryForm` üzerinden incelenebiliyor.
- **Gelişmiş Fiş Gösterici (Receipt Dialog)**: Satın alma fişleri özel modal pencerede (`ReceiptForm`) gösteriliyor; panoya kopyalanabilir veya `.txt` dosyası olarak kaydedilebilir.
- **Ürün Arama & Kataloğa Ürün Ekleme**: Arayüze anlık ürün arama (filtreleme) ve dinamik olarak yeni ürün ekleme penceresi (`AddProductForm`) dahil edildi.
- **Unit Tests**: `MiniMarket.Tests` (xUnit) projesi eklenerek sepet, bakiye, ürün yönetimi ve fiş servisleri otomatik testlerle koruma altına alındı.

---

## v2.0.0 (August 4, 2026)
- **Architecture**: Tamamen OOP (Nesne Yönelimli) mimariyle yeniden yazıldı. UI ve iş mantığı (Models) ayrıştırıldı.
- **UI/UX**: Eski, karmaşık TextBox yığını kaldırılarak yerine çok daha pratik ve temiz `DataGridView` tabloları eklendi. Buton ikonları ve arkaplan görselleri iyileştirildi.
- **Framework**: Proje, artık eski nesil `.NET Framework 4.7.2` yerine son teknoloji ürünü **`.NET 8.0 SDK-Style`** altyapısında çalışıyor.
- **Feature**: Sepetteki ürünlerin satın alımı sonrasında dinamik olarak detaylı **Alışveriş Fişi (Receipt)** üreten yeni bir özellik eklendi.
- **Cleanup**: Proje adı anlamsız `DorduncuUygulama` isminden kurtulup `MiniMarket` olarak değiştirildi. Gereksiz tüm önbellek (.vs, bin, obj vb.) dosyaları temizlenip `.gitignore` eklendi.

---

## v1.0.1 (Nov 5, 2021)
- Removed negative test effects from workflows and actions.
- Github Action tests.

## v1.0.0 (Jan 12, 2021)
- Initial release, update and release.
