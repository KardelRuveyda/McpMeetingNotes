# MeetingMcp

MeetingMcp, toplantı notlarını yönetmek için geliştirilmiş bir uygulamadır. Bu uygulama, toplantı notlarını ekleme, listeleme, belirli bir ID veya tarihe göre getirme gibi işlevler sunar.

## Özellikler

- **Tüm toplantı notlarını listeleme**: Uygulama içerisindeki tüm toplantı notlarını görüntüleyebilirsiniz.
- **Belirli bir ID ile toplantı notu getirme**: ID bilgisi ile spesifik bir toplantı notunu sorgulayabilirsiniz.
- **Son toplantı notunu getirme**: En son eklenen toplantı notunu görüntüleyebilirsiniz.
- **Belirli bir tarihteki toplantı notlarını getirme**: Tarih bilgisi ile o günkü toplantı notlarını sorgulayabilirsiniz.
- **Yeni toplantı notu ekleme**: Başlık, içerik ve tarih bilgisi ile yeni bir toplantı notu ekleyebilirsiniz.

## Kurulum

1. **Gereksinimler**:
   - .NET 9.0 SDK
   - Windows işletim sistemi

2. **Projeyi Çalıştırma**:
   - Projeyi klonlayın:
     ```bash
     git clone <repository-url>
     ```
   - Proje dizinine gidin:
     ```bash
     cd MeetingMcp
     ```
   - Uygulamayı çalıştırın:
     ```bash
     dotnet run --project MeetingMcp.csproj
     ```

## Kullanım

### Araçlar

Uygulama aşağıdaki araçları sunar:

1. **GetAllNotes**: Tüm toplantı notlarını getirir.
2. **GetNoteById**: Belirli bir ID ile toplantı notu getirir.
3. **GetLastNote**: Son toplantı notunu getirir.
4. **GetNotesByDate**: Belirtilen tarihteki toplantı notlarını getirir.
5. **AddNote**: Yeni bir toplantı notu ekler.

### Örnek Kullanım

- **Son toplantı notunu getirme**:
  ```bash
  curl -X GET http://localhost:5000/api/notes/last
  ```

- **Yeni toplantı notu ekleme**:
  ```bash
  curl -X POST http://localhost:5000/api/notes -d '{"title": "Sprint Planlama", "content": "Yeni sprint için görevler belirlendi.", "date": "2025-07-25"}'
  ```

## ModelContextProtocol Inspector

MeetingMcp, ModelContextProtocol Inspector ile uyumlu çalışmaktadır. Bu araç, MCP tabanlı uygulamaların durumunu ve işlevlerini görselleştirmek için kullanılır. Inspector sayesinde:

- MCP araçlarını test edebilir ve çalıştırabilirsiniz.
- Uygulamanın durumunu ve performansını izleyebilirsiniz.
- Hata ayıklama ve analiz süreçlerini kolaylaştırabilirsiniz.

ModelContextProtocol Inspector hakkında daha fazla bilgi için [resmi dökümantasyona](https://modelcontextprotocol.io/inspector) göz atabilirsiniz.

## Katkıda Bulunma

Katkıda bulunmak için lütfen bir pull request gönderin veya bir issue açın.

## Lisans

Bu proje MIT Lisansı altında lisanslanmıştır.
