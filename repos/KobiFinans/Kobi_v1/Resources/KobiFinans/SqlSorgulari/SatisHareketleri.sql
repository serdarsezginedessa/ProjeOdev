SELECT Convert(date, si.SatisTarihi) as [Fatura Tarihi] ,si.FaturaNo as [Fatura No], c.CariKod [Cari Kod], c.cariAdi [Ad Soyad],(Sum(si.Tutar)/1.20) as [Kdv Matrahý], SUM(si.Tutar) as [Genel Toplam]  From SatisIslemleri as si
Left Join Urunler as u
On si.UrunID=u.UrunID
LEFT Join Cari as c
On si.CariID=c.CariID
LEFT Join SatisFaturaNo f
On si.FaturaNo=f.FaturaID
Group By si.SatisTarihi, si.FaturaNo, c.CariKod,c.CariAdi
Order BY si.FaturaNo DESC


--si.SatisID, u.UrunKodu[Ürün Kodu],u.UrunAdi[Ürün Adý],si.Adet[Adet],si.Tutar[Tutar],si.Durum[Durum]

--LEFT Join Kasa k
--On si.KasaID=k.id
--LEFT Join Bankalar b
--On si.BankaID=b.ID
--LEFT Join OdemeTuru odt
--On si.OdemeID=odt.OdemeID

SELECT 
				u.UrunKodu [Ürün Kodu],
				u.UrunAdi [Ürün Adý],
				u.SatisFiyat [Satýþ Fiyatý],
				u.Kdv,
				si.Adet,si.Tutar
				
				
From SatisIslemleri as si
Left Join Urunler as u
On si.UrunID=u.UrunID
LEFT Join Cari as c
On si.CariID=c.CariID
LEFT Join SatisFaturaNo f
On si.FaturaNo=f.FaturaID
Left Join Kasa as k
On si.KasaID=k.id
Left Join Bankalar as b
On si.BankaID=b.ID
Left Join OdemeTuru od
On si.OdemeID=od.OdemeID
Where si.FaturaNo=56


SELECT c.CariID,c.CariAdi, c.Eposta, c.Telefon, c.Yetkili, c.CariTuru, si.Durum,si.FaturaNo,
				si.SatisTarihi,			
				k.KasaAdi,
				b.BankaAd,
				od.OdemeAD
				
From SatisIslemleri as si
Left Join Urunler as u
On si.UrunID=u.UrunID
LEFT Join Cari as c
On si.CariID=c.CariID
LEFT Join SatisFaturaNo f
On si.FaturaNo=f.FaturaID
Left Join Kasa as k
On si.KasaID=k.id
Left Join Bankalar as b
On si.BankaID=b.ID
Left Join OdemeTuru od
On si.OdemeID=od.OdemeID
Where si.FaturaNo=56


