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
                                c.cariadi = 'Foto Serdar'