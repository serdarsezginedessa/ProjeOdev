USE [KobiFinans]
GO
/****** Object:  Table [dbo].[BankaHareketleri]    Script Date: 04.05.2025 19:20:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BankaHareketleri](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BankaID] [int] NOT NULL,
	[CariID] [int] NOT NULL,
	[Aciklama] [nvarchar](max) NULL,
	[HareketTipi] [nvarchar](50) NOT NULL,
	[Tarih] [datetime] NOT NULL,
	[Tutar] [decimal](18, 2) NOT NULL,
	[Kaynak] [nvarchar](50) NULL,
	[FaturaNo] [int] NULL,
	[TahsilatID] [int] NULL,
 CONSTRAINT [PK_BankaHareket] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bankalar]    Script Date: 04.05.2025 19:20:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bankalar](
	[BankaID] [int] IDENTITY(1,1) NOT NULL,
	[BankaAd] [nvarchar](50) NULL,
	[BankaSube] [nvarchar](50) NULL,
	[HesapNo] [nvarchar](50) NULL,
	[Iban] [nvarchar](50) NULL,
	[EklenmeTarihi] [datetime] NULL,
	[Durum] [bit] NOT NULL,
 CONSTRAINT [PK_Bankalar] PRIMARY KEY CLUSTERED 
(
	[BankaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cari]    Script Date: 04.05.2025 19:20:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cari](
	[CariID] [int] IDENTITY(1,1) NOT NULL,
	[CariKod] [nvarchar](20) NULL,
	[CariAdi] [nvarchar](100) NOT NULL,
	[CariTuru] [int] NOT NULL,
	[Yetkili] [nvarchar](100) NULL,
	[Telefon] [nvarchar](20) NULL,
	[Eposta] [nvarchar](100) NULL,
	[Adres] [nvarchar](200) NULL,
	[Sehir] [nvarchar](50) NULL,
	[Ulke] [nvarchar](50) NULL,
	[VergiDairesi] [nvarchar](50) NULL,
	[VergiNo] [nvarchar](20) NULL,
	[DogumTarihi] [date] NULL,
	[EvlilikTarihi] [date] NULL,
	[KayitTarihi] [datetime] NULL,
	[Durum] [bit] NULL,
	[Aciklama] [nvarchar](250) NULL,
	[Resim] [nvarchar](max) NULL,
 CONSTRAINT [PK__Cari__5F7113A9A34E30BE] PRIMARY KEY CLUSTERED 
(
	[CariID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ__Cari__D16BCA565F40901F] UNIQUE NONCLUSTERED 
(
	[CariKod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CariHareketleri]    Script Date: 04.05.2025 19:20:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CariHareketleri](
	[HareketID] [int] IDENTITY(1,1) NOT NULL,
	[CariID] [int] NULL,
	[KasaID] [int] NULL,
	[BankaID] [int] NULL,
	[OdemeID] [int] NOT NULL,
	[Tarih] [datetime] NOT NULL,
	[Aciklama] [nvarchar](255) NULL,
	[Tutar] [decimal](18, 2) NOT NULL,
	[HareketTipi] [nvarchar](20) NOT NULL,
	[TahsilatID] [int] NULL,
	[GiderId] [int] NULL,
 CONSTRAINT [PK__CariHare__50654B067EE8B580] PRIMARY KEY CLUSTERED 
(
	[HareketID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CariTuru]    Script Date: 04.05.2025 19:20:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CariTuru](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Ad] [nvarchar](50) NOT NULL,
	[Prefix] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CariTuru] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gider]    Script Date: 04.05.2025 19:20:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gider](
	[GiderID] [int] IDENTITY(1,1) NOT NULL,
	[CariID] [int] NOT NULL,
	[KasaID] [int] NOT NULL,
	[Aciklama] [nvarchar](max) NULL,
	[Tarih] [datetime] NULL,
	[Tutar] [decimal](18, 2) NULL,
	[Tipi] [int] NOT NULL,
	[Durum] [bit] NULL,
 CONSTRAINT [PK_GelirGider] PRIMARY KEY CLUSTERED 
(
	[GiderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GiderTipi]    Script Date: 04.05.2025 19:20:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GiderTipi](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Ad] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_GelirGiderTipi] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KasaHareketleri]    Script Date: 04.05.2025 19:20:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KasaHareketleri](
	[HareketID] [int] IDENTITY(1,1) NOT NULL,
	[KasaID] [int] NOT NULL,
	[CariID] [int] NOT NULL,
	[Tarih] [datetime] NOT NULL,
	[Tutar] [decimal](18, 2) NOT NULL,
	[Aciklama] [nvarchar](255) NULL,
	[HareketTipi] [nvarchar](50) NOT NULL,
	[FaturaNo] [int] NULL,
	[TahsilatID] [int] NULL,
	[GiderID] [int] NULL,
 CONSTRAINT [PK__KasaHare__50654B06D609D65B] PRIMARY KEY CLUSTERED 
(
	[HareketID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kasalar]    Script Date: 04.05.2025 19:20:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kasalar](
	[KasaID] [int] IDENTITY(1,1) NOT NULL,
	[KasaAdi] [nvarchar](50) NOT NULL,
	[Aciklama] [nvarchar](200) NULL,
	[Durum] [bit] NULL,
	[Tarih] [datetime] NULL,
 CONSTRAINT [PK_Kasa] PRIMARY KEY CLUSTERED 
(
	[KasaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kullanici]    Script Date: 04.05.2025 19:20:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kullanici](
	[KullaniciID] [int] IDENTITY(1,1) NOT NULL,
	[KullaniciAdi] [nvarchar](50) NOT NULL,
	[Sifre] [nvarchar](50) NOT NULL,
	[Eposta] [nvarchar](50) NOT NULL,
	[Rol] [nvarchar](20) NOT NULL,
	[Durum] [bit] NOT NULL,
 CONSTRAINT [PK__Kullanic__E011F09BE5D33764] PRIMARY KEY CLUSTERED 
(
	[KullaniciID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OdemeTuru]    Script Date: 04.05.2025 19:20:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OdemeTuru](
	[OdemeID] [int] IDENTITY(1,1) NOT NULL,
	[OdemeAD] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_OdemeTuru] PRIMARY KEY CLUSTERED 
(
	[OdemeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SatisDetaylari]    Script Date: 04.05.2025 19:20:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SatisDetaylari](
	[DetayID] [int] IDENTITY(1,1) NOT NULL,
	[FaturaID] [int] NOT NULL,
	[UrunID] [int] NOT NULL,
	[Adet] [int] NOT NULL,
	[BirimFiyat] [decimal](18, 2) NOT NULL,
	[KdvOrani] [float] NOT NULL,
 CONSTRAINT [PK_SatisDetaylari] PRIMARY KEY CLUSTERED 
(
	[DetayID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SatisFaturaNo]    Script Date: 04.05.2025 19:20:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SatisFaturaNo](
	[FaturaID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_SatisFaturaNo] PRIMARY KEY CLUSTERED 
(
	[FaturaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SatisIslemleri]    Script Date: 04.05.2025 19:20:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SatisIslemleri](
	[SatisID] [int] IDENTITY(1,1) NOT NULL,
	[FaturaNo] [int] NULL,
	[CariID] [int] NULL,
	[Tarih] [datetime] NULL,
	[SatisTarihi] [datetime] NULL,
	[Durum] [nvarchar](50) NULL,
 CONSTRAINT [PK__SatisIsl__80CB4CFFF972EF34] PRIMARY KEY CLUSTERED 
(
	[SatisID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [PK_Satis] UNIQUE NONCLUSTERED 
(
	[FaturaNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tahsilatlar]    Script Date: 04.05.2025 19:20:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tahsilatlar](
	[TahsilatID] [int] IDENTITY(1,1) NOT NULL,
	[FaturaNo] [int] NULL,
	[CariID] [int] NOT NULL,
	[Tutar] [decimal](18, 2) NOT NULL,
	[Tarih] [datetime] NOT NULL,
	[OdemeTuruID] [int] NOT NULL,
	[KasaID] [int] NULL,
	[BankaID] [int] NULL,
	[Aciklama] [nvarchar](250) NULL,
 CONSTRAINT [PK__Tahsilat__89AB38275D7BE249] PRIMARY KEY CLUSTERED 
(
	[TahsilatID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UrunBirimleri]    Script Date: 04.05.2025 19:20:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UrunBirimleri](
	[BirimID] [int] IDENTITY(1,1) NOT NULL,
	[BirimAdi] [nvarchar](50) NULL,
 CONSTRAINT [PK_UrunBirimleri] PRIMARY KEY CLUSTERED 
(
	[BirimID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UrunEtiketleri]    Script Date: 04.05.2025 19:20:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UrunEtiketleri](
	[EtiketID] [int] NOT NULL,
	[UrunID] [int] NULL,
	[Etiket] [nvarchar](100) NULL,
 CONSTRAINT [PK_UrunEtiketleri] PRIMARY KEY CLUSTERED 
(
	[EtiketID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UrunFiyatGecmisi]    Script Date: 04.05.2025 19:20:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UrunFiyatGecmisi](
	[FiyatID] [int] IDENTITY(1,1) NOT NULL,
	[UrunID] [int] NULL,
	[Fiyat] [decimal](18, 2) NOT NULL,
	[DegisiklikTarihi] [datetime] NULL,
 CONSTRAINT [PK_UrunFiyatGecmisi] PRIMARY KEY CLUSTERED 
(
	[FiyatID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UrunKategori]    Script Date: 04.05.2025 19:20:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UrunKategori](
	[KategoriID] [int] IDENTITY(1,20) NOT NULL,
	[KategoriAdi] [nvarchar](100) NOT NULL,
	[Aciklama] [nvarchar](250) NULL,
	[Durum] [bit] NOT NULL,
 CONSTRAINT [PK_Kategori] PRIMARY KEY CLUSTERED 
(
	[KategoriID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Urunler]    Script Date: 04.05.2025 19:20:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Urunler](
	[UrunID] [int] IDENTITY(1,1) NOT NULL,
	[UrunKodu] [nvarchar](50) NULL,
	[Barkod] [nvarchar](50) NULL,
	[Marka] [nvarchar](50) NULL,
	[Model] [nvarchar](50) NULL,
	[UrunAdi] [nvarchar](50) NULL,
	[KategoriID] [int] NULL,
	[AlisFiyat] [decimal](18, 2) NULL,
	[SatisFiyat] [decimal](18, 2) NOT NULL,
	[Kdv] [smallint] NULL,
	[StokMiktari] [int] NOT NULL,
	[Aciklama] [nvarchar](250) NULL,
	[Resim] [nvarchar](max) NULL,
	[Durum] [bit] NOT NULL,
	[KayitTarihi] [date] NOT NULL,
	[Birim] [nvarchar](50) NULL,
 CONSTRAINT [PK_Urunler] PRIMARY KEY CLUSTERED 
(
	[UrunID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Urunleryedek]    Script Date: 04.05.2025 19:20:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Urunleryedek](
	[UrunID] [int] IDENTITY(1,1) NOT NULL,
	[UrunAdi] [nvarchar](100) NOT NULL,
	[Kategori] [nvarchar](50) NULL,
	[Fiyat] [decimal](10, 2) NOT NULL,
	[StokMiktari] [int] NULL,
	[EklenmeTarihi] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[UrunID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UrunResimleri]    Script Date: 04.05.2025 19:20:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UrunResimleri](
	[ResimID] [int] IDENTITY(1,1) NOT NULL,
	[UrunID] [int] NULL,
	[Resim] [nvarchar](500) NULL,
 CONSTRAINT [PK_UrunResimleri] PRIMARY KEY CLUSTERED 
(
	[ResimID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BankaHareketleri] ADD  CONSTRAINT [DF_BankaHareketleri_HareketTipi]  DEFAULT (N'Tahsilat') FOR [HareketTipi]
GO
ALTER TABLE [dbo].[BankaHareketleri] ADD  CONSTRAINT [DF_BankaHareket_Tarih]  DEFAULT (getdate()) FOR [Tarih]
GO
ALTER TABLE [dbo].[BankaHareketleri] ADD  CONSTRAINT [DF_BankaHareketleri_FaturaNo]  DEFAULT ((0)) FOR [FaturaNo]
GO
ALTER TABLE [dbo].[Bankalar] ADD  CONSTRAINT [DF_Bankalar_EklenmeTarihi]  DEFAULT (getdate()) FOR [EklenmeTarihi]
GO
ALTER TABLE [dbo].[Bankalar] ADD  CONSTRAINT [DF_Bankalar_Durum]  DEFAULT ((1)) FOR [Durum]
GO
ALTER TABLE [dbo].[Cari] ADD  CONSTRAINT [DF__Cari__KayitTarih__345EC57D]  DEFAULT (getdate()) FOR [KayitTarihi]
GO
ALTER TABLE [dbo].[Cari] ADD  CONSTRAINT [DF__Cari__Aktif__3552E9B6]  DEFAULT ((1)) FOR [Durum]
GO
ALTER TABLE [dbo].[CariHareketleri] ADD  CONSTRAINT [DF_CariHareketleri_KasaID]  DEFAULT ((0)) FOR [KasaID]
GO
ALTER TABLE [dbo].[CariHareketleri] ADD  CONSTRAINT [DF_CariHareketleri_BankaID]  DEFAULT (NULL) FOR [BankaID]
GO
ALTER TABLE [dbo].[CariHareketleri] ADD  CONSTRAINT [DF__CariHarek__Tarih__74AE54BC]  DEFAULT (getdate()) FOR [Tarih]
GO
ALTER TABLE [dbo].[CariHareketleri] ADD  CONSTRAINT [DF_CariHareketleri_TahsilatID]  DEFAULT ((0)) FOR [TahsilatID]
GO
ALTER TABLE [dbo].[CariHareketleri] ADD  CONSTRAINT [DF_CariHareketleri_GiderId]  DEFAULT ((0)) FOR [GiderId]
GO
ALTER TABLE [dbo].[Gider] ADD  CONSTRAINT [DF_Gider_Tarih]  DEFAULT (getdate()) FOR [Tarih]
GO
ALTER TABLE [dbo].[Gider] ADD  CONSTRAINT [DF_GelirGider_Durum]  DEFAULT ((1)) FOR [Durum]
GO
ALTER TABLE [dbo].[KasaHareketleri] ADD  CONSTRAINT [DF__KasaHarek__Tarih__5165187F]  DEFAULT (getdate()) FOR [Tarih]
GO
ALTER TABLE [dbo].[KasaHareketleri] ADD  CONSTRAINT [DF_KasaHareketleri_FaturaNo]  DEFAULT ((0)) FOR [FaturaNo]
GO
ALTER TABLE [dbo].[KasaHareketleri] ADD  CONSTRAINT [DF_KasaHareketleri_TahsilatID]  DEFAULT ((0)) FOR [TahsilatID]
GO
ALTER TABLE [dbo].[KasaHareketleri] ADD  CONSTRAINT [DF_KasaHareketleri_GiderID]  DEFAULT ((0)) FOR [GiderID]
GO
ALTER TABLE [dbo].[Kasalar] ADD  CONSTRAINT [DF_Kasa_Durum]  DEFAULT ((1)) FOR [Durum]
GO
ALTER TABLE [dbo].[Kasalar] ADD  CONSTRAINT [DF_Kasa_Tarih]  DEFAULT (getdate()) FOR [Tarih]
GO
ALTER TABLE [dbo].[Kullanici] ADD  CONSTRAINT [DF_Kullanici_Durum]  DEFAULT ((1)) FOR [Durum]
GO
ALTER TABLE [dbo].[SatisIslemleri] ADD  CONSTRAINT [DF_SatisIslemleri_FaturaNo]  DEFAULT (NULL) FOR [FaturaNo]
GO
ALTER TABLE [dbo].[SatisIslemleri] ADD  CONSTRAINT [DF_SatisIslemleri_Tarih]  DEFAULT (getdate()) FOR [Tarih]
GO
ALTER TABLE [dbo].[SatisIslemleri] ADD  CONSTRAINT [DF__SatisIsle__Satis__208CD6FA]  DEFAULT (getdate()) FOR [SatisTarihi]
GO
ALTER TABLE [dbo].[Tahsilatlar] ADD  CONSTRAINT [DF_Tahsilatlar_FaturaNo]  DEFAULT (NULL) FOR [FaturaNo]
GO
ALTER TABLE [dbo].[Tahsilatlar] ADD  CONSTRAINT [DF_Tahsilatlar_Tarih]  DEFAULT (getdate()) FOR [Tarih]
GO
ALTER TABLE [dbo].[UrunFiyatGecmisi] ADD  CONSTRAINT [DF_UrunFiyatGecmisi_DegisiklikTarihi]  DEFAULT (getdate()) FOR [DegisiklikTarihi]
GO
ALTER TABLE [dbo].[Urunler] ADD  CONSTRAINT [DF_Urunler_Barkod]  DEFAULT (NULL) FOR [Barkod]
GO
ALTER TABLE [dbo].[Urunler] ADD  CONSTRAINT [DF_Urunler_AlisFiyat]  DEFAULT ((0.00)) FOR [AlisFiyat]
GO
ALTER TABLE [dbo].[Urunler] ADD  CONSTRAINT [DF_Urunler_StokMiktari]  DEFAULT ((0)) FOR [StokMiktari]
GO
ALTER TABLE [dbo].[Urunler] ADD  CONSTRAINT [DF_Urunler_Durum]  DEFAULT ((1)) FOR [Durum]
GO
ALTER TABLE [dbo].[Urunler] ADD  CONSTRAINT [DF_Urunler_KayitTarihi]  DEFAULT (getdate()) FOR [KayitTarihi]
GO
ALTER TABLE [dbo].[Urunleryedek] ADD  DEFAULT ((0)) FOR [StokMiktari]
GO
ALTER TABLE [dbo].[Urunleryedek] ADD  DEFAULT (getdate()) FOR [EklenmeTarihi]
GO
ALTER TABLE [dbo].[BankaHareketleri]  WITH CHECK ADD  CONSTRAINT [FK_BankaHareket_Bankalar] FOREIGN KEY([BankaID])
REFERENCES [dbo].[Bankalar] ([BankaID])
GO
ALTER TABLE [dbo].[BankaHareketleri] CHECK CONSTRAINT [FK_BankaHareket_Bankalar]
GO
ALTER TABLE [dbo].[BankaHareketleri]  WITH CHECK ADD  CONSTRAINT [FK_BankaHareket_Cari2] FOREIGN KEY([CariID])
REFERENCES [dbo].[Cari] ([CariID])
GO
ALTER TABLE [dbo].[BankaHareketleri] CHECK CONSTRAINT [FK_BankaHareket_Cari2]
GO
ALTER TABLE [dbo].[Cari]  WITH CHECK ADD  CONSTRAINT [FK_Cari_CariTuru] FOREIGN KEY([CariTuru])
REFERENCES [dbo].[CariTuru] ([ID])
GO
ALTER TABLE [dbo].[Cari] CHECK CONSTRAINT [FK_Cari_CariTuru]
GO
ALTER TABLE [dbo].[CariHareketleri]  WITH CHECK ADD  CONSTRAINT [FK_CariHareketleri_Bankalar] FOREIGN KEY([BankaID])
REFERENCES [dbo].[Bankalar] ([BankaID])
GO
ALTER TABLE [dbo].[CariHareketleri] CHECK CONSTRAINT [FK_CariHareketleri_Bankalar]
GO
ALTER TABLE [dbo].[CariHareketleri]  WITH CHECK ADD  CONSTRAINT [FK_CariHareketleri_Cari] FOREIGN KEY([CariID])
REFERENCES [dbo].[Cari] ([CariID])
GO
ALTER TABLE [dbo].[CariHareketleri] CHECK CONSTRAINT [FK_CariHareketleri_Cari]
GO
ALTER TABLE [dbo].[CariHareketleri]  WITH CHECK ADD  CONSTRAINT [FK_CariHareketleri_Kasa] FOREIGN KEY([KasaID])
REFERENCES [dbo].[Kasalar] ([KasaID])
GO
ALTER TABLE [dbo].[CariHareketleri] CHECK CONSTRAINT [FK_CariHareketleri_Kasa]
GO
ALTER TABLE [dbo].[CariHareketleri]  WITH CHECK ADD  CONSTRAINT [FK_CariHareketleri_OdemeTuru] FOREIGN KEY([OdemeID])
REFERENCES [dbo].[OdemeTuru] ([OdemeID])
GO
ALTER TABLE [dbo].[CariHareketleri] CHECK CONSTRAINT [FK_CariHareketleri_OdemeTuru]
GO
ALTER TABLE [dbo].[Gider]  WITH CHECK ADD  CONSTRAINT [FK_GelirGider_Cari] FOREIGN KEY([CariID])
REFERENCES [dbo].[Cari] ([CariID])
GO
ALTER TABLE [dbo].[Gider] CHECK CONSTRAINT [FK_GelirGider_Cari]
GO
ALTER TABLE [dbo].[Gider]  WITH CHECK ADD  CONSTRAINT [FK_GelirGider_GelirGiderTipi] FOREIGN KEY([Tipi])
REFERENCES [dbo].[GiderTipi] ([ID])
GO
ALTER TABLE [dbo].[Gider] CHECK CONSTRAINT [FK_GelirGider_GelirGiderTipi]
GO
ALTER TABLE [dbo].[Gider]  WITH CHECK ADD  CONSTRAINT [FK_GelirGider_Kasa] FOREIGN KEY([KasaID])
REFERENCES [dbo].[Kasalar] ([KasaID])
GO
ALTER TABLE [dbo].[Gider] CHECK CONSTRAINT [FK_GelirGider_Kasa]
GO
ALTER TABLE [dbo].[KasaHareketleri]  WITH CHECK ADD  CONSTRAINT [FK_KasaHareketleri_Cari] FOREIGN KEY([CariID])
REFERENCES [dbo].[Cari] ([CariID])
GO
ALTER TABLE [dbo].[KasaHareketleri] CHECK CONSTRAINT [FK_KasaHareketleri_Cari]
GO
ALTER TABLE [dbo].[KasaHareketleri]  WITH CHECK ADD  CONSTRAINT [FK_KasaHareketleri_Kasa] FOREIGN KEY([KasaID])
REFERENCES [dbo].[Kasalar] ([KasaID])
GO
ALTER TABLE [dbo].[KasaHareketleri] CHECK CONSTRAINT [FK_KasaHareketleri_Kasa]
GO
ALTER TABLE [dbo].[SatisDetaylari]  WITH CHECK ADD  CONSTRAINT [FK__SatisDeta__Fatur__2665ABE1] FOREIGN KEY([FaturaID])
REFERENCES [dbo].[SatisIslemleri] ([FaturaNo])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SatisDetaylari] CHECK CONSTRAINT [FK__SatisDeta__Fatur__2665ABE1]
GO
ALTER TABLE [dbo].[SatisDetaylari]  WITH CHECK ADD  CONSTRAINT [FK__SatisDeta__UrunI__2759D01A] FOREIGN KEY([UrunID])
REFERENCES [dbo].[Urunler] ([UrunID])
GO
ALTER TABLE [dbo].[SatisDetaylari] CHECK CONSTRAINT [FK__SatisDeta__UrunI__2759D01A]
GO
ALTER TABLE [dbo].[SatisIslemleri]  WITH CHECK ADD  CONSTRAINT [FK_SatisIslemleri_Cari] FOREIGN KEY([CariID])
REFERENCES [dbo].[Cari] ([CariID])
GO
ALTER TABLE [dbo].[SatisIslemleri] CHECK CONSTRAINT [FK_SatisIslemleri_Cari]
GO
ALTER TABLE [dbo].[SatisIslemleri]  WITH CHECK ADD  CONSTRAINT [FK_SatisIslemleri_SatisFaturaNo1] FOREIGN KEY([FaturaNo])
REFERENCES [dbo].[SatisFaturaNo] ([FaturaID])
GO
ALTER TABLE [dbo].[SatisIslemleri] CHECK CONSTRAINT [FK_SatisIslemleri_SatisFaturaNo1]
GO
ALTER TABLE [dbo].[UrunEtiketleri]  WITH CHECK ADD  CONSTRAINT [FK_UrunEtiketleri_Urunler] FOREIGN KEY([UrunID])
REFERENCES [dbo].[Urunler] ([UrunID])
GO
ALTER TABLE [dbo].[UrunEtiketleri] CHECK CONSTRAINT [FK_UrunEtiketleri_Urunler]
GO
ALTER TABLE [dbo].[UrunFiyatGecmisi]  WITH CHECK ADD  CONSTRAINT [FK_UrunFiyatGecmisi_Urunler] FOREIGN KEY([UrunID])
REFERENCES [dbo].[Urunler] ([UrunID])
GO
ALTER TABLE [dbo].[UrunFiyatGecmisi] CHECK CONSTRAINT [FK_UrunFiyatGecmisi_Urunler]
GO
ALTER TABLE [dbo].[Urunler]  WITH CHECK ADD  CONSTRAINT [FK_Urunler_UrunKategori1] FOREIGN KEY([KategoriID])
REFERENCES [dbo].[UrunKategori] ([KategoriID])
GO
ALTER TABLE [dbo].[Urunler] CHECK CONSTRAINT [FK_Urunler_UrunKategori1]
GO
ALTER TABLE [dbo].[UrunResimleri]  WITH CHECK ADD  CONSTRAINT [FK_UrunResimleri_Urunler] FOREIGN KEY([UrunID])
REFERENCES [dbo].[Urunler] ([UrunID])
GO
ALTER TABLE [dbo].[UrunResimleri] CHECK CONSTRAINT [FK_UrunResimleri_Urunler]
GO
