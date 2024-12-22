--
-- PostgreSQL database dump
--

-- Dumped from database version 17.0
-- Dumped by pg_dump version 17.0

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: Proje; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE "Proje" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'English_United States.1252';


ALTER DATABASE "Proje" OWNER TO postgres;

\connect "Proje"

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: ekipmandurumuguncelle(integer, character varying); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.ekipmandurumuguncelle(ekipman_numarasi integer, yeni_durum character varying) RETURNS void
    LANGUAGE plpgsql
    AS $$
BEGIN
    UPDATE Ekipman
    SET durum = yeni_durum
    WHERE ekipman_id = ekipman_numarasi;

    RAISE NOTICE 'Ekipman durumu güncellendi.';
END;
$$;


ALTER FUNCTION public.ekipmandurumuguncelle(ekipman_numarasi integer, yeni_durum character varying) OWNER TO postgres;

--
-- Name: ekipmangecerlilikkontrol(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.ekipmangecerlilikkontrol() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN
    IF NOT EkipmanUygunlukKontrol(NEW.ekipman_id) THEN
        RAISE EXCEPTION 'Bu ekipman bozuk veya bakımda, kullanılamaz!';
    END IF;
    RETURN NEW;
END;
$$;


ALTER FUNCTION public.ekipmangecerlilikkontrol() OWNER TO postgres;

--
-- Name: ekipmanuygunlukkontrol(integer); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.ekipmanuygunlukkontrol(ekipman_id_input integer) RETURNS boolean
    LANGUAGE plpgsql
    AS $$
DECLARE
    ekipman_durumu VARCHAR;
BEGIN
    -- Ekipmanın mevcut durumunu al
    SELECT durum INTO ekipman_durumu
    FROM Ekipman
    WHERE ekipman_id = ekipman_id_input;

    -- Durumu kontrol et
    IF ekipman_durumu = 'Kullanılabilir' THEN
        RETURN TRUE; -- Kullanılabilir
    ELSE
        RETURN FALSE; -- Alınamaz
    END IF;
END;
$$;


ALTER FUNCTION public.ekipmanuygunlukkontrol(ekipman_id_input integer) OWNER TO postgres;

--
-- Name: odemegecmisi(integer); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.odemegecmisi(IN kisi_id_input integer)
    LANGUAGE plpgsql
    AS $$
BEGIN
    -- Üyenin ödeme geçmişini göster
    RAISE NOTICE 'Ödeme Geçmişi:';
    PERFORM odeme_id, tutar, odeme_tarihi 
    FROM Odeme
    WHERE kisi_id = kisi_id_input;

    -- Üyenin toplam ödemesini hesapla ve göster
    RAISE NOTICE 'Toplam Ödeme: %', COALESCE(SUM(tutar), 0)
    FROM Odeme
    WHERE kisi_id = kisi_id_input;
END;
$$;


ALTER PROCEDURE public.odemegecmisi(IN kisi_id_input integer) OWNER TO postgres;

--
-- Name: sinifdolumu(integer); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.sinifdolumu(sinif_id_input integer) RETURNS boolean
    LANGUAGE plpgsql
    AS $$
DECLARE
    mevcut_katilim_sayisi INT;
    kapasite INT;
BEGIN
    -- Daha önce oluşturulan fonksiyon ile mevcut katılım sayısını al
    mevcut_katilim_sayisi := SinifKatilimSayisi(sinif_id_input);

    -- Sınıf kapasitesini al
    SELECT kapasite INTO kapasite
    FROM Sinif
    WHERE sinif_id = sinif_id_input;

    -- Kapasiteyi kontrol et
    IF mevcut_katilim_sayisi >= kapasite THEN
        RETURN TRUE; -- Sınıf dolu
    ELSE
        RETURN FALSE; -- Sınıf dolu değil
    END IF;
END;
$$;


ALTER FUNCTION public.sinifdolumu(sinif_id_input integer) OWNER TO postgres;

--
-- Name: sinifkatilimsayisi(integer); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.sinifkatilimsayisi(sinif_numara integer) RETURNS integer
    LANGUAGE plpgsql
    AS $$
DECLARE
    katilim_sayisi INTEGER;
BEGIN
    SELECT COUNT(*) INTO katilim_sayisi
    FROM SinifRezervasyon
    WHERE sinif_id = sinif_numara;

    RETURN katilim_sayisi;
END;
$$;


ALTER FUNCTION public.sinifkatilimsayisi(sinif_numara integer) OWNER TO postgres;

--
-- Name: sinifrezervasyonkontrol(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.sinifrezervasyonkontrol() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN
    IF SinifDoluMu(NEW.sinif_id) THEN
        RAISE EXCEPTION 'Bu sınıf dolu, yeni rezervasyon yapılamaz!';
    END IF;
    RETURN NEW;
END;
$$;


ALTER FUNCTION public.sinifrezervasyonkontrol() OWNER TO postgres;

--
-- Name: toplamodemehesapla(integer); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.toplamodemehesapla(kisi integer) RETURNS numeric
    LANGUAGE plpgsql
    AS $$
DECLARE
    toplam_odeme NUMERIC;
BEGIN
    SELECT COALESCE(SUM(tutar), 0) INTO toplam_odeme
    FROM Odeme
    WHERE kisi_id = kisi;

    RETURN toplam_odeme;
END;
$$;


ALTER FUNCTION public.toplamodemehesapla(kisi integer) OWNER TO postgres;

--
-- Name: uyelikbaslangictarihkontrol(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.uyelikbaslangictarihkontrol() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN
    -- Eğer başlangıç tarihi bugünden küçükse hata fırlat
    IF NEW.baslangic_tarihi < CURRENT_DATE THEN
        RAISE EXCEPTION 'Üyelik başlangıç tarihi geçmiş bir tarih olamaz!';
    END IF;
    RETURN NEW;
END;
$$;


ALTER FUNCTION public.uyelikbaslangictarihkontrol() OWNER TO postgres;

--
-- Name: yarismakatilimcilistesi(integer); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.yarismakatilimcilistesi(yarisma_id_input integer) RETURNS TABLE(kisi_ad character varying, kisi_soyad character varying)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT k.ad, k.soyad
    FROM Kisi k
    JOIN YarismayaKatilim yk ON k.kisi_id = yk.kisi_id
    WHERE yk.yarisma_id = yarisma_id_input;
END;
$$;


ALTER FUNCTION public.yarismakatilimcilistesi(yarisma_id_input integer) OWNER TO postgres;

--
-- Name: yarismayakatilimtarihkontrol(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.yarismayakatilimtarihkontrol() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN
    -- Katılım tarihi, yarışma tarihinden sonraysa hata fırlat
    IF NEW.katilim_tarihi > (SELECT tarih FROM Yarisma WHERE yarisma_id = NEW.yarisma_id) THEN
        RAISE EXCEPTION 'Katılım tarihi, yarışma tarihinden sonraki bir tarih olamaz!';
    END IF;
    RETURN NEW;
END;
$$;


ALTER FUNCTION public.yarismayakatilimtarihkontrol() OWNER TO postgres;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: antrenmanprogrami; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.antrenmanprogrami (
    program_id integer NOT NULL,
    hedef character varying(100),
    baslangic_tarihi date NOT NULL,
    bitis_tarihi date NOT NULL,
    beslenme_id integer,
    CONSTRAINT bitis_tarihi_kontrol CHECK ((bitis_tarihi > baslangic_tarihi))
);


ALTER TABLE public.antrenmanprogrami OWNER TO postgres;

--
-- Name: antrenmanprogrami_program_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.antrenmanprogrami_program_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.antrenmanprogrami_program_id_seq OWNER TO postgres;

--
-- Name: antrenmanprogrami_program_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.antrenmanprogrami_program_id_seq OWNED BY public.antrenmanprogrami.program_id;


--
-- Name: beslenmeprogrami; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.beslenmeprogrami (
    beslenme_id integer NOT NULL,
    hedef character varying(100),
    baslangic_tarihi date NOT NULL,
    bitis_tarihi date NOT NULL,
    kisi_id integer,
    CONSTRAINT bitis_tarihi_kontrol CHECK ((bitis_tarihi > baslangic_tarihi))
);


ALTER TABLE public.beslenmeprogrami OWNER TO postgres;

--
-- Name: beslenmeprogrami_beslenme_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.beslenmeprogrami_beslenme_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.beslenmeprogrami_beslenme_id_seq OWNER TO postgres;

--
-- Name: beslenmeprogrami_beslenme_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.beslenmeprogrami_beslenme_id_seq OWNED BY public.beslenmeprogrami.beslenme_id;


--
-- Name: calisan; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.calisan (
    kisi_id integer NOT NULL,
    uzmanlik character varying(100) NOT NULL,
    deneyim integer,
    maas numeric(10,2),
    CONSTRAINT calisan_deneyim_check CHECK ((deneyim >= 0)),
    CONSTRAINT calisan_maas_check CHECK ((maas > (0)::numeric))
);


ALTER TABLE public.calisan OWNER TO postgres;

--
-- Name: degerlendirme; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.degerlendirme (
    degerlendirme_id integer NOT NULL,
    kisi_id integer,
    sinif_id integer,
    egitmen_id integer,
    puan integer,
    yorum text,
    tarih date NOT NULL,
    CONSTRAINT degerlendirme_puan_check CHECK (((puan >= 0) AND (puan <= 10)))
);


ALTER TABLE public.degerlendirme OWNER TO postgres;

--
-- Name: degerlendirme_degerlendirme_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.degerlendirme_degerlendirme_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.degerlendirme_degerlendirme_id_seq OWNER TO postgres;

--
-- Name: degerlendirme_degerlendirme_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.degerlendirme_degerlendirme_id_seq OWNED BY public.degerlendirme.degerlendirme_id;


--
-- Name: ders; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.ders (
    ders_id integer NOT NULL,
    ders_adi character varying(50) NOT NULL,
    baslangic_saati time without time zone NOT NULL,
    bitis_saati time without time zone NOT NULL
);


ALTER TABLE public.ders OWNER TO postgres;

--
-- Name: ders_ders_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.ders_ders_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.ders_ders_id_seq OWNER TO postgres;

--
-- Name: ders_ders_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.ders_ders_id_seq OWNED BY public.ders.ders_id;


--
-- Name: egitmen; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.egitmen (
    kisi_id integer NOT NULL
);


ALTER TABLE public.egitmen OWNER TO postgres;

--
-- Name: ekipman; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.ekipman (
    ekipman_id integer NOT NULL,
    ekipman_adi character varying(100) NOT NULL,
    bakim_tarihi date,
    durum character varying(50) NOT NULL,
    CONSTRAINT ekipman_durum_check CHECK (((durum)::text = ANY ((ARRAY['Kullanılabilir'::character varying, 'Bakımda'::character varying, 'Bozuk'::character varying])::text[])))
);


ALTER TABLE public.ekipman OWNER TO postgres;

--
-- Name: ekipman_ekipman_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.ekipman_ekipman_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.ekipman_ekipman_id_seq OWNER TO postgres;

--
-- Name: ekipman_ekipman_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.ekipman_ekipman_id_seq OWNED BY public.ekipman.ekipman_id;


--
-- Name: isci; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.isci (
    kisi_id integer NOT NULL
);


ALTER TABLE public.isci OWNER TO postgres;

--
-- Name: kisi; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.kisi (
    kisi_id integer NOT NULL,
    ad character varying(50) NOT NULL,
    soyad character varying(50) NOT NULL,
    eposta character varying(100) NOT NULL,
    telefon character varying(15),
    adres character varying(255),
    saglik_durumu text,
    uye boolean,
    calisan boolean,
    CONSTRAINT eposta_format CHECK (((eposta)::text ~ '^[a-z0-9]+@[a-z]+\.[a-z]{2,3}$'::text))
);


ALTER TABLE public.kisi OWNER TO postgres;

--
-- Name: kisi_kisi_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.kisi_kisi_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.kisi_kisi_id_seq OWNER TO postgres;

--
-- Name: kisi_kisi_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.kisi_kisi_id_seq OWNED BY public.kisi.kisi_id;


--
-- Name: odeme; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.odeme (
    odeme_id integer NOT NULL,
    kisi_id integer,
    tutar numeric(10,2),
    odeme_tarihi date NOT NULL,
    uyelik_id integer,
    CONSTRAINT odeme_tutar_check CHECK ((tutar > (0)::numeric))
);


ALTER TABLE public.odeme OWNER TO postgres;

--
-- Name: odeme_odeme_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.odeme_odeme_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.odeme_odeme_id_seq OWNER TO postgres;

--
-- Name: odeme_odeme_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.odeme_odeme_id_seq OWNED BY public.odeme.odeme_id;


--
-- Name: sinif; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.sinif (
    sinif_id integer NOT NULL,
    sinif_adi character varying(100) NOT NULL,
    kapasite integer,
    egitmen_id integer,
    CONSTRAINT sinif_kapasite_check CHECK ((kapasite > 0))
);


ALTER TABLE public.sinif OWNER TO postgres;

--
-- Name: sinif_sinif_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.sinif_sinif_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.sinif_sinif_id_seq OWNER TO postgres;

--
-- Name: sinif_sinif_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.sinif_sinif_id_seq OWNED BY public.sinif.sinif_id;


--
-- Name: sinifders; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.sinifders (
    sinifders_id integer NOT NULL,
    sinif_id integer,
    ders_id integer
);


ALTER TABLE public.sinifders OWNER TO postgres;

--
-- Name: sinifders_sinifders_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.sinifders_sinifders_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.sinifders_sinifders_id_seq OWNER TO postgres;

--
-- Name: sinifders_sinifders_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.sinifders_sinifders_id_seq OWNED BY public.sinifders.sinifders_id;


--
-- Name: sinifrezervasyon; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.sinifrezervasyon (
    rezervasyon_id integer NOT NULL,
    kisi_id integer,
    sinif_id integer,
    baslangic_tarihi date NOT NULL,
    bitis_tarihi date NOT NULL,
    CONSTRAINT rezervasyon_tarih_kontrol CHECK ((bitis_tarihi > baslangic_tarihi))
);


ALTER TABLE public.sinifrezervasyon OWNER TO postgres;

--
-- Name: sinifrezervasyon_rezervasyon_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.sinifrezervasyon_rezervasyon_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.sinifrezervasyon_rezervasyon_id_seq OWNER TO postgres;

--
-- Name: sinifrezervasyon_rezervasyon_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.sinifrezervasyon_rezervasyon_id_seq OWNED BY public.sinifrezervasyon.rezervasyon_id;


--
-- Name: uye; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.uye (
    kisi_id integer NOT NULL,
    program_id integer
);


ALTER TABLE public.uye OWNER TO postgres;

--
-- Name: uyeekipman; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.uyeekipman (
    uye_ekipman_id integer NOT NULL,
    kisi_id integer,
    ekipman_id integer,
    kullanim_tarihi date NOT NULL
);


ALTER TABLE public.uyeekipman OWNER TO postgres;

--
-- Name: uyeekipman_uye_ekipman_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.uyeekipman_uye_ekipman_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.uyeekipman_uye_ekipman_id_seq OWNER TO postgres;

--
-- Name: uyeekipman_uye_ekipman_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.uyeekipman_uye_ekipman_id_seq OWNED BY public.uyeekipman.uye_ekipman_id;


--
-- Name: uyelik; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.uyelik (
    uyelik_id integer NOT NULL,
    kisi_id integer,
    paket_id integer,
    baslangic_tarihi date,
    bitis_tarihi date,
    CONSTRAINT bitis_tarihi_kontrol CHECK ((bitis_tarihi > baslangic_tarihi))
);


ALTER TABLE public.uyelik OWNER TO postgres;

--
-- Name: uyelik_uyelik_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.uyelik_uyelik_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.uyelik_uyelik_id_seq OWNER TO postgres;

--
-- Name: uyelik_uyelik_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.uyelik_uyelik_id_seq OWNED BY public.uyelik.uyelik_id;


--
-- Name: uyelikpaket; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.uyelikpaket (
    paket_id integer NOT NULL,
    paket_adi character varying(100),
    sure integer,
    fiyat numeric(10,2),
    CONSTRAINT uyelikpaket_fiyat_check CHECK ((fiyat >= (0)::numeric)),
    CONSTRAINT uyelikpaket_sure_check CHECK ((sure > 0))
);


ALTER TABLE public.uyelikpaket OWNER TO postgres;

--
-- Name: uyelikpaket_paket_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.uyelikpaket_paket_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.uyelikpaket_paket_id_seq OWNER TO postgres;

--
-- Name: uyelikpaket_paket_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.uyelikpaket_paket_id_seq OWNED BY public.uyelikpaket.paket_id;


--
-- Name: yarisma; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.yarisma (
    yarisma_id integer NOT NULL,
    ad character varying(100) NOT NULL,
    tarih date NOT NULL,
    yer character varying(100),
    odul character varying(100),
    kazanan character varying(100),
    sponsor character varying(100)
);


ALTER TABLE public.yarisma OWNER TO postgres;

--
-- Name: yarisma_yarisma_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.yarisma_yarisma_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.yarisma_yarisma_id_seq OWNER TO postgres;

--
-- Name: yarisma_yarisma_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.yarisma_yarisma_id_seq OWNED BY public.yarisma.yarisma_id;


--
-- Name: yarismayakatilim; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.yarismayakatilim (
    katilim_id integer NOT NULL,
    kisi_id integer,
    yarisma_id integer,
    katilim_tarihi date NOT NULL
);


ALTER TABLE public.yarismayakatilim OWNER TO postgres;

--
-- Name: yarismayakatilim_katilim_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.yarismayakatilim_katilim_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.yarismayakatilim_katilim_id_seq OWNER TO postgres;

--
-- Name: yarismayakatilim_katilim_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.yarismayakatilim_katilim_id_seq OWNED BY public.yarismayakatilim.katilim_id;


--
-- Name: yoklama; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.yoklama (
    yoklama_id integer NOT NULL,
    ders_id integer,
    kisi_id integer,
    sinif_id integer,
    katilim boolean DEFAULT false,
    tarih date NOT NULL
);


ALTER TABLE public.yoklama OWNER TO postgres;

--
-- Name: yoklama_yoklama_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.yoklama_yoklama_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.yoklama_yoklama_id_seq OWNER TO postgres;

--
-- Name: yoklama_yoklama_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.yoklama_yoklama_id_seq OWNED BY public.yoklama.yoklama_id;


--
-- Name: antrenmanprogrami program_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.antrenmanprogrami ALTER COLUMN program_id SET DEFAULT nextval('public.antrenmanprogrami_program_id_seq'::regclass);


--
-- Name: beslenmeprogrami beslenme_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.beslenmeprogrami ALTER COLUMN beslenme_id SET DEFAULT nextval('public.beslenmeprogrami_beslenme_id_seq'::regclass);


--
-- Name: degerlendirme degerlendirme_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.degerlendirme ALTER COLUMN degerlendirme_id SET DEFAULT nextval('public.degerlendirme_degerlendirme_id_seq'::regclass);


--
-- Name: ders ders_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.ders ALTER COLUMN ders_id SET DEFAULT nextval('public.ders_ders_id_seq'::regclass);


--
-- Name: ekipman ekipman_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.ekipman ALTER COLUMN ekipman_id SET DEFAULT nextval('public.ekipman_ekipman_id_seq'::regclass);


--
-- Name: kisi kisi_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.kisi ALTER COLUMN kisi_id SET DEFAULT nextval('public.kisi_kisi_id_seq'::regclass);


--
-- Name: odeme odeme_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.odeme ALTER COLUMN odeme_id SET DEFAULT nextval('public.odeme_odeme_id_seq'::regclass);


--
-- Name: sinif sinif_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.sinif ALTER COLUMN sinif_id SET DEFAULT nextval('public.sinif_sinif_id_seq'::regclass);


--
-- Name: sinifders sinifders_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.sinifders ALTER COLUMN sinifders_id SET DEFAULT nextval('public.sinifders_sinifders_id_seq'::regclass);


--
-- Name: sinifrezervasyon rezervasyon_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.sinifrezervasyon ALTER COLUMN rezervasyon_id SET DEFAULT nextval('public.sinifrezervasyon_rezervasyon_id_seq'::regclass);


--
-- Name: uyeekipman uye_ekipman_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.uyeekipman ALTER COLUMN uye_ekipman_id SET DEFAULT nextval('public.uyeekipman_uye_ekipman_id_seq'::regclass);


--
-- Name: uyelik uyelik_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.uyelik ALTER COLUMN uyelik_id SET DEFAULT nextval('public.uyelik_uyelik_id_seq'::regclass);


--
-- Name: uyelikpaket paket_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.uyelikpaket ALTER COLUMN paket_id SET DEFAULT nextval('public.uyelikpaket_paket_id_seq'::regclass);


--
-- Name: yarisma yarisma_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.yarisma ALTER COLUMN yarisma_id SET DEFAULT nextval('public.yarisma_yarisma_id_seq'::regclass);


--
-- Name: yarismayakatilim katilim_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.yarismayakatilim ALTER COLUMN katilim_id SET DEFAULT nextval('public.yarismayakatilim_katilim_id_seq'::regclass);


--
-- Name: yoklama yoklama_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.yoklama ALTER COLUMN yoklama_id SET DEFAULT nextval('public.yoklama_yoklama_id_seq'::regclass);


--
-- Data for Name: antrenmanprogrami; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.antrenmanprogrami (program_id, hedef, baslangic_tarihi, bitis_tarihi, beslenme_id) FROM stdin;
1	Kilo Verme	2024-09-10	2024-09-11	1
\.


--
-- Data for Name: beslenmeprogrami; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.beslenmeprogrami (beslenme_id, hedef, baslangic_tarihi, bitis_tarihi, kisi_id) FROM stdin;
1	Kilo Verme	2024-09-10	2024-09-11	2
\.


--
-- Data for Name: calisan; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.calisan (kisi_id, uzmanlik, deneyim, maas) FROM stdin;
2	Fitness Eğitmeni	5	12000.50
3	Temizlikçi	3	10000.00
5	Siber Güvenlik	7	14000.75
\.


--
-- Data for Name: degerlendirme; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.degerlendirme (degerlendirme_id, kisi_id, sinif_id, egitmen_id, puan, yorum, tarih) FROM stdin;
1	1	1	2	10	Eğitmenimi ve burayı çok sevdim. Harika!	2024-10-10
\.


--
-- Data for Name: ders; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.ders (ders_id, ders_adi, baslangic_saati, bitis_saati) FROM stdin;
1	Kilo Verme Sanatı	10:00:00	12:00:00
\.


--
-- Data for Name: egitmen; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.egitmen (kisi_id) FROM stdin;
2
\.


--
-- Data for Name: ekipman; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.ekipman (ekipman_id, ekipman_adi, bakim_tarihi, durum) FROM stdin;
1	Yağ Yaktıran Alet 4000	2024-01-09	Kullanılabilir
\.


--
-- Data for Name: isci; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.isci (kisi_id) FROM stdin;
3
5
\.


--
-- Data for Name: kisi; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.kisi (kisi_id, ad, soyad, eposta, telefon, adres, saglik_durumu, uye, calisan) FROM stdin;
1	Ali	Yılmaz	aliyilmaz@example.com	5551234567	Ankara, Türkiye	Sağlıklı	t	f
2	Ayşe	Demir	aysedemir@example.com	5329876543	İstanbul, Türkiye	Alerji	f	t
3	Mehmet	Kara	mehmetkara@example.com	\N	İzmir, Türkiye	Sağlıklı	t	t
4	Fatma	Şahin	fatmasahin@example.com	5455556677	\N	Kronik hastalık	f	f
5	Can	Turan	canturan@example.com	5302223344	Bursa, Türkiye	\N	t	t
\.


--
-- Data for Name: odeme; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.odeme (odeme_id, kisi_id, tutar, odeme_tarihi, uyelik_id) FROM stdin;
1	1	4000.00	2024-09-10	1
\.


--
-- Data for Name: sinif; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.sinif (sinif_id, sinif_adi, kapasite, egitmen_id) FROM stdin;
1	Kilo Verme Sınıfı	20	2
\.


--
-- Data for Name: sinifders; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.sinifders (sinifders_id, sinif_id, ders_id) FROM stdin;
1	1	1
\.


--
-- Data for Name: sinifrezervasyon; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.sinifrezervasyon (rezervasyon_id, kisi_id, sinif_id, baslangic_tarihi, bitis_tarihi) FROM stdin;
1	1	1	2024-09-10	2024-09-11
\.


--
-- Data for Name: uye; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.uye (kisi_id, program_id) FROM stdin;
1	1
3	1
5	1
\.


--
-- Data for Name: uyeekipman; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.uyeekipman (uye_ekipman_id, kisi_id, ekipman_id, kullanim_tarihi) FROM stdin;
1	1	1	2024-10-09
\.


--
-- Data for Name: uyelik; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.uyelik (uyelik_id, kisi_id, paket_id, baslangic_tarihi, bitis_tarihi) FROM stdin;
1	1	1	2024-09-10	2024-09-11
\.


--
-- Data for Name: uyelikpaket; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.uyelikpaket (paket_id, paket_adi, sure, fiyat) FROM stdin;
1	Kilo Verme Deneme Paketi	30	4000.00
\.


--
-- Data for Name: yarisma; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.yarisma (yarisma_id, ad, tarih, yer, odul, kazanan, sponsor) FROM stdin;
1	10Km Koşu Yarışması	2024-10-10	İstanbul	50.000TL	\N	\N
\.


--
-- Data for Name: yarismayakatilim; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.yarismayakatilim (katilim_id, kisi_id, yarisma_id, katilim_tarihi) FROM stdin;
1	1	1	2024-09-10
\.


--
-- Data for Name: yoklama; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.yoklama (yoklama_id, ders_id, kisi_id, sinif_id, katilim, tarih) FROM stdin;
1	1	1	1	t	2024-10-10
\.


--
-- Name: antrenmanprogrami_program_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.antrenmanprogrami_program_id_seq', 1, true);


--
-- Name: beslenmeprogrami_beslenme_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.beslenmeprogrami_beslenme_id_seq', 1, true);


--
-- Name: degerlendirme_degerlendirme_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.degerlendirme_degerlendirme_id_seq', 1, true);


--
-- Name: ders_ders_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.ders_ders_id_seq', 1, false);


--
-- Name: ekipman_ekipman_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.ekipman_ekipman_id_seq', 1, false);


--
-- Name: kisi_kisi_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.kisi_kisi_id_seq', 5, true);


--
-- Name: odeme_odeme_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.odeme_odeme_id_seq', 1, true);


--
-- Name: sinif_sinif_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.sinif_sinif_id_seq', 1, false);


--
-- Name: sinifders_sinifders_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.sinifders_sinifders_id_seq', 1, true);


--
-- Name: sinifrezervasyon_rezervasyon_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.sinifrezervasyon_rezervasyon_id_seq', 1, true);


--
-- Name: uyeekipman_uye_ekipman_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.uyeekipman_uye_ekipman_id_seq', 1, true);


--
-- Name: uyelik_uyelik_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.uyelik_uyelik_id_seq', 1, true);


--
-- Name: uyelikpaket_paket_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.uyelikpaket_paket_id_seq', 1, false);


--
-- Name: yarisma_yarisma_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.yarisma_yarisma_id_seq', 1, true);


--
-- Name: yarismayakatilim_katilim_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.yarismayakatilim_katilim_id_seq', 1, true);


--
-- Name: yoklama_yoklama_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.yoklama_yoklama_id_seq', 1, true);


--
-- Name: antrenmanprogrami antrenmanprogrami_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.antrenmanprogrami
    ADD CONSTRAINT antrenmanprogrami_pkey PRIMARY KEY (program_id);


--
-- Name: beslenmeprogrami beslenmeprogrami_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.beslenmeprogrami
    ADD CONSTRAINT beslenmeprogrami_pkey PRIMARY KEY (beslenme_id);


--
-- Name: calisan calisan_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.calisan
    ADD CONSTRAINT calisan_pkey PRIMARY KEY (kisi_id);


--
-- Name: degerlendirme degerlendirme_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.degerlendirme
    ADD CONSTRAINT degerlendirme_pkey PRIMARY KEY (degerlendirme_id);


--
-- Name: ders ders_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.ders
    ADD CONSTRAINT ders_pkey PRIMARY KEY (ders_id);


--
-- Name: egitmen egitmen_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.egitmen
    ADD CONSTRAINT egitmen_pkey PRIMARY KEY (kisi_id);


--
-- Name: ekipman ekipman_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.ekipman
    ADD CONSTRAINT ekipman_pkey PRIMARY KEY (ekipman_id);


--
-- Name: isci isci_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.isci
    ADD CONSTRAINT isci_pkey PRIMARY KEY (kisi_id);


--
-- Name: kisi kisi_eposta_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.kisi
    ADD CONSTRAINT kisi_eposta_key UNIQUE (eposta);


--
-- Name: kisi kisi_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.kisi
    ADD CONSTRAINT kisi_pkey PRIMARY KEY (kisi_id);


--
-- Name: kisi kisi_telefon_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.kisi
    ADD CONSTRAINT kisi_telefon_key UNIQUE (telefon);


--
-- Name: odeme odeme_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.odeme
    ADD CONSTRAINT odeme_pkey PRIMARY KEY (odeme_id);


--
-- Name: sinif sinif_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.sinif
    ADD CONSTRAINT sinif_pkey PRIMARY KEY (sinif_id);


--
-- Name: sinifders sinifders_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.sinifders
    ADD CONSTRAINT sinifders_pkey PRIMARY KEY (sinifders_id);


--
-- Name: sinifrezervasyon sinifrezervasyon_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.sinifrezervasyon
    ADD CONSTRAINT sinifrezervasyon_pkey PRIMARY KEY (rezervasyon_id);


--
-- Name: uye uye_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.uye
    ADD CONSTRAINT uye_pkey PRIMARY KEY (kisi_id);


--
-- Name: uyeekipman uyeekipman_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.uyeekipman
    ADD CONSTRAINT uyeekipman_pkey PRIMARY KEY (uye_ekipman_id);


--
-- Name: uyelik uyelik_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.uyelik
    ADD CONSTRAINT uyelik_pkey PRIMARY KEY (uyelik_id);


--
-- Name: uyelikpaket uyelikpaket_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.uyelikpaket
    ADD CONSTRAINT uyelikpaket_pkey PRIMARY KEY (paket_id);


--
-- Name: yarisma yarisma_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.yarisma
    ADD CONSTRAINT yarisma_pkey PRIMARY KEY (yarisma_id);


--
-- Name: yarismayakatilim yarismayakatilim_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.yarismayakatilim
    ADD CONSTRAINT yarismayakatilim_pkey PRIMARY KEY (katilim_id);


--
-- Name: yoklama yoklama_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.yoklama
    ADD CONSTRAINT yoklama_pkey PRIMARY KEY (yoklama_id);


--
-- Name: uyelik triggeruyelikbaslangictarihkontrol; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER triggeruyelikbaslangictarihkontrol BEFORE INSERT ON public.uyelik FOR EACH ROW EXECUTE FUNCTION public.uyelikbaslangictarihkontrol();


--
-- Name: yarismayakatilim triggeryarismayakatilimtarihkontrol; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER triggeryarismayakatilimtarihkontrol BEFORE INSERT ON public.yarismayakatilim FOR EACH ROW EXECUTE FUNCTION public.yarismayakatilimtarihkontrol();


--
-- Name: antrenmanprogrami antrenmanprogrami_beslenme_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.antrenmanprogrami
    ADD CONSTRAINT antrenmanprogrami_beslenme_id_fkey FOREIGN KEY (beslenme_id) REFERENCES public.beslenmeprogrami(beslenme_id);


--
-- Name: beslenmeprogrami beslenmeprogrami_kisi_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.beslenmeprogrami
    ADD CONSTRAINT beslenmeprogrami_kisi_id_fkey FOREIGN KEY (kisi_id) REFERENCES public.egitmen(kisi_id);


--
-- Name: calisan calisan_kisi_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.calisan
    ADD CONSTRAINT calisan_kisi_id_fkey FOREIGN KEY (kisi_id) REFERENCES public.kisi(kisi_id);


--
-- Name: degerlendirme degerlendirme_egitmen_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.degerlendirme
    ADD CONSTRAINT degerlendirme_egitmen_id_fkey FOREIGN KEY (egitmen_id) REFERENCES public.egitmen(kisi_id);


--
-- Name: degerlendirme degerlendirme_kisi_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.degerlendirme
    ADD CONSTRAINT degerlendirme_kisi_id_fkey FOREIGN KEY (kisi_id) REFERENCES public.uye(kisi_id);


--
-- Name: degerlendirme degerlendirme_sinif_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.degerlendirme
    ADD CONSTRAINT degerlendirme_sinif_id_fkey FOREIGN KEY (sinif_id) REFERENCES public.sinif(sinif_id);


--
-- Name: egitmen egitmen_kisi_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.egitmen
    ADD CONSTRAINT egitmen_kisi_id_fkey FOREIGN KEY (kisi_id) REFERENCES public.calisan(kisi_id);


--
-- Name: isci isci_kisi_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.isci
    ADD CONSTRAINT isci_kisi_id_fkey FOREIGN KEY (kisi_id) REFERENCES public.calisan(kisi_id);


--
-- Name: odeme odeme_kisi_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.odeme
    ADD CONSTRAINT odeme_kisi_id_fkey FOREIGN KEY (kisi_id) REFERENCES public.uye(kisi_id);


--
-- Name: odeme odeme_uyelik_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.odeme
    ADD CONSTRAINT odeme_uyelik_id_fkey FOREIGN KEY (uyelik_id) REFERENCES public.uyelik(uyelik_id);


--
-- Name: sinif sinif_egitmen_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.sinif
    ADD CONSTRAINT sinif_egitmen_id_fkey FOREIGN KEY (egitmen_id) REFERENCES public.egitmen(kisi_id);


--
-- Name: sinifders sinifders_ders_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.sinifders
    ADD CONSTRAINT sinifders_ders_id_fkey FOREIGN KEY (ders_id) REFERENCES public.ders(ders_id);


--
-- Name: sinifders sinifders_sinif_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.sinifders
    ADD CONSTRAINT sinifders_sinif_id_fkey FOREIGN KEY (sinif_id) REFERENCES public.sinif(sinif_id);


--
-- Name: sinifrezervasyon sinifrezervasyon_kisi_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.sinifrezervasyon
    ADD CONSTRAINT sinifrezervasyon_kisi_id_fkey FOREIGN KEY (kisi_id) REFERENCES public.uye(kisi_id);


--
-- Name: sinifrezervasyon sinifrezervasyon_sinif_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.sinifrezervasyon
    ADD CONSTRAINT sinifrezervasyon_sinif_id_fkey FOREIGN KEY (sinif_id) REFERENCES public.sinif(sinif_id);


--
-- Name: uye uye_kisi_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.uye
    ADD CONSTRAINT uye_kisi_id_fkey FOREIGN KEY (kisi_id) REFERENCES public.kisi(kisi_id);


--
-- Name: uye uye_program_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.uye
    ADD CONSTRAINT uye_program_id_fkey FOREIGN KEY (program_id) REFERENCES public.antrenmanprogrami(program_id);


--
-- Name: uyeekipman uyeekipman_ekipman_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.uyeekipman
    ADD CONSTRAINT uyeekipman_ekipman_id_fkey FOREIGN KEY (ekipman_id) REFERENCES public.ekipman(ekipman_id);


--
-- Name: uyeekipman uyeekipman_kisi_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.uyeekipman
    ADD CONSTRAINT uyeekipman_kisi_id_fkey FOREIGN KEY (kisi_id) REFERENCES public.uye(kisi_id);


--
-- Name: uyelik uyelik_kisi_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.uyelik
    ADD CONSTRAINT uyelik_kisi_id_fkey FOREIGN KEY (kisi_id) REFERENCES public.uye(kisi_id);


--
-- Name: uyelik uyelik_paket_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.uyelik
    ADD CONSTRAINT uyelik_paket_id_fkey FOREIGN KEY (paket_id) REFERENCES public.uyelikpaket(paket_id);


--
-- Name: yarismayakatilim yarismayakatilim_kisi_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.yarismayakatilim
    ADD CONSTRAINT yarismayakatilim_kisi_id_fkey FOREIGN KEY (kisi_id) REFERENCES public.kisi(kisi_id);


--
-- Name: yarismayakatilim yarismayakatilim_yarisma_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.yarismayakatilim
    ADD CONSTRAINT yarismayakatilim_yarisma_id_fkey FOREIGN KEY (yarisma_id) REFERENCES public.yarisma(yarisma_id);


--
-- Name: yoklama yoklama_ders_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.yoklama
    ADD CONSTRAINT yoklama_ders_id_fkey FOREIGN KEY (ders_id) REFERENCES public.ders(ders_id);


--
-- Name: yoklama yoklama_kisi_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.yoklama
    ADD CONSTRAINT yoklama_kisi_id_fkey FOREIGN KEY (kisi_id) REFERENCES public.uye(kisi_id);


--
-- Name: yoklama yoklama_sinif_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.yoklama
    ADD CONSTRAINT yoklama_sinif_id_fkey FOREIGN KEY (sinif_id) REFERENCES public.sinif(sinif_id);


--
-- PostgreSQL database dump complete
--

