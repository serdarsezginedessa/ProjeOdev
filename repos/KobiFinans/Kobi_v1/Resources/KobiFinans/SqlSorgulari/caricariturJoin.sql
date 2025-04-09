Select c.CariID,
                                    c.CariAdi,
		                            c.Telefon,
		                            c.Email,
		                            c.Adres,
		                            c.VergiNo,
		                            c.Borc,
		                            c.Alacak, 
		                            ct.Ad 
		                            From cari as c
		                            INNER JOIN
		                            CariTuru as ct
		                            ON
		                            c.cariTuru = ct.ID