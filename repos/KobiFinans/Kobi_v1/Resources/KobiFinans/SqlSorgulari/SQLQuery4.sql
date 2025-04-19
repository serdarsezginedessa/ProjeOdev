select * from CariHareketleri
select * from Cari
select cariadi from Cari where CariID=2

SELECT
                                ch.Tarih,
	                            ch.HareketID,
	                            ch.Aciklama,	
	                            c.Borc,
	                            c.Alacak,    
                                ch.HareketTipi,
                                ch.Tutar
                            FROM 
                                cari AS c
                            INNER JOIN 
                                carihareketleri AS ch
                            ON 
                                c.CariID = ch.CariID
                            WHERE 
                                c.cariadi = 'Foto Serdar';
Select c.CariAdi [Cari Ad�],
		c.Telefon,
		c.Email [E-Posta],
		c.Adres,
		c.VergiNo [Vergi No],
		c.Borc [Bor�],
		c.Alacak, 
		ct.Ad [Cari Turu] 
		From cari as c
		INNER JOIN
		CariTuru as ct
		ON
		c.cariTuru = ct.ID;




Select ur.UrunKodu [�r�n Kodu],ur.UrunAdi [�r�n Ad�],ur.Kdv [Kdv],ur.AlisFiyat [Fiyat�]  from Urunler as ur
Inner Join
SatisIslemleri as si
ON
ur.UrunID=si.UrunID
Inner Join
Cari as c
ON
si.CariID=c.CariID