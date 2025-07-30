
--
-- CLEAN
--
DO $$
DECLARE
    r RECORD;
BEGIN
    FOR r IN (
        SELECT nspname
        FROM pg_namespace
        WHERE nspname NOT LIKE 'pg_%'
          AND nspname <> 'information_schema'
    ) LOOP
        EXECUTE 'DROP SCHEMA IF EXISTS ' || quote_ident(r.nspname) || ' CASCADE';
    END LOOP;
END $$;


--
-- PostgreSQL database dump
--

-- Dumped from database version 17.5 (Debian 17.5-1.pgdg120+1)
-- Dumped by pg_dump version 17.5

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
-- Name: auth; Type: SCHEMA; Schema: -; Owner: admin
--

CREATE SCHEMA auth;
ALTER SCHEMA auth OWNER TO admin;

--
-- Name: briefingcon; Type: SCHEMA; Schema: -; Owner: admin
--

CREATE SCHEMA briefingcon;


ALTER SCHEMA briefingcon OWNER TO admin;

--
-- Name: generic; Type: SCHEMA; Schema: -; Owner: admin
--

CREATE SCHEMA generic;


ALTER SCHEMA generic OWNER TO admin;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: ruolo; Type: TABLE; Schema: auth; Owner: admin
--

CREATE TABLE auth.ruolo (
    id integer NOT NULL,
    nome text NOT NULL
);


ALTER TABLE auth.ruolo OWNER TO admin;

--
-- Name: ruolo_id_seq; Type: SEQUENCE; Schema: auth; Owner: admin
--

CREATE SEQUENCE auth.ruolo_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE auth.ruolo_id_seq OWNER TO admin;

--
-- Name: ruolo_id_seq; Type: SEQUENCE OWNED BY; Schema: auth; Owner: admin
--

ALTER SEQUENCE auth.ruolo_id_seq OWNED BY auth.ruolo.id;


--
-- Name: utenteruolo; Type: TABLE; Schema: auth; Owner: admin
--

CREATE TABLE auth.utenteruolo (
    id integer NOT NULL,
    username text NOT NULL,
    ruoloid integer NOT NULL
);


ALTER TABLE auth.utenteruolo OWNER TO admin;

--
-- Name: utenteruolo_id_seq; Type: SEQUENCE; Schema: auth; Owner: admin
--

CREATE SEQUENCE auth.utenteruolo_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE auth.utenteruolo_id_seq OWNER TO admin;

--
-- Name: utenteruolo_id_seq; Type: SEQUENCE OWNED BY; Schema: auth; Owner: admin
--

ALTER SEQUENCE auth.utenteruolo_id_seq OWNED BY auth.utenteruolo.id;


--
-- Name: nuclei; Type: TABLE; Schema: briefingcon; Owner: admin
--

CREATE TABLE briefingcon.nuclei (
    id integer NOT NULL,
    nome text NOT NULL
);


ALTER TABLE briefingcon.nuclei OWNER TO admin;

--
-- Name: nuclei_id_seq; Type: SEQUENCE; Schema: briefingcon; Owner: admin
--

CREATE SEQUENCE briefingcon.nuclei_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE briefingcon.nuclei_id_seq OWNER TO admin;

--
-- Name: nuclei_id_seq; Type: SEQUENCE OWNED BY; Schema: briefingcon; Owner: admin
--

ALTER SEQUENCE briefingcon.nuclei_id_seq OWNED BY briefingcon.nuclei.id;


--
-- Name: organici; Type: TABLE; Schema: briefingcon; Owner: admin
--

CREATE TABLE briefingcon.organici (
    id integer NOT NULL,
    anno integer NOT NULL,
    tipologiaid integer NOT NULL,
    qtarisorseumaneorganico integer,
    qtarisorsemezziorganico integer,
    qtarisorseumanereali integer,
    qtarisorsemezzireali integer
);


ALTER TABLE briefingcon.organici OWNER TO admin;

--
-- Name: organici_id_seq; Type: SEQUENCE; Schema: briefingcon; Owner: admin
--

CREATE SEQUENCE briefingcon.organici_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE briefingcon.organici_id_seq OWNER TO admin;

--
-- Name: organici_id_seq; Type: SEQUENCE OWNED BY; Schema: briefingcon; Owner: admin
--

ALTER SEQUENCE briefingcon.organici_id_seq OWNED BY briefingcon.organici.id;


--
-- Name: organicidisponibili; Type: TABLE; Schema: briefingcon; Owner: admin
--

CREATE TABLE briefingcon.organicidisponibili (
    id integer NOT NULL,
    tipologiaid integer NOT NULL,
    servizioid integer NOT NULL,
    qtarisorseumanedisponibili integer,
    qtarisorsemezzidisponibili integer
);


ALTER TABLE briefingcon.organicidisponibili OWNER TO admin;

--
-- Name: organicidisponibili_id_seq; Type: SEQUENCE; Schema: briefingcon; Owner: admin
--

CREATE SEQUENCE briefingcon.organicidisponibili_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE briefingcon.organicidisponibili_id_seq OWNER TO admin;

--
-- Name: organicidisponibili_id_seq; Type: SEQUENCE OWNED BY; Schema: briefingcon; Owner: admin
--

ALTER SEQUENCE briefingcon.organicidisponibili_id_seq OWNED BY briefingcon.organicidisponibili.id;


--
-- Name: organicitipologie; Type: TABLE; Schema: briefingcon; Owner: admin
--

CREATE TABLE briefingcon.organicitipologie (
    id integer NOT NULL,
    nome text NOT NULL,
    sedeid integer NOT NULL,
    qualificaid integer,
    nucleoid integer,
    specializzazioneid integer
);


ALTER TABLE briefingcon.organicitipologie OWNER TO admin;

--
-- Name: organicitipologie_id_seq; Type: SEQUENCE; Schema: briefingcon; Owner: admin
--

CREATE SEQUENCE briefingcon.organicitipologie_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE briefingcon.organicitipologie_id_seq OWNER TO admin;

--
-- Name: organicitipologie_id_seq; Type: SEQUENCE OWNED BY; Schema: briefingcon; Owner: admin
--

ALTER SEQUENCE briefingcon.organicitipologie_id_seq OWNED BY briefingcon.organicitipologie.id;


--
-- Name: qualifiche; Type: TABLE; Schema: briefingcon; Owner: admin
--

CREATE TABLE briefingcon.qualifiche (
    id integer NOT NULL,
    nome text NOT NULL,
    categoria text
);


ALTER TABLE briefingcon.qualifiche OWNER TO admin;

--
-- Name: qualifiche_id_seq; Type: SEQUENCE; Schema: briefingcon; Owner: admin
--

CREATE SEQUENCE briefingcon.qualifiche_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE briefingcon.qualifiche_id_seq OWNER TO admin;

--
-- Name: qualifiche_id_seq; Type: SEQUENCE OWNED BY; Schema: briefingcon; Owner: admin
--

ALTER SEQUENCE briefingcon.qualifiche_id_seq OWNED BY briefingcon.qualifiche.id;


--
-- Name: servizi; Type: TABLE; Schema: briefingcon; Owner: admin
--

CREATE TABLE briefingcon.servizi (
    id integer NOT NULL,
    data date NOT NULL,
    notturno boolean,
    username text NOT NULL,
    turno character(1) NOT NULL,
	sede varchar(50)
);


ALTER TABLE briefingcon.servizi OWNER TO admin;

--
-- Name: servizi_id_seq; Type: SEQUENCE; Schema: briefingcon; Owner: admin
--

CREATE SEQUENCE briefingcon.servizi_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE briefingcon.servizi_id_seq OWNER TO admin;

--
-- Name: servizi_id_seq; Type: SEQUENCE OWNED BY; Schema: briefingcon; Owner: admin
--

ALTER SEQUENCE briefingcon.servizi_id_seq OWNED BY briefingcon.servizi.id;


--
-- Name: specializzazioni; Type: TABLE; Schema: briefingcon; Owner: admin
--

CREATE TABLE briefingcon.specializzazioni (
    id integer NOT NULL,
    nome text NOT NULL,
    categoria text
);


ALTER TABLE briefingcon.specializzazioni OWNER TO admin;

--
-- Name: specializzazioni_id_seq; Type: SEQUENCE; Schema: briefingcon; Owner: admin
--

CREATE SEQUENCE briefingcon.specializzazioni_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE briefingcon.specializzazioni_id_seq OWNER TO admin;

--
-- Name: specializzazioni_id_seq; Type: SEQUENCE OWNED BY; Schema: briefingcon; Owner: admin
--

ALTER SEQUENCE briefingcon.specializzazioni_id_seq OWNED BY briefingcon.specializzazioni.id;


--
-- Name: sedi; Type: TABLE; Schema: generic; Owner: admin
--

CREATE TABLE generic.sedi (
    id integer NOT NULL,
    nome text NOT NULL,
    tipologiaid integer,
    provinciasigla text,
    cap text,
    citta text,
    indirizzo text,
    civico text,
    parentid integer
);


ALTER TABLE generic.sedi OWNER TO admin;

--
-- Name: sedi_id_seq; Type: SEQUENCE; Schema: generic; Owner: admin
--

CREATE SEQUENCE generic.sedi_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE generic.sedi_id_seq OWNER TO admin;

--
-- Name: sedi_id_seq; Type: SEQUENCE OWNED BY; Schema: generic; Owner: admin
--

ALTER SEQUENCE generic.sedi_id_seq OWNED BY generic.sedi.id;


--
-- Name: seditipologie; Type: TABLE; Schema: generic; Owner: admin
--

CREATE TABLE generic.seditipologie (
    id integer NOT NULL,
    nome text NOT NULL
);


ALTER TABLE generic.seditipologie OWNER TO admin;

--
-- Name: seditipologie_id_seq; Type: SEQUENCE; Schema: generic; Owner: admin
--

CREATE SEQUENCE generic.seditipologie_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE generic.seditipologie_id_seq OWNER TO admin;

--
-- Name: seditipologie_id_seq; Type: SEQUENCE OWNED BY; Schema: generic; Owner: admin
--

ALTER SEQUENCE generic.seditipologie_id_seq OWNED BY generic.seditipologie.id;


--
-- Name: ruolo id; Type: DEFAULT; Schema: auth; Owner: admin
--

ALTER TABLE ONLY auth.ruolo ALTER COLUMN id SET DEFAULT nextval('auth.ruolo_id_seq'::regclass);


--
-- Name: utenteruolo id; Type: DEFAULT; Schema: auth; Owner: admin
--

ALTER TABLE ONLY auth.utenteruolo ALTER COLUMN id SET DEFAULT nextval('auth.utenteruolo_id_seq'::regclass);


--
-- Name: nuclei id; Type: DEFAULT; Schema: briefingcon; Owner: admin
--

ALTER TABLE ONLY briefingcon.nuclei ALTER COLUMN id SET DEFAULT nextval('briefingcon.nuclei_id_seq'::regclass);


--
-- Name: organici id; Type: DEFAULT; Schema: briefingcon; Owner: admin
--

ALTER TABLE ONLY briefingcon.organici ALTER COLUMN id SET DEFAULT nextval('briefingcon.organici_id_seq'::regclass);


--
-- Name: organicidisponibili id; Type: DEFAULT; Schema: briefingcon; Owner: admin
--

ALTER TABLE ONLY briefingcon.organicidisponibili ALTER COLUMN id SET DEFAULT nextval('briefingcon.organicidisponibili_id_seq'::regclass);


--
-- Name: organicitipologie id; Type: DEFAULT; Schema: briefingcon; Owner: admin
--

ALTER TABLE ONLY briefingcon.organicitipologie ALTER COLUMN id SET DEFAULT nextval('briefingcon.organicitipologie_id_seq'::regclass);


--
-- Name: qualifiche id; Type: DEFAULT; Schema: briefingcon; Owner: admin
--

ALTER TABLE ONLY briefingcon.qualifiche ALTER COLUMN id SET DEFAULT nextval('briefingcon.qualifiche_id_seq'::regclass);


--
-- Name: servizi id; Type: DEFAULT; Schema: briefingcon; Owner: admin
--

ALTER TABLE ONLY briefingcon.servizi ALTER COLUMN id SET DEFAULT nextval('briefingcon.servizi_id_seq'::regclass);


--
-- Name: specializzazioni id; Type: DEFAULT; Schema: briefingcon; Owner: admin
--

ALTER TABLE ONLY briefingcon.specializzazioni ALTER COLUMN id SET DEFAULT nextval('briefingcon.specializzazioni_id_seq'::regclass);


--
-- Name: sedi id; Type: DEFAULT; Schema: generic; Owner: admin
--

ALTER TABLE ONLY generic.sedi ALTER COLUMN id SET DEFAULT nextval('generic.sedi_id_seq'::regclass);


--
-- Name: seditipologie id; Type: DEFAULT; Schema: generic; Owner: admin
--

ALTER TABLE ONLY generic.seditipologie ALTER COLUMN id SET DEFAULT nextval('generic.seditipologie_id_seq'::regclass);


--
-- Data for Name: ruolo; Type: TABLE DATA; Schema: auth; Owner: admin
--

INSERT INTO auth.ruolo VALUES (1, 'Admin');
INSERT INTO auth.ruolo VALUES (10, 'Capo Distaccamento');


--
-- Data for Name: utenteruolo; Type: TABLE DATA; Schema: auth; Owner: admin
--

INSERT INTO auth.utenteruolo VALUES (1, 'tommaso.tomasetti', 1);
INSERT INTO auth.utenteruolo VALUES (2, 'tommaso.tomasetti', 10);


--
-- Data for Name: nuclei; Type: TABLE DATA; Schema: briefingcon; Owner: admin
--

INSERT INTO briefingcon.nuclei VALUES (1, 'NBCR');


--
-- Data for Name: organici; Type: TABLE DATA; Schema: briefingcon; Owner: admin
--

INSERT INTO briefingcon.organici VALUES (1, 2025, 1, 5, 2, 4, 1);


--
-- Data for Name: organicidisponibili; Type: TABLE DATA; Schema: briefingcon; Owner: admin
--



--
-- Data for Name: organicitipologie; Type: TABLE DATA; Schema: briefingcon; Owner: admin
--

INSERT INTO briefingcon.organicitipologie VALUES (1, 'SAF Livello 1', 2, NULL, NULL, 1);


--
-- Data for Name: qualifiche; Type: TABLE DATA; Schema: briefingcon; Owner: admin
--

INSERT INTO briefingcon.qualifiche VALUES (1, 'Q1', 'Categoria1');
INSERT INTO briefingcon.qualifiche VALUES (2, 'Q2', 'Categoria12');


--
-- Data for Name: servizi; Type: TABLE DATA; Schema: briefingcon; Owner: admin
--



--
-- Data for Name: specializzazioni; Type: TABLE DATA; Schema: briefingcon; Owner: admin
--

INSERT INTO briefingcon.specializzazioni VALUES (1, 'SAF', 'Livello 1');
INSERT INTO briefingcon.specializzazioni VALUES (2, 'SAF', 'Livello 2');


--
-- Data for Name: sedi; Type: TABLE DATA; Schema: generic; Owner: admin
--

INSERT INTO generic.sedi VALUES (1, 'Direzione Marche', 1, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO generic.sedi VALUES (2, 'Comando Ancona', 2, NULL, NULL, NULL, NULL, NULL, 1);
INSERT INTO generic.sedi VALUES (3, 'Aeroporto', 3, NULL, NULL, NULL, NULL, NULL, 2);
INSERT INTO generic.sedi VALUES (4, 'Arcevia', 3, NULL, NULL, NULL, NULL, NULL, 2);
INSERT INTO generic.sedi VALUES (5, 'Jesi', 3, NULL, NULL, NULL, NULL, NULL, 2);
INSERT INTO generic.sedi VALUES (6, 'Fabriano', 3, NULL, NULL, NULL, NULL, NULL, 2);
INSERT INTO generic.sedi VALUES (7, 'Jesi', 3, NULL, NULL, NULL, NULL, NULL, 2);
INSERT INTO generic.sedi VALUES (8, 'Osimo', 3, NULL, NULL, NULL, NULL, NULL, 2);
INSERT INTO generic.sedi VALUES (9, 'Porto', 3, NULL, NULL, NULL, NULL, NULL, 2);


--
-- Data for Name: seditipologie; Type: TABLE DATA; Schema: generic; Owner: admin
--

INSERT INTO generic.seditipologie VALUES (1, 'Direzione');
INSERT INTO generic.seditipologie VALUES (2, 'Comando');
INSERT INTO generic.seditipologie VALUES (3, 'Distaccamento');


--
-- Name: ruolo_id_seq; Type: SEQUENCE SET; Schema: auth; Owner: admin
--

SELECT pg_catalog.setval('auth.ruolo_id_seq', 10, true);


--
-- Name: utenteruolo_id_seq; Type: SEQUENCE SET; Schema: auth; Owner: admin
--

SELECT pg_catalog.setval('auth.utenteruolo_id_seq', 2, true);


--
-- Name: nuclei_id_seq; Type: SEQUENCE SET; Schema: briefingcon; Owner: admin
--

SELECT pg_catalog.setval('briefingcon.nuclei_id_seq', 1, true);


--
-- Name: organici_id_seq; Type: SEQUENCE SET; Schema: briefingcon; Owner: admin
--

SELECT pg_catalog.setval('briefingcon.organici_id_seq', 1, true);


--
-- Name: organicidisponibili_id_seq; Type: SEQUENCE SET; Schema: briefingcon; Owner: admin
--

SELECT pg_catalog.setval('briefingcon.organicidisponibili_id_seq', 1, false);


--
-- Name: organicitipologie_id_seq; Type: SEQUENCE SET; Schema: briefingcon; Owner: admin
--

SELECT pg_catalog.setval('briefingcon.organicitipologie_id_seq', 1, true);


--
-- Name: qualifiche_id_seq; Type: SEQUENCE SET; Schema: briefingcon; Owner: admin
--

SELECT pg_catalog.setval('briefingcon.qualifiche_id_seq', 2, true);


--
-- Name: servizi_id_seq; Type: SEQUENCE SET; Schema: briefingcon; Owner: admin
--

SELECT pg_catalog.setval('briefingcon.servizi_id_seq', 1, false);


--
-- Name: specializzazioni_id_seq; Type: SEQUENCE SET; Schema: briefingcon; Owner: admin
--

SELECT pg_catalog.setval('briefingcon.specializzazioni_id_seq', 2, true);


--
-- Name: sedi_id_seq; Type: SEQUENCE SET; Schema: generic; Owner: admin
--

SELECT pg_catalog.setval('generic.sedi_id_seq', 9, true);


--
-- Name: seditipologie_id_seq; Type: SEQUENCE SET; Schema: generic; Owner: admin
--

SELECT pg_catalog.setval('generic.seditipologie_id_seq', 3, true);


--
-- Name: ruolo ruolo_pkey; Type: CONSTRAINT; Schema: auth; Owner: admin
--

ALTER TABLE ONLY auth.ruolo
    ADD CONSTRAINT ruolo_pkey PRIMARY KEY (id);


--
-- Name: utenteruolo utenteruolo_pkey; Type: CONSTRAINT; Schema: auth; Owner: admin
--

ALTER TABLE ONLY auth.utenteruolo
    ADD CONSTRAINT utenteruolo_pkey PRIMARY KEY (id);


--
-- Name: nuclei nuclei_pkey; Type: CONSTRAINT; Schema: briefingcon; Owner: admin
--

ALTER TABLE ONLY briefingcon.nuclei
    ADD CONSTRAINT nuclei_pkey PRIMARY KEY (id);


--
-- Name: organici organici_pkey; Type: CONSTRAINT; Schema: briefingcon; Owner: admin
--

ALTER TABLE ONLY briefingcon.organici
    ADD CONSTRAINT organici_pkey PRIMARY KEY (id);


--
-- Name: organicidisponibili organicidisponibili_pkey; Type: CONSTRAINT; Schema: briefingcon; Owner: admin
--

ALTER TABLE ONLY briefingcon.organicidisponibili
    ADD CONSTRAINT organicidisponibili_pkey PRIMARY KEY (id);


--
-- Name: organicitipologie organicitipologie_pkey; Type: CONSTRAINT; Schema: briefingcon; Owner: admin
--

ALTER TABLE ONLY briefingcon.organicitipologie
    ADD CONSTRAINT organicitipologie_pkey PRIMARY KEY (id);


--
-- Name: qualifiche qualifiche_pkey; Type: CONSTRAINT; Schema: briefingcon; Owner: admin
--

ALTER TABLE ONLY briefingcon.qualifiche
    ADD CONSTRAINT qualifiche_pkey PRIMARY KEY (id);


--
-- Name: servizi servizi_pkey; Type: CONSTRAINT; Schema: briefingcon; Owner: admin
--

ALTER TABLE ONLY briefingcon.servizi
    ADD CONSTRAINT servizi_pkey PRIMARY KEY (id);


--
-- Name: specializzazioni specializzazioni_pkey; Type: CONSTRAINT; Schema: briefingcon; Owner: admin
--

ALTER TABLE ONLY briefingcon.specializzazioni
    ADD CONSTRAINT specializzazioni_pkey PRIMARY KEY (id);


--
-- Name: sedi sedi_pkey; Type: CONSTRAINT; Schema: generic; Owner: admin
--

ALTER TABLE ONLY generic.sedi
    ADD CONSTRAINT sedi_pkey PRIMARY KEY (id);


--
-- Name: seditipologie seditipologie_pkey; Type: CONSTRAINT; Schema: generic; Owner: admin
--

ALTER TABLE ONLY generic.seditipologie
    ADD CONSTRAINT seditipologie_pkey PRIMARY KEY (id);


--
-- Name: utenteruolo utenteruolo_ruoloid_fkey; Type: FK CONSTRAINT; Schema: auth; Owner: admin
--

ALTER TABLE ONLY auth.utenteruolo
    ADD CONSTRAINT utenteruolo_ruoloid_fkey FOREIGN KEY (ruoloid) REFERENCES auth.ruolo(id);


--
-- Name: organici organici_tipologiaid_fkey; Type: FK CONSTRAINT; Schema: briefingcon; Owner: admin
--

ALTER TABLE ONLY briefingcon.organici
    ADD CONSTRAINT organici_tipologiaid_fkey FOREIGN KEY (tipologiaid) REFERENCES briefingcon.organicitipologie(id);


--
-- Name: organicidisponibili organicidisponibili_servizioid_fkey; Type: FK CONSTRAINT; Schema: briefingcon; Owner: admin
--

ALTER TABLE ONLY briefingcon.organicidisponibili
    ADD CONSTRAINT organicidisponibili_servizioid_fkey FOREIGN KEY (servizioid) REFERENCES briefingcon.servizi(id);


--
-- Name: organicidisponibili organicidisponibili_tipologiaid_fkey; Type: FK CONSTRAINT; Schema: briefingcon; Owner: admin
--

ALTER TABLE ONLY briefingcon.organicidisponibili
    ADD CONSTRAINT organicidisponibili_tipologiaid_fkey FOREIGN KEY (tipologiaid) REFERENCES briefingcon.organicitipologie(id);


--
-- Name: organicitipologie organicitipologie_nucleoid_fkey; Type: FK CONSTRAINT; Schema: briefingcon; Owner: admin
--

ALTER TABLE ONLY briefingcon.organicitipologie
    ADD CONSTRAINT organicitipologie_nucleoid_fkey FOREIGN KEY (nucleoid) REFERENCES briefingcon.nuclei(id);


--
-- Name: organicitipologie organicitipologie_qualificaid_fkey; Type: FK CONSTRAINT; Schema: briefingcon; Owner: admin
--

ALTER TABLE ONLY briefingcon.organicitipologie
    ADD CONSTRAINT organicitipologie_qualificaid_fkey FOREIGN KEY (qualificaid) REFERENCES briefingcon.qualifiche(id);


--
-- Name: organicitipologie organicitipologie_sedeid_fkey; Type: FK CONSTRAINT; Schema: briefingcon; Owner: admin
--

ALTER TABLE ONLY briefingcon.organicitipologie
    ADD CONSTRAINT organicitipologie_sedeid_fkey FOREIGN KEY (sedeid) REFERENCES generic.sedi(id);


--
-- Name: organicitipologie organicitipologie_specializzazioneid_fkey; Type: FK CONSTRAINT; Schema: briefingcon; Owner: admin
--

ALTER TABLE ONLY briefingcon.organicitipologie
    ADD CONSTRAINT organicitipologie_specializzazioneid_fkey FOREIGN KEY (specializzazioneid) REFERENCES briefingcon.specializzazioni(id);


--
-- Name: sedi sedi_parentid_fkey; Type: FK CONSTRAINT; Schema: generic; Owner: admin
--

ALTER TABLE ONLY generic.sedi
    ADD CONSTRAINT sedi_parentid_fkey FOREIGN KEY (parentid) REFERENCES generic.sedi(id);


--
-- Name: sedi sedi_tipologiaid_fkey; Type: FK CONSTRAINT; Schema: generic; Owner: admin
--

ALTER TABLE ONLY generic.sedi
    ADD CONSTRAINT sedi_tipologiaid_fkey FOREIGN KEY (tipologiaid) REFERENCES generic.seditipologie(id);


--
-- PostgreSQL database dump complete
--

