# Bileşik Geometrik Dönüşümler (Compound Geometrical Transformations)

Bu proje, bir C# Windows Forms uygulamasıdır ve bileşik geometrik dönüşümlerin görsel bir temsilini sunar. Uygulama, 2D uzayda tanımlanan bir üçgene art arda iki farklı dönme dönüşümünün uygulanmasını ve sonucunu gösterir.

## Projenin Amacı

Bu uygulama, `System.Drawing.Drawing2D.Matrix` sınıfını kullanarak bir geometrik şekle (üçgen) bileşik bir dönüşüm matrisinin nasıl uygulandığını göstermek için geliştirilmiştir.

Orijinal üçgen (Mavi) ve dönüşüm uygulanmış üçgen (Kırmızı) koordinat sistemi üzerinde çizdirilir.

## Uygulanan Dönüşümler

Kod, bir `ABC` üçgenine sırasıyla aşağıdaki iki dönüşümü uygular:

1.  **1. Dönüşüm:** `P1(7, 1)` noktası etrafında `-44.0` derece dönme.
2.  **2. Dönüşüm:** `P2(1, 8)` noktası etrafında `20.0` derece dönme.

Bu iki dönüşüm matrisi çarpılarak tek bir `finalMatrix` (bileşik dönüşüm matrisi) elde edilir ve bu matris orijinal üçgenin köşe noktalarına uygulanır.

### Orijinal Noktalar

* **A:** (-3, 3)
* **B:** (-5, 3)
* **C:** (-3, 1)

## Kullanılan Teknolojiler

* **Platform:** .NET 8
* **Uygulama Türü:** Windows Forms (WinExe)
* **Dil:** C#

## Nasıl Çalıştırılır

1.  Projeyi Visual Studio ile açın.
2.  Projeyi derleyin ve çalıştırın (F5).
3.  Açılan pencerede, orijinal `ABC` üçgeni (mavi) ve bileşik dönüşüm uygulanmış `A'B'C'` üçgeni (kırmızı) görüntülenecektir. Dönme noktaları olan `P1` (yeşil) ve `P2` (turuncu) de gösterilmektedir.
