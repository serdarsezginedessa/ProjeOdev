--Satýþ Hareketleri Tüm Kayýtlar
SELECT Convert(DATE, si.SatisTarihi) as [Fatura Tarihi] 
							,si.FaturaNo as [Fatura No]
                            ,c.CariKod [Cari Kod]
							,c.cariAdi [Ad Soyad]
							,SUM(si.KdvMatrahi) as [Kdv Matrahý]
							,SUM(si.KdvTutari) as [Kdv Tutarý]
							,SUM(si.Tutar) as [Tutar]
							,SUM(si.GenelToplam) as [Genel Toplam]

                            From SatisIslemleri as si
                            Left Join Urunler as u
                            On si.UrunID=u.UrunID
                            LEFT Join Cari as c
                            On si.CariID=c.CariID
                            LEFT Join SatisFaturaNo as f            
                            On si.FaturaNo=f.FaturaID
                            Group By si.SatisTarihi, si.FaturaNo, c.CariKod,c.CariAdi
                            Order BY si.FaturaNo DESC
-- Satýþ Hareketleri  Tarih Aralýðý
SELECT Convert(DATE, si.SatisTarihi) as [Fatura Tarihi] 
							,si.FaturaNo as [Fatura No]
                            ,c.CariKod [Cari Kod]
							,c.cariAdi [Ad Soyad]
							,SUM(si.KdvMatrahi) as [Kdv Matrahý]
							,SUM(si.KdvTutari) as [Kdv Tutarý]
							,SUM(si.Tutar) as [Tutar]
							,SUM(si.GenelToplam) as [Genel Toplam]

                            From SatisIslemleri as si
                            Left Join Urunler as u
                            On si.UrunID=u.UrunID
                            LEFT Join Cari as c
                            On si.CariID=c.CariID
                            LEFT Join SatisFaturaNo as f            
                            On si.FaturaNo=f.FaturaID

							Where si.SatisTarihi between '2025.04.20' and '2025.04.20'
							
                            Group By si.SatisTarihi, si.FaturaNo, c.CariKod,c.CariAdi
                            Order BY si.FaturaNo DESC
--Satýþ Hareketleri Fatura No---

SELECT Convert(DATE, si.SatisTarihi) as [Fatura Tarihi] 
							,si.FaturaNo as [Fatura No]
                            ,c.CariKod [Cari Kod]
							,c.cariAdi [Ad Soyad]
							,SUM(si.KdvMatrahi) as [Kdv Matrahý]
							,SUM(si.KdvTutari) as [Kdv Tutarý]
							,SUM(si.Tutar) as [Tutar]
							,SUM(si.GenelToplam) as [Genel Toplam]

                            From SatisIslemleri as si
                            Left Join Urunler as u
                            On si.UrunID=u.UrunID
                            LEFT Join Cari as c
                            On si.CariID=c.CariID
                            LEFT Join SatisFaturaNo as f            
                            On si.FaturaNo=f.FaturaID

							Where si.FaturaNo like 56

                            Group By si.SatisTarihi, si.FaturaNo, c.CariKod,c.CariAdi
                            Order BY si.FaturaNo DESC



-- Satýþ Hareketleri Ad Soyada Göre
SELECT Convert(DATE, si.SatisTarihi) as [Fatura Tarihi] 
							,si.FaturaNo as [Fatura No]
                            ,c.CariKod [Cari Kod]
							,c.cariAdi [Ad Soyad]
							,SUM(si.KdvMatrahi) as [Kdv Matrahý]
							,SUM(si.KdvTutari) as [Kdv Tutarý]
							,SUM(si.Tutar) as [Tutar]
							,SUM(si.GenelToplam) as [Genel Toplam]

                            From SatisIslemleri as si
                            Left Join Urunler as u
                            On si.UrunID=u.UrunID
                            LEFT Join Cari as c
                            On si.CariID=c.CariID
                            LEFT Join SatisFaturaNo as f            
                            On si.FaturaNo=f.FaturaID

							Where c.CariAdi like 'Serdar Sezgin'

							Group By si.SatisTarihi, si.FaturaNo, c.CariKod,c.CariAdi
                            Order BY si.FaturaNo DESC
-- Satýþ Hareketleri Car Kod a Göre

SELECT Convert(DATE, si.SatisTarihi) as [Fatura Tarihi] 
							,si.FaturaNo as [Fatura No]
                            ,c.CariKod [Cari Kod]
							,c.cariAdi [Ad Soyad]
							,SUM(si.KdvMatrahi) as [Kdv Matrahý]
							,SUM(si.KdvTutari) as [Kdv Tutarý]
							,SUM(si.Tutar) as [Tutar]
							,SUM(si.GenelToplam) as [Genel Toplam]

                            From SatisIslemleri as si
                            Left Join Urunler as u
                            On si.UrunID=u.UrunID
                            LEFT Join Cari as c
                            On si.CariID=c.CariID
                            LEFT Join SatisFaturaNo as f            
                            On si.FaturaNo=f.FaturaID

							Where c.CariKod like 'Müþ002'

                            Group By si.SatisTarihi, si.FaturaNo, c.CariKod,c.CariAdi
                            Order BY si.FaturaNo DESC






