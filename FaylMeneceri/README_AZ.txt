FAYL MENECERI - C# WINDOWS FORMS
===============================

Visual Studio-da açmaq:
1. ZIP faylını qovluğa çıxarın (Extract All).
2. FaylMeneceri.sln faylına iki dəfə klikləyin.
3. Visual Studio 2022 (və ya .NET 8 dəstəkləyən daha yeni versiya) açıldıqda F5 basın.
4. İlk açılışda NumuneFayllar qovluğundakı 5 mətn faylı görünəcək.

Visual Studio Installer vasitəsilə "Desktop development with .NET"
komponenti quraşdırılmış olmalıdır. .NET 8 SDK lazım ola bilər.

Əsas hissələr:
- Form1.Designer.cs  -> proqramın görünüşü və Control-lar
- Form1.cs           -> düymələrin işləmə məntiqi, hadisələr
- Program.cs         -> başlanğıc kodu
- NumuneFayllar      -> nümunə .txt fayllar

Control adları (göndərilən şəklə uyğun):
btnQovluq, btnAc, btnSaxla, btnSil, txtYol,
lstFayllar, txtMetn, lblMelumat, statusStrip1, lblStatus.

İstifadə qaydası:
- "Qovluq seç"  -> kompüterdə qovluq seçir.
- Fayl siyahısı -> seçilmiş .txt faylını mətndə göstərir.
- "Aç"         -> seçilmiş .txt faylını açır.
- "Yadda saxla" -> redaktə edilmiş mətni fayla yazır.
- "Sil"        -> təsdiq alaraq faylı silir.
- Aşağı panel  -> fayl adı, həcm və yaranma tarixini göstərir.
- Status hissə -> fayl sayını və son əməliyyatı göstərir.

Qısa yollar:
Ctrl+Shift+O - Qovluq seç
Ctrl+O       - Faylı aç
Ctrl+S       - Yadda saxla
F5           - Siyahını yenilə
Delete       - Siyahıda seçilmiş faylı sil

Qırmızı yazılar şəkildəki Control adlarının göstəriciləridir.
İstəmirsinizsə, Form1.Designer.cs faylındakı
lblTag... komponentlərini və lblTagStatus-u çıxara bilərsiniz.

QEYD:
Bu paket mənbə kodudur (.sln/.csproj/.cs), hazır .exe deyil.
Windows və .NET 8 yüklənmiş Visual Studio-da layihəni F5 ilə işə salın.
