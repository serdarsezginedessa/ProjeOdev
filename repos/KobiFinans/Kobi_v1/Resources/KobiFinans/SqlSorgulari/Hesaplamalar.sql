select count(*) carituru from cari where CariTuru='MüÞ'
select SUBSTRING(CariKod,1,3) from cari where CariKod LIKE 'MÜÞ %'

select count (SUBSTRING(CariKod,1,3)) as 'Müþteri Sayýsý' from cari where SUBSTRING(CariKod,1,3) LIKE 'MÜÞ%'
select * from cari

select HareketTipi, sum(Tutar) from KasaHareketleri where HareketTipi='Tahsilat'
group by HareketTipi

SELECT SUM(Tutar) AS GelirToplami
FROM KasaHareketleri
WHERE HareketTipi IN ('Tahsilat', 'Giriþ')

SELECT SUM(Tutar) AS GiderToplami
FROM KasaHareketleri
WHERE HareketTipi IN ('Tediye', 'Çýkýþ', 'Gider')

SELECT 
    CASE 
        WHEN HareketTipi IN ('Tahsilat', 'Giriþ') THEN 'Gelir'
        WHEN HareketTipi IN ('Tediye', 'Çýkýþ', 'Gider') THEN 'Gider'
        ELSE 'Diðer'
    END AS Tip,
    SUM(Tutar) AS Toplam
FROM KasaHareketleri
GROUP BY 
    CASE 
        WHEN HareketTipi IN ('Tahsilat', 'Giriþ') THEN 'Gelir'
        WHEN HareketTipi IN ('Tediye', 'Çýkýþ', 'Gider') THEN 'Gider'
        ELSE 'Diðer'
    END


