SELECT TOP (1000) [UrunID] as ID
      ,[UrunKodu] as 'Urun Kodu'
      ,[UrunAdi] as 'Urun Ad�'
      ,[Aciklama] as 'A��klama'
      ,kt.KategoriAd as 'Kategori'
      ,[AlisFiyat] as 'Al�� Fiyat�'
      ,[SatisFiyat] as 'Sat�� Fiyat�'
      ,[StokMiktari] as 'Stok Adeti'
  FROM [KobiFinans].[dbo].[Urunler] as ur
  inner Join
  UrunKategori as kt
  on
  ur.KategoriId=kt.ID

