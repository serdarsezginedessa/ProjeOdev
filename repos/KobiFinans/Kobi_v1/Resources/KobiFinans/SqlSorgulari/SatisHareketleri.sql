SELECT si.FaturaNo, c.CariAdi,si.SatisTarihi, SUM(si.Tutar) as Tutar from SatisIslemleri as si
Inner Join Urunler as u
On si.UrunID=u.UrunID
Full outer Join Cari as c
On si.CariID=c.CariID
Inner Join Kasa k
On k.id=si.KasaID
Inner Join Bankalar b
On b.ID=si.BankaID
Inner Join OdemeTuru odt
On odt.OdemeID=si.OdemeID
Inner Join SatisFaturaNo f
On f.FaturaID=si.FaturaNo
Group By si.FaturaNo,c.CariAdi,si.SatisTarihi
--Order BY si.FaturaNo
--si.SatisID, u.UrunKodu[Ürün Kodu],u.UrunAdi[Ürün Adý],si.Adet[Adet],si.Tutar[Tutar],si.Durum[Durum]