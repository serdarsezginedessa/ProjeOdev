SELECT TOP (1000) [UrunID] as ID
      ,[UrunKodu] as 'Urun Kodu'
      ,[UrunAdi] as 'Urun Adý'
      ,[Aciklama] as 'Açýklama'
      ,kt.KategoriAd as 'Kategori'
      ,[AlisFiyat] as 'Alýþ Fiyatý'
      ,[SatisFiyat] as 'Satýþ Fiyatý'
      ,[StokMiktari] as 'Stok Adeti'
  FROM [KobiFinans].[dbo].[Urunler] as ur
  inner Join
  UrunKategori as kt
  on
  ur.KategoriId=kt.ID

